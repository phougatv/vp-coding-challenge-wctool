namespace VP.CodingChallenge.WCNet.Startup;

internal static class WCNetServiceExtension
{
	private readonly static Type _iCommandType = typeof(ICommand);
	private static List<Type> _concreteCommandTypes = [];
	private static List<String> _allowedCommands = [];

	internal static IServiceProvider BuildWCNetServiceProvider(this IServiceCollection services, IConfiguration configuration)
	{
		InitializeConcreteCommandTypes();
		InitializeAllowedCommands();

		return services.AddWCNet(configuration).BuildServiceProvider();
	}

	private static IServiceCollection AddWCNet(this IServiceCollection services, IConfiguration configuration)
		=> services
			.AddWCNetCommands()
			.AddWCNetCommandResolver()
			.AddWCNetCommandParser(configuration)
			.AddWCNetCommandHandler();

	private static IServiceCollection AddWCNetCommands(this IServiceCollection services)
	{
		if (_concreteCommandTypes.Count == 0)
		{
			//need to log the error
			return services;
		}

		foreach (var commandType in _concreteCommandTypes)
		{
			var keyAttribute = commandType.GetCustomAttribute<CommandKeyAttribute>();
			if (keyAttribute is null) continue;

			services.AddKeyedScoped(_iCommandType, keyAttribute.Key, commandType);
		}

		return services;
	}

	private static IServiceCollection AddWCNetCommandResolver(this IServiceCollection services)
		=> services.AddScoped<ICommandResolver, DefaultCommandResolver>(provider =>
			{
				var commandMap = new Dictionary<CommandKey, ICommand>(_concreteCommandTypes.Count);
				foreach (var commandType in _concreteCommandTypes)
				{
					var attribute = commandType.GetCustomAttribute<CommandKeyAttribute>();
					if (attribute is null) continue;

					var commandInstance = provider.GetRequiredKeyedService<ICommand>(attribute.Key);
					commandMap[attribute.Key] = commandInstance;
				}

				return new DefaultCommandResolver(commandMap);
			});

	private static IServiceCollection AddWCNetCommandParser(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<ICommandParser, DefaultCommandParser>();

		var section = configuration.GetSection(nameof(ParserOptions));
		if (section is null)
		{
			return services;
		}

		return services.Configure<ParserOptions>(section);
	}

	private static IServiceCollection AddWCNetCommandHandler(this IServiceCollection services)
		=> services.AddScoped<CommandHandlerBase, DefaultCommandHandler>();

	private static void InitializeConcreteCommandTypes()
	{
		_concreteCommandTypes = Assembly
			.GetExecutingAssembly()
			.GetTypes()
			.Where(type => _iCommandType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
			.ToList();
	}
	private static void InitializeAllowedCommands()
	{
		_allowedCommands = new List<String>(_concreteCommandTypes.Count);
		foreach (var type in _concreteCommandTypes)
		{
			var attribute = type.GetCustomAttribute<CommandKeyAttribute>();
			if (attribute is null)
			{
				continue;
			}

			_allowedCommands.Add(attribute.Key);
		}
	}
}
