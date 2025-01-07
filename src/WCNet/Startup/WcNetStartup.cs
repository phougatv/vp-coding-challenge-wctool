namespace VP.CodingChallenge.WCNet.Startup;

internal class WcNetStartup
{
    private const String DefaultAppSettingsFileName = "appsettings.json";

    internal static async Task MainAsync(String[] args)
    {
        try
        {
            var options = GetParserOptions();
            var parser = GetParser();
            var commandRequestResult = parser.Parse(args, options);
            if (commandRequestResult.IsFailed)
            {
                throw new ParserOptionsLoadFailedException();
            }

            var serviceProvider = BuildWcNetServiceProvider(commandRequestResult.Value.FilePath);
            var handler = serviceProvider.GetRequiredService<AsyncCommandsHandler>();
            await handler.Main(commandRequestResult.Value);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Application terminated. Error: {ex.Message}");
            AsyncCommandHandlerBase.Usage();
        }
    }

    #region Private Methods
    private static DefaultCommandParser GetParser()
    {
        var fileOperation = new DefaultFile();
        return new DefaultCommandParser(fileOperation);
    }
    private static CommandParsingOptions? GetParserOptions()
    {
        var builder = new ConfigurationBuilder();
        var configuration = BuildWcNetConfiguration(builder);
        var options = configuration.GetSection(nameof(CommandParsingOptions)).Get<CommandParsingOptions>();
        if (options is not null && options.DefaultCommandsRaw.Length > 0)
        {
            options.DefaultCommands = options.DefaultCommandsRaw.Select(dc => new CommandKey(dc)).ToArray();
        }

        return options;
    }
    private static IConfiguration BuildWcNetConfiguration(IConfigurationBuilder builder)
        => builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(path: DefaultAppSettingsFileName, optional: true, reloadOnChange: true)
            .Build();
    internal static IServiceProvider BuildWcNetServiceProvider(FilePath filepath)
    {
        var services = new ServiceCollection();

        return services
            .AddWcNet(filepath)
            .BuildServiceProvider();
    }
    #endregion Private Methods
}
