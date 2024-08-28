namespace VP.CodingChallenge.WCNet.Chassis;

public class Program
{
	private static readonly IServiceCollection ServiceCollection = new ServiceCollection();

	static void Main(String[] args)
	{
		//WC configuration provider
		var configuration = GetWcConfigurationBuilder().Build();

		//WC service provider
		var serviceProvider = ServiceCollection.BuildWcNetServiceProvider(configuration);

		//Execute DefaultCommandHandler.Handle
		var commandHandler = serviceProvider.GetRequiredService<DefaultCommandHandler>();
		commandHandler.Handle(args);
	}

	internal static IConfigurationBuilder GetWcConfigurationBuilder()
	{
		var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

		return builder;
	}
}
