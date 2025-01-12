[assembly: InternalsVisibleTo("VP.CodingChallenge.WCNet.UnitTest")]
namespace VP.CodingChallenge.WCNet.CommandParsers;

internal class DefaultCommandParser
{
    private const String Dash = "-";
    private const String EmptyString = "";

    private readonly IFile _file;

    internal DefaultCommandParser(IFile file)
    {
        _file = file;
    }

    internal Result<CommandRequest> Parse(String[] args, CommandParsingOptions? options) => InternalParse(args, options);

    #region Private Methods
    private Result<CommandRequest> InternalParse(String[] args, CommandParsingOptions? options)
    {
        if (IsIncorrectCommandFormat(args))
        {
            return Result<CommandRequest>.Fail(CommandFormatError.Create());
        }

        if (IsConfigurationMissing(options))
        {
            return Result<CommandRequest>.Fail(CommandParsingOptionsMissingError.Create());
        }

        var filename = args[^1];
        var filepathResult = ValidateFilepath(options.Directory, filename, options.AllowedFileExtension);
        if (filepathResult.IsFailed)
        {
            return Result<CommandRequest>.Fail(filepathResult.Error);
        }

        if (IsDefaultCommand(args))
        {
            return Result<CommandRequest>.Ok(CommandRequest.Create(options.DefaultCommands, filepathResult.Value));
        }

        var commandKey = args[0];
        var commandRegex = new Regex(options.AllowedCommandPattern);
        if (!commandRegex.IsMatch(commandKey))
        {
            var key = RemoveDash(commandKey);
            return Result<CommandRequest>.Fail(CommandNotRegisteredError.Create(key));
        }

        commandKey = RemoveDash(commandKey);
        return Result<CommandRequest>.Ok(CommandRequest.Create(commandKey, filepathResult.Value));
    }
    private Result<FilePath> ValidateFilepath(String directory, String filename, String allowedExtension)
    {
        var extension = Path.GetExtension(filename);
        if (IsFileExtensionNullOrEmpty(extension))
        {
            return Result<FilePath>.Fail(FileExtensionNotFoundError.Create());
        }

        if (IsFileExtensionNotAllowed(extension, allowedExtension))
        {
            return Result<FilePath>.Fail(FileExtensionNotAllowedError.Create(extension));
        }

        var filepath = Path.Combine(directory, filename);
        if (!_file.Exists(filepath))
        {
            return Result<FilePath>.Fail(FileNotFoundError.Create(filename));
        }

        return Result<FilePath>.Ok(filepath);
    }
    private static Boolean IsConfigurationMissing([NotNullWhen(false)] CommandParsingOptions? options)
        => options is null ||
        options.DefaultCommands is null ||
        options.DefaultCommands.Length == 0 ||
        String.IsNullOrEmpty(options.AllowedCommandPattern) ||
        String.IsNullOrEmpty(options.AllowedFileExtension);
    private static Boolean IsDefaultCommand(String[] args) => args.Length == 1;
    private static Boolean IsFileExtensionNotAllowed(String current, String allowed)
        => !String.Equals(current, allowed, StringComparison.OrdinalIgnoreCase);
    private static Boolean IsFileExtensionNullOrEmpty(String extension) => String.IsNullOrEmpty(extension);
    private static Boolean IsIncorrectCommandFormat([NotNullWhen(false)] String[] args)
        => args is null ||
        args.Length < 1 ||
        args.Length > 2;
    private static String RemoveDash(String commandValue) => commandValue.Replace(Dash, EmptyString);
    #endregion Private Methods
}
