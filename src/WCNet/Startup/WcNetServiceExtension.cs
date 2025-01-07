namespace VP.CodingChallenge.WCNet.Startup;

[ExcludeFromCodeCoverage]
internal static class WcNetServiceExtension
{
    internal static IServiceCollection AddWcNet(this IServiceCollection services, FilePath filepath)
        => services
            .AddWcNetFileHandlers(filepath)
            .AddWcNetCountCommands()
            .AddWcNetOutput()
            .AddWcNetCommandFactories()
            .AddWcNetCommandInvokers()
            .AddWcNetCommandHandlers();

    private static IServiceCollection AddWcNetCommandFactories(this IServiceCollection services)
        => services.AddSingleton<ICommandFactory, CountCommandFactory>();

    private static IServiceCollection AddWcNetCountCommands(this IServiceCollection services)
    {
        var commandTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => typeof(IAsyncCommand).IsAssignableFrom(type) && !type.IsAbstract && type.IsClass)
            .ToList();

        foreach (var type in commandTypes)
        {
            var commandKeyAttribute = type.GetCustomAttribute<CommandKeyAttribute>();
            if (commandKeyAttribute is null) continue;

            services.AddKeyedSingleton(typeof(IAsyncCommand), commandKeyAttribute.Key, type);
        }

        return services;
    }

    private static IServiceCollection AddWcNetOutput(this IServiceCollection services)
        => services.AddSingleton<IOutput, ConsoleOutput>();

    private static IServiceCollection AddWcNetCommandInvokers(this IServiceCollection services)
        => services.AddSingleton<IAsyncCommandInvoker, AsyncCommandInvoker>();

    private static IServiceCollection AddWcNetCommandHandlers(this IServiceCollection services)
        => services.AddSingleton<AsyncCommandsHandler>();

    private static IServiceCollection AddWcNetFileHandlers(this IServiceCollection services, FilePath filepath)
    {
        var document = new Document(filepath);
        services
            .AddSingleton<IByteCountable>(document)
            .AddSingleton<IAsyncCharacterCountable>(document)
            .AddSingleton<IAsyncLineCountable>(document)
            .AddSingleton<IAsyncWordCountable>(document);

        return services;
    }
}
