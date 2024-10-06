namespace VP.CodingChallenge.WCNet.Startup;

internal static class WCNetServiceExtension
{
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
            .Where(type =>
                //type.GetInterfaces().Any(i =>
                //    i.IsGenericType &&
                //    i.GetGenericTypeDefinition() == typeof(ICommand<>)) &&
                //!type.IsAbstract &&
                //type.IsClass)
                typeof(ICommand).IsAssignableFrom(type) && !type.IsAbstract && type.IsClass)
            .ToList();
            var commandTypeMap = new Dictionary<Command, Type>(commandTypes.Count);
            foreach (var type in commandTypes)
            {
                var commandKeyAttribute = type.GetCustomAttribute<CommandKeyAttribute>();
                if (commandKeyAttribute is null) continue;
                commandTypeMap.Add(commandKeyAttribute.Key, type);
            }

            //var output = provider.GetRequiredService<IOutput>();
            return new CountCommandFactory(commandTypeMap);
        });

        return services;
    }

    private static IServiceCollection AddWCNetOutput(this IServiceCollection services)
        => services.AddSingleton<IOutput, ConsoleOutput>();

    private static IServiceCollection AddWCNetCommandResolver(this IServiceCollection services)
        => services.AddSingleton<ICommandResolver, DefaultCommandResolver>();

    private static IServiceCollection AddWCNetCommandInvoker(this IServiceCollection services)
        => services.AddSingleton<ICommandInvoker, DefaultCommandInvoker>();

    //private static IServiceCollection AddWCNetCommandHandler(this IServiceCollection services)
    //    => services.AddSingleton<CommandHandlerBase, DefaultCommandHandler>();
    private static IServiceCollection AddWCNetCommandHandler(this IServiceCollection services)
        => services.AddSingleton<DefaultCommandHandler>();

    //private static IServiceCollection Add
}
