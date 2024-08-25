namespace VP.CodingChallenge.WCNet.Chassis;

using Microsoft.Extensions.DependencyInjection;
using VP.CodingChallenge.WCNet.CommandHandlers;
using VP.CodingChallenge.WCNet.Startup;

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
