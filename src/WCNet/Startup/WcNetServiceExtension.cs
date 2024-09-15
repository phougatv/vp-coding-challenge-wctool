namespace VP.CodingChallenge.WCNet.Startup;

internal static class WCNetServiceExtension
{
    private readonly static Type _iCommandType = typeof(ICommand);
    private static List<Type> _concreteCommandTypes = [];
    private static List<String> _allowedCommands = [];

    internal static IServiceProvider BuildWCNetServiceProvider(this IServiceCollection services)
    {
        InitializeConcreteCommandTypes();
        InitializeAllowedCommands();

        return services.AddWCNet().BuildServiceProvider();
    }

    private static IServiceCollection AddWCNet(this IServiceCollection services)
        => services
            .AddWCNetCommands()
            .AddWCNetCommandResolver()
            .AddWCNetCommandHandler();

    private static IServiceCollection AddWCNetCommands(this IServiceCollection services)
    {
        if (_concreteCommandTypes.Count == 0)
        {
            Console.WriteLine("No commands found to register.");
            return services;
        }

        foreach (var commandType in _concreteCommandTypes)
        {
            RegisterCommand(services, commandType);
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

    //private static IServiceCollection AddWCNetCommandParser(this IServiceCollection services, IConfiguration configuration)
    //    => services
    //        .AddScoped<ICommandParser, DefaultCommandParser>()
    //        .AddWcNetParserOptions (configuration);

    private static IServiceCollection AddWcNetParserOptions(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(nameof(ParserOptions));
        if (section is null)
        {
            return services;
        }

        return services
            .Configure<ParserOptions>(section)
            .PostConfigure<ParserOptions>(options =>
            {
                if (options.DefaultCommandsRaw is not null && options.DefaultCommandsRaw.Length > 0)
                {
                    options.DefaultCommands = options.DefaultCommandsRaw.Select(dc => new CommandKey(dc)).ToArray();
                }
            });
    }

    private static IServiceCollection AddWCNetCommandHandler(this IServiceCollection services)
        => services.AddScoped<CommandHandlerBase, DefaultCommandHandler>();

    private static void RegisterCommand(IServiceCollection services, Type commandType)
    {
        var attribute = commandType.GetCustomAttribute<CommandKeyAttribute>();
        if (attribute is null)
        {
            //Console.WriteLine($"Skipping registration for {commandType.Name}: No CommandKeyAttribute found.");
            return;
        }

        //register non-character count command
        if (!attribute.Key.IsCharacterCountKey())
        {
            services.AddKeyedScoped(_iCommandType, attribute.Key, commandType);
            return;
        }

        RegisterCharacterCountCommand(services, attribute.Key);
    }

    private static void RegisterCharacterCountCommand(IServiceCollection services, CommandKey key)
    {
        //register ByteCountCommand for single-byte encoding
        if (Encoding.Default.IsSingleByte)
        {
            services.AddKeyedScoped<ICommand, ByteCountCommand>(key);
            return;
        }

        //register CharacterCountCommand for multibyte encoding
        services.AddKeyedScoped<ICommand, CharacterCountCommand>(key);
    }

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
