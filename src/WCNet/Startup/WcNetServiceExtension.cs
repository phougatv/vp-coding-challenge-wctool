namespace VP.CodingChallenge.WCNet.Startup;

using Microsoft.Extensions.DependencyInjection;
using VP.CodingChallenge.WCNet.CommandHandlers;
using VP.CodingChallenge.WCNet.CommandResolvers;
using VP.CodingChallenge.WCNet.Commands;
using VP.CodingChallenge.WCNet.Commands.Concrete;

internal static class WcNetServiceExtension
{
	internal static IServiceProvider BuildWcNetServiceProvider(this IServiceCollection services)
		=> services.AddWcNet().BuildServiceProvider();

	private static IServiceCollection AddWcNet(this IServiceCollection services)
	{
		services
			.AddWcNetCommands()
			.AddWcNetCommandResolver()
			.AddWcNetCommandHandler();

		return services;
	}

	private static IServiceCollection AddWcNetCommands(this IServiceCollection services)
	{
		services
			.AddKeyedScoped<ICommand, ByteCountCommand>("-c")
			.AddKeyedScoped<ICommand, LineCountCommand>("-l");

		return services;
	}

	private static IServiceCollection AddWcNetCommandResolver(this IServiceCollection services)
	{
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

		return services;
	}

	private static IServiceCollection AddWcNetCommandHandler(this IServiceCollection services)
	{
		services.AddScoped<DefaultCommandHandler>();

		return services;
	}
}
