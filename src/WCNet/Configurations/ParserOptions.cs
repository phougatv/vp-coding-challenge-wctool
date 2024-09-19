namespace VP.CodingChallenge.WCNet.Configurations;

public class ParserOptions
{
    public String AllowedFileExtension { get; set; } = String.Empty;
    public String AllowedCommandPattern { get; set; } = String.Empty;
    public Command[] DefaultCommands { get; set; } = [];
    public String Directory { get; set; } = String.Empty;

    [JsonIgnore]
    public String[] DefaultCommandsRaw { get; set; } = [];
}
