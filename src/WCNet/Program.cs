namespace VP.CodingChallenge.WCNet;

using Microsoft.Extensions.DependencyInjection;
using VP.CodingChallenge.WCNet.CommandHandlers;
using VP.CodingChallenge.WCNet.CommandResolvers;
using VP.CodingChallenge.WCNet.Commands;
using VP.CodingChallenge.WCNet.Commands.Concrete;

public class Program
{
	//private const String Directory = @".\Files";

	static void Main(String[] args)
	{
		var services = new ServiceCollection();

		//Add commands
		services
			.AddKeyedScoped<ICommand, ByteCountCommand>("-c")
			.AddKeyedScoped<ICommand, LineCountCommand>("-l");

		//Add Resolver
		services
			.AddScoped<ICommandResolver, DefaultCommandResolver>(provider =>
			{
				var keys = new[] { "-c", "-l" }; // Extend this as needed or use reflection to automate
				var commandMap = keys
				.ToDictionary(
					key => key,
					key => provider.GetRequiredKeyedService<ICommand>(key));

				return new DefaultCommandResolver(commandMap);
			});

		//Add Handler
		services.AddScoped<DefaultCommandHandler>();

		//Build ServiceProvider
		var serviceProvider = services.BuildServiceProvider();

		//Execute DefaultCommandHandler.Handle
		var commandHandler = serviceProvider.GetRequiredService<DefaultCommandHandler>();
		commandHandler.Handle(args);
	}
}
