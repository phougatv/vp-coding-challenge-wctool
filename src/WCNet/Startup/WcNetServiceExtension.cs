namespace VP.CodingChallenge.WCNet.Startup;

[ExcludeFromCodeCoverage]
internal static class WCNetServiceExtension
{
    internal static IServiceProvider BuildWCNetServiceProvider(this IServiceCollection services, Filepath filepath)
        => services.AddWCNet(filepath).BuildServiceProvider();

    private static IServiceCollection AddWCNet(this IServiceCollection services, Filepath filepath)
        => services
            .AddWCNetFileHandlers(filepath)
            .AddWCNetCountCommands()
            .AddWCNetOutput()
            .AddWCNetCommandFactories()
            .AddWCNetCommandInvokers()
            .AddWCNetCommandHandlers();

    private static IServiceCollection AddWCNetCommandFactories(this IServiceCollection services)
        => services.AddSingleton<ICommandFactory, CountCommandFactory>();

    private static IServiceCollection AddWCNetCountCommands(this IServiceCollection services)
    {
        var commandTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => typeof(ICommand).IsAssignableFrom(type) && !type.IsAbstract && type.IsClass)
            .ToList();

        foreach (var type in commandTypes)
        {
            var commandKeyAttribute = type.GetCustomAttribute<CommandKeyAttribute>();
            if (commandKeyAttribute is null) continue;

            services.AddKeyedSingleton(typeof(ICommand), commandKeyAttribute.Key, type);
        }

        return services;
    }

    private static IServiceCollection AddWCNetOutput(this IServiceCollection services)
        => services.AddSingleton<IOutput, ConsoleOutput>();

    private static IServiceCollection AddWCNetCommandInvokers(this IServiceCollection services)
        => services.AddSingleton<ICommandInvoker, CommandInvoker>();

    private static IServiceCollection AddWCNetCommandHandlers(this IServiceCollection services)
        => services
            .AddSingleton<DefaultCommandHandler>()
            .AddSingleton<UserCommandHandler>();

    private static IServiceCollection AddWCNetFileHandlers(this IServiceCollection services, Filepath filepath)
    {
        var document = new Document(filepath);
        services
            .AddSingleton<IByteCountable>(document)
            .AddSingleton<ICharacterCountable>(document)
            .AddSingleton<ILineCountable>(document)
            .AddSingleton<IWordCountable>(document);

        return services;
    }
}
