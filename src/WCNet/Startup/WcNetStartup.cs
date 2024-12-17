namespace VP.CodingChallenge.WCNet.Startup;

using VP.CodingChallenge.WCNet.Validators;

internal class WcNetStartup
{
    internal async Task Main(String[] args)
    {
        var wcNetConfigurationBuilder = GetWcNetConfigurationBuilder();
        var wcNetConfiguration = GetWcNetConfiguration(wcNetConfigurationBuilder);
        var options = GetWcParseOptions(wcNetConfiguration);
        if (!WcOptionsValidator.Validate(options, out var validationResults))
        {

        }

        var commandRequestResult = DefaultCommandParser.Parse(args, options);
        if (commandRequestResult.IsFailed)
        {
            throw new ParserOptionsLoadFailedException();
        }

        //Build WcNet service provider
        var serviceProvider = new ServiceCollection().BuildWCNetServiceProvider(commandRequestResult.Value.Filepath);
        var handler = serviceProvider.GetRequiredService<AsyncCommandsHandler>();
        await handler.Main(commandRequestResult.Value);
    }

    #region Private Methods
    private static IConfigurationBuilder GetWcNetConfigurationBuilder()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        return builder;
    }
    private static IConfiguration GetWcNetConfiguration(IConfigurationBuilder builder)
        => builder.Build();

    private static ParseOptions? GetWcParseOptions(IConfiguration configuration)
    {
        var options = configuration.GetSection(nameof(ParseOptions)).Get<ParseOptions>();
        if (options is not null && options.DefaultCommandsRaw.Length > 0)
        {
            options.DefaultCommands = options.DefaultCommandsRaw.Select(dc => new CommandKey(dc)).ToArray();
        }

        return options;
    }
    #endregion Private Methods
}
