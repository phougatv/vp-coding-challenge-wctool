namespace VP.CodingChallenge.WCNet.CommandParsers;

<<<<<<< HEAD
internal class DefaultCommandParser
{
    private const String Dash = "-";
    private const String EmptyString = "";

    public static Result<CommandRequest> Parse(String[] args, ParserOptions? options)
    {
        if (IsIncorrectFormat(args))
        {
            return Result<CommandRequest>.Fail(CommandFormatError.Create());
        }

        if (IsConfigurationMissing(options))
        {
            return Result<CommandRequest>.Fail(ParserOptionsMissingError.Create());
        }

        var filename = args[^1];
        if (IsDefault(args))
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
    private static Boolean IsDefault(String[] args) => args.Length == 1;
    private static Boolean IsExtensionNotAllowed(String current, String allowed)
        => !String.Equals(current, allowed, StringComparison.OrdinalIgnoreCase);
    private static Boolean IsIncorrectFormat([NotNullWhen(false)]String[] args)
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
        if (IsExtensionNotAllowed(extension, allowedExtension))
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
=======
internal class DefaultCommandParser : ICommandParser
{
    private readonly ParserOptions _options;

    public DefaultCommandParser(IOptions<ParserOptions> options)
    {
        _options = options.Value;
    }

    public Result<CommandArgument> Parse(String[] args)
    {
        if (HasUnexpectedNumberOfItems(args))
        {
            return Result<CommandArgument>.Fail(CommandFormatError.Create());
        }

        if (HasSingleItem(args))
        {
            return ParseToDefaultCommands(args);
        }

        return ParseToSpecifiedCommands(args);
    }

    #region Private Methods
    private Result<CommandArgument> ParseToDefaultCommands(String[] args)
    {
        var filename = args[^1];
        var filepath = Path.Combine(_options.Directory, filename);
        if (!IsFileExtensionAllowed(filename))
        {
            return Result<CommandArgument>.Fail(FileExtensionNotAllowedError.Create(Path.GetExtension(filename)));
        }

        if (FileDoesNotExists(filepath))
        {
            return Result<CommandArgument>.Fail(FileNotFoundError.Create(filename));
        }

        return Result<CommandArgument>.Ok(CommandArgument.Create(_options.DefaultCommands, filepath));
    }

    private Result<CommandArgument> ParseToSpecifiedCommands(String[] args)
    {
        var commandRegex = new Regex(_options.CommandExpression);
        var commandValue = args[0];
        if (!commandRegex.IsMatch(commandValue))
        {
            return Result<CommandArgument>.Fail(CommandNotFoundError.Create(commandValue));
        }

        var filename = args[^1];
        if (!IsFileExtensionAllowed(filename))
        {
            return Result<CommandArgument>.Fail(FileExtensionNotAllowedError.Create(Path.GetExtension(filename)));
        }

        var filepath = Path.Combine(_options.Directory, filename);
        if (FileDoesNotExists(filepath))
        {
            return Result<CommandArgument>.Fail(FileNotFoundError.Create(filename));
        }

        var keys = new CommandKey[] { commandValue.Replace("-", "") };
        return Result<CommandArgument>.Ok(CommandArgument.Create(keys, filepath));
    }

    private static Boolean HasUnexpectedNumberOfItems(String[] args)
        => args.Length < 1 || args.Length > 2;
    private static Boolean HasSingleItem(String[] args)
        => args.Length == 1;

    private static Boolean FileDoesNotExists(String filepath)
        => !File.Exists(filepath);
    private Boolean IsFileExtensionAllowed(String filename)
        => _options.AllowedFileExtension.Equals(Path.GetExtension(filename));
>>>>>>> master
    #endregion Private Methods
}
