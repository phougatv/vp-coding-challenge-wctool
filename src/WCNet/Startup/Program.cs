namespace VP.CodingChallenge.WCNet;

[ExcludeFromCodeCoverage]
public class Program
{
    static async Task Main(String[] args)
    {
        try
        {
            //Build WcNet configuration
            var configuration = new ConfigurationBuilder().BuildWCNetConfiguration();
            var options = configuration.GetParserOptions();
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
        catch (Exception ex)
        {
            Console.WriteLine($"Application terminated. Error: {ex.Message}");
            AsyncCommandHandlerBase.Usage();
        }
    }
}
