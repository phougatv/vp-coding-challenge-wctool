namespace VP.CodingChallenge.WCNet.Startup;

internal static class WCNetServiceExtension
{
<<<<<<< HEAD
    internal static IServiceProvider BuildWCNetServiceProvider(this IServiceCollection services)
        => services.AddWCNet().BuildServiceProvider();

    private static IServiceCollection AddWCNet(this IServiceCollection services)
        => services
            .AddWCNetOutput()
            .AddWCNetCommandFactories()
            .AddWCNetCommandResolver()
            .AddWCNetCommandInvoker()
            .AddWCNetCommandHandler();

    private static IServiceCollection AddWCNetCommandFactories(this IServiceCollection services)
    {
        services.AddSingleton<ICommandFactory>(provider =>
        {
            var commandTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => typeof(ICommand).IsAssignableFrom(type) && !type.IsAbstract && type.IsClass)
            .ToList();
            var commandTypeMap = new Dictionary<Command, Type>(commandTypes.Count);
            foreach (var type in commandTypes)
            {
                var commandKeyAttribute = type.GetCustomAttribute<CommandKeyAttribute>();
                if (commandKeyAttribute is null) continue;
                commandTypeMap.Add(commandKeyAttribute.Key, type);
            }

            var output = provider.GetRequiredService<IOutput>();
            return new CountCommandFactory(commandTypeMap, output);
        });
=======
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
            Console.WriteLine("No commands found to register.");
            return services;
        }

        foreach (var commandType in _concreteCommandTypes)
        {
            RegisterCommand(services, commandType);
        }
>>>>>>> master

        return services;
    }

<<<<<<< HEAD
    private static IServiceCollection AddWCNetOutput(this IServiceCollection services)
        => services.AddSingleton<IOutput, ConsoleOutput>();

    private static IServiceCollection AddWCNetCommandResolver(this IServiceCollection services)
        => services.AddSingleton<ICommandResolver, DefaultCommandResolver>();

    private static IServiceCollection AddWCNetCommandInvoker(this IServiceCollection services)
        => services.AddSingleton<ICommandInvoker, DefaultCommandInvoker>();

    private static IServiceCollection AddWCNetCommandHandler(this IServiceCollection services)
        => services.AddSingleton<CommandHandlerBase, DefaultCommandHandler>();
=======
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
        => services
            .AddScoped<ICommandParser, DefaultCommandParser>()
            .AddWcNetParserOptions (configuration);

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
>>>>>>> master
}
