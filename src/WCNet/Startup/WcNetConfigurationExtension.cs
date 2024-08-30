namespace VP.CodingChallenge.WCNet.Startup;

internal static class WcNetConfigurationExtension
{
    internal static IConfiguration BuildWcNetConfiguration(this IConfigurationBuilder builder)
        => builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
}
