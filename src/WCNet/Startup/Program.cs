namespace VP.CodingChallenge.WCNet.Chassis;

public class Program
{
	private static readonly IServiceCollection ServiceCollection = new ServiceCollection();
    private static readonly IConfigurationBuilder ConfigurationBuilder = new ConfigurationBuilder();

	static void Main(String[] args)
	{
		//Build WcNet configuration
		var configuration = ConfigurationBuilder.BuildWcNetConfiguration();

		//Build WcNet service provider
		var serviceProvider = ServiceCollection.BuildWcNetServiceProvider(configuration);

		//Execute CommandHandlerBase.Main
		var commandHandler = serviceProvider.GetRequiredService<CommandHandlerBase>();
		commandHandler.Main(args);
	}
}
