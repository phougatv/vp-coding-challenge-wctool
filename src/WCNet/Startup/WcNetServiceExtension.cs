namespace VP.CodingChallenge.WCNet.Startup;

internal static class WCNetServiceExtension
{
    internal static IServiceProvider BuildWCNetServiceProvider(this IServiceCollection services)
        => services.AddWCNet().BuildServiceProvider();

    private static IServiceCollection AddWCNet(this IServiceCollection services)
        => services
            .AddWCNetCommandFactories()
            .AddWCNetCommandResolver()
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
            var commandTypeMap = new Dictionary<CommandKey, Type>(commandTypes.Count);
            foreach (var type in commandTypes)
            {
                var commandKeyAttribute = type.GetCustomAttribute<CommandKeyAttribute>();
                if (commandKeyAttribute is null) continue;
                commandTypeMap.Add(commandKeyAttribute.Key, type);
            }

            return new CountCommandFactory(commandTypeMap);
        });

        return services;
    }

    private static IServiceCollection AddWCNetCommandResolver(this IServiceCollection services)
        => services.AddScoped<ICommandResolver, DefaultCommandResolver>();

    private static IServiceCollection AddWCNetCommandHandler(this IServiceCollection services)
        => services.AddScoped<CommandHandlerBase, DefaultCommandHandler>();
}
