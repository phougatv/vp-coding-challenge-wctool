namespace VP.CodingChallenge.WCNet.Startup;

internal static class WCNetConfigurationExtension
{
    internal static IConfiguration BuildWCNetConfiguration(this IConfigurationBuilder builder)
        => builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
}
