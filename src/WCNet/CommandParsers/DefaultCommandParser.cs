namespace VP.CodingChallenge.WCNet.CommandParsers;
using System.Diagnostics.CodeAnalysis;

internal class DefaultCommandParser
{
    public static Result<CommandRequest> Parse(String[] args, ParserOptions? options)
    {
        if (HasUnexpectedNumberOfItems(args))
        {
            return Result<CommandRequest>.Fail(CommandFormatError.Create());
        }

        if (IsConfigurationMissing(options))
        {
            //TODO: add custom error along with the message
            return Result<CommandRequest>.Fail("Missing configuration");
        }

        //if (HasSingleItem(args))
        //{
        //    return ParseToDefaultCommands(args, options);
        //}

        return ParseToSpecifiedCommands(args, options);
    }

    #region Private Methods
    private static Boolean IsConfigurationMissing([NotNullWhen(false)] ParserOptions? options)
        => options is null ||
        options.DefaultCommands.Length == 0 ||
        String.IsNullOrEmpty(options.CommandExpression) ||
        String.IsNullOrEmpty(options.AllowedFileExtension);
    //private static Result<CommandArgument> ParseToDefaultCommands(String[] args, ParserOptions options)
    //{
    //    var filename = args[^1];
    //    var fileExtension = Path.GetExtension(filename);
    //    var filepath = Path.Combine(options.Directory, filename);
    //    if (!IsFileExtensionAllowed(fileExtension, options.AllowedFileExtension))
    //    {
    //        return Result<CommandArgument>.Fail(FileExtensionNotAllowedError.Create(Path.GetExtension(filename)));
    //    }

    //    if (FileDoesNotExists(filepath))
    //    {
    //        return Result<CommandArgument>.Fail(FileNotFoundError.Create(filename));
    //    }

    //    return Result<CommandArgument>.Ok(CommandArgument.Create(options.DefaultCommands, filepath));
    //}

    private static Result<CommandRequest> ParseToSpecifiedCommands(String[] args, ParserOptions options)
    {
        var commandRegex = new Regex(options.CommandExpression);
        var commandValue = args[0];
        if (!commandRegex.IsMatch(commandValue))
        {
            return Result<CommandRequest>.Fail(CommandNotFoundError.Create(commandValue));
        }

        var filename = args[^1];
        var fileExtension = Path.GetExtension(filename);
        if (!IsFileExtensionAllowed(fileExtension, options.AllowedFileExtension))
        {
            return Result<CommandRequest>.Fail(FileExtensionNotAllowedError.Create(Path.GetExtension(filename)));
        }

        var filepath = Path.Combine(options.Directory, filename);
        if (FileDoesNotExists(filepath))
        {
            return Result<CommandRequest>.Fail(FileNotFoundError.Create(filename));
        }

        var keys = new Command(commandValue.Replace("-", ""));
        return Result<CommandRequest>.Ok(CommandRequest.Create(keys, filepath));
    }

    private static Boolean HasUnexpectedNumberOfItems(String[] args)
        => args.Length < 1 || args.Length > 2;
    private static Boolean HasSingleItem(String[] args)
        => args.Length == 1;
    private static Boolean FileDoesNotExists(String filepath)
        => !File.Exists(filepath);
    private static Boolean IsFileExtensionAllowed(String fileExtension, String allowedExtension)
        => String.Equals(fileExtension, allowedExtension, StringComparison.OrdinalIgnoreCase);
    #endregion Private Methods
}
