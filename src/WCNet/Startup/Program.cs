namespace VP.CodingChallenge.WCNet.Chassis;

public class Program
{
	private static readonly IServiceCollection ServiceCollection = new ServiceCollection();
    private static readonly IConfigurationBuilder ConfigurationBuilder = new ConfigurationBuilder();

	static void Main(String[] args)
	{
        try
        {
            //Build WcNet configuration
            var configuration = ConfigurationBuilder.BuildWCNetConfiguration();
            var options = configuration.GetSection(nameof(ParserOptions)).Get<ParserOptions>();
            if (options is not null && options.DefaultCommandsRaw.Length > 0)
            {
                options.DefaultCommands = options.DefaultCommandsRaw.Select(dc => new CommandKey(dc)).ToArray();
            }

            var commandRequestResult = DefaultCommandParser.Parse(args, options);
            if (commandRequestResult.IsFailed)
            {
                throw new Exception("Failed to load ParserOptions.");
            }

            //Build WcNet service provider
            var serviceProvider = ServiceCollection.BuildWCNetServiceProvider();

            //Execute CommandHandlerBase.Main
            var commandHandler = serviceProvider.GetRequiredService<CommandHandlerBase>();
            commandHandler.Main(commandRequestResult.Value);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Application terminated. Error: {ex.Message}");
        }
	}
}
