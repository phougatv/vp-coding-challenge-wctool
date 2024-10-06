namespace VP.CodingChallenge.WCNet.CommandParsers;

internal class DefaultCommandParser
{
    private const String Dash = "-";
    private const String EmptyString = "";

    public static Result<CommandRequest> Parse(String[] args, ParserOptions? options)
    {
        if (IsIncorrectCommandFormat(args))
        {
            return Result<CommandRequest>.Fail(CommandFormatError.Create());
        }

        if (IsConfigurationMissing(options))
        {
            return Result<CommandRequest>.Fail(ParserOptionsMissingError.Create());
        }

        var filename = args[^1];
        if (IsDefaultCommand(args))
        {
            return ParseToDefaultCommands(options.DefaultCommands, options.Directory, filename, options.AllowedFileExtension);
        }

        var command = args[0];
        return ParseToCommand(command, options.AllowedCommandPattern, options.Directory, filename, options.AllowedFileExtension);
    }

    #region Private Methods
    private static Boolean IsConfigurationMissing([NotNullWhen(false)] ParserOptions? options)
        => options is null ||
        options.DefaultCommands.Length == 0 ||
        String.IsNullOrEmpty(options.AllowedCommandPattern) ||
        String.IsNullOrEmpty(options.AllowedFileExtension);
    private static Boolean IsDefaultCommand(String[] args) => args.Length == 1;
    private static Boolean IsFileExtensionNotAllowed(String current, String allowed)
        => !String.Equals(current, allowed, StringComparison.OrdinalIgnoreCase);
    private static Boolean IsIncorrectCommandFormat([NotNullWhen(false)]String[] args)
        => args is null ||
        args.Length < 1 ||
        args.Length > 2;
    private static String RemoveDash(String commandValue) => commandValue.Replace(Dash, EmptyString);

    private static Result<CommandRequest> ParseToDefaultCommands(
        Command[] defaultCommands,
        String directory,
        String filename,
        String allowedExtension)
    {
        var filepathResult = ValidateFilepath(directory, filename, allowedExtension);
        if (filepathResult.IsFailed)
        {
            return Result<CommandRequest>.Fail(filepathResult.Error);
        }

        return Result<CommandRequest>.Ok(CommandRequest.CreateDefault(defaultCommands, filepathResult.Value));
    }

    private static Result<CommandRequest> ParseToCommand(
        String commandValue,
        String allowedCommandPattern,
        String directory,
        String filename,
        String allowedExtension)
    {
        var commandRegex = new Regex(allowedCommandPattern);
        if (!commandRegex.IsMatch(commandValue))
        {
            return Result<CommandRequest>.Fail(CommandNotFoundError.Create());
        }

        var filepathResult = ValidateFilepath(directory, filename, allowedExtension);
        if (filepathResult.IsFailed)
        {
            return Result<CommandRequest>.Fail(filepathResult.Error);
        }

        var command = RemoveDash(commandValue);
        return Result<CommandRequest>.Ok(CommandRequest.Create(command, filepathResult.Value));
    }

    private static Result<Filepath> ValidateFilepath(String directory, String filename, String allowedExtension)
    {
        var extension = Path.GetExtension(filename);
        if (IsFileExtensionNotAllowed(extension, allowedExtension))
        {
            return Result<Filepath>.Fail(FileExtensionNotAllowedError.Create(extension));
        }

        var filepath = Path.Combine(directory, filename);
        if (!File.Exists(filepath))
        {
            return Result<Filepath>.Fail(FileNotFoundError.Create(filename));
        }

        return Result<Filepath>.Ok(filepath);
    }
    #endregion Private Methods
}
