namespace VP.CodingChallenge.WCNet.Configurations;

public class ParserOptions
{
    public String AllowedFileExtension { get; set; } = String.Empty;
    public String CommandExpression { get; set; } = String.Empty;
    public CommandKey[] DefaultCommands { get; set; } = [];
    public String Directory { get; set; } = String.Empty;

    [JsonIgnore]
    public String[] DefaultCommandsRaw { get; set; } = [];
}
