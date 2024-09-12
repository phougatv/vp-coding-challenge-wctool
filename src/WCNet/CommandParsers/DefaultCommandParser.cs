namespace VP.CodingChallenge.WCNet.CommandParsers;

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
    #endregion Private Methods
}
