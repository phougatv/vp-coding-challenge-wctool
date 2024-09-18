namespace VP.CodingChallenge.WCNet.Startup;

internal static class WCNetConfigurationExtension
{
    internal static IConfiguration BuildWCNetConfiguration(this IConfigurationBuilder builder)
        => builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
<<<<<<< HEAD
    internal static ParserOptions? GetParserOptions(this IConfiguration configuration)
    {
        var options = configuration.GetSection(nameof(ParserOptions)).Get<ParserOptions>();
        if (options is not null && options.DefaultCommandsRaw.Length > 0)
        {
            options.DefaultCommands = options.DefaultCommandsRaw.Select(dc => new Command(dc)).ToArray();
        }

        return options;
    }
=======
>>>>>>> master
}
