namespace VP.CodingChallenge.WCNet.Configurations;

[ExcludeFromCodeCoverage]
public class ParseOptions
{
    public String AllowedFileExtension { get; set; } = String.Empty;
    public String AllowedCommandPattern { get; set; } = String.Empty;
    public CommandKey[] DefaultCommands { get; set; } = [];
    public String Directory { get; set; } = String.Empty;

    [JsonIgnore]
    public String[] DefaultCommandsRaw { get; set; } = [];
}
