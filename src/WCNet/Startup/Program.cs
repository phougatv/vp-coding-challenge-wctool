﻿namespace VP.CodingChallenge.WCNet.Chassis;

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
            var options = configuration.GetParserOptions();
            var commandRequestResult = DefaultCommandParser.Parse(args, options);
            if (commandRequestResult.IsFailed)
            {
                throw new ParserOptionsLoadFailedException();
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
