namespace VP.CodingChallenge.WCNet.Chassis;

public class Program
{
    static void Main(String[] args)
    {
        try
        {
            //Build WcNet configuration
            var configuration = new ConfigurationBuilder().BuildWCNetConfiguration();
            var options = configuration.GetParserOptions();
            var commandRequestResult = CommandParser.Parse(args, options);
            if (commandRequestResult.IsFailed)
            {
                throw new ParserOptionsLoadFailedException();
            }

            //Build WcNet service provider
            var serviceProvider = new ServiceCollection().BuildWCNetServiceProvider(commandRequestResult.Value.Filepath);

            //Execute CommandHandlerBase.Main
            CommandHandlerBase? handler = commandRequestResult.Value.IsDefault
                ? serviceProvider.GetRequiredService<DefaultCommandHandler>()
                : serviceProvider.GetRequiredService<UserCommandHandler>();

            handler.Main(commandRequestResult.Value);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Application terminated. Error: {ex.Message}");
            CommandHandlerBase.Usage();
        }
    }
}
