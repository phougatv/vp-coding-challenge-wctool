namespace VP.CodingChallenge.WCNet.Chassis;

public class Program
{
	private static readonly IServiceCollection ServiceCollection = new ServiceCollection();

	static void Main(String[] args)
	{
		//WC service provider
		var serviceProvider = ServiceCollection.BuildWcNetServiceProvider();

		//Execute DefaultCommandHandler.Handle
		var commandHandler = serviceProvider.GetRequiredService<DefaultCommandHandler>();
		commandHandler.Handle(args);
	}
}
