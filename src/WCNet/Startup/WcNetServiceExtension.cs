namespace VP.CodingChallenge.WCNet.Startup;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VP.CodingChallenge.WCNet.Attributes;
using VP.CodingChallenge.WCNet.CommandHandlers;
using VP.CodingChallenge.WCNet.CommandResolvers;
using VP.CodingChallenge.WCNet.Commands;

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
		var commandInterfaceType = typeof(ICommand);
		var concreteCommandTypes = Assembly
			.GetExecutingAssembly()
			.GetTypes()
			.Where(type => commandInterfaceType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
			.ToList();
		foreach (var commandType in concreteCommandTypes)
		{
			var keyAttribute = commandType.GetCustomAttribute<CommandKeyAttribute>();
			if (keyAttribute is null) continue;

			services.AddKeyedScoped(commandInterfaceType, keyAttribute.Key, commandType);
		}

		return services;
	}

	private static IServiceCollection AddWcNetCommandResolver(this IServiceCollection services)
	{
		services
			.AddScoped<ICommandResolver, DefaultCommandResolver>(provider =>
			{
				var commandInterfaceType = typeof(ICommand);
				var concreteCommandTypes = Assembly
					.GetExecutingAssembly()
					.GetTypes()
					.Where(type => commandInterfaceType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
					.ToList();					
				var commandMap = new Dictionary<String, ICommand>(concreteCommandTypes.Count);
				foreach (var commandType in concreteCommandTypes)
				{
					var attribute = commandType.GetCustomAttribute<CommandKeyAttribute>();
					if (attribute is null) continue;

					var commandInstance = provider.GetRequiredKeyedService<ICommand>(attribute.Key);
					commandMap[attribute.Key] = commandInstance;
				}

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
