﻿namespace VP.CodingChallenge.WCNet.CommandParsers;

internal class DefaultCommandParser
{
    private const String Dash = "-";
    private const String EmptyString = "";

    public static Result<CommandRequest> Parse(String[] args, ParseOptions? options)
    {
        //if (IsIncorrectCommandFormat(args))
        //{
        //    return Result<CommandRequest>.Fail(CommandFormatError.Create());
        //}

        //if (IsConfigurationMissing(options))
        //{
        //    return Result<CommandRequest>.Fail(ParserOptionsMissingError.Create());
        //}

        //var filename = args[^1];
        //if (IsDefaultCommand(args))
        //{
        //    return ParseToDefaultCommands(options.DefaultCommands, options.Directory, filename, options.AllowedFileExtension);
        //}

        //var command = args[0];
        //return ParseToUserCommand(command, options.AllowedCommandPattern, options.Directory, filename, options.AllowedFileExtension);

        return InternalTestParse(args, options);
    }

    #region Test
    private static Result<CommandRequest> InternalTestParse(String[] args, ParseOptions? options)
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
        var filepathResult = ValidateFilepath(options.Directory, filename, options.AllowedFileExtension);
        if (filepathResult.IsFailed)
        {
            return Result<CommandRequest>.Fail(filepathResult.Error);
        }

        if (IsDefaultCommand(args))
        {
            return Result<CommandRequest>.Ok(CommandRequest.CreateTest(options.DefaultCommands, filepathResult.Value));
        }

        var commandKey = args[0];
        var commandRegex = new Regex(options.AllowedCommandPattern);
        if (!commandRegex.IsMatch(commandKey))
        {
            return Result<CommandRequest>.Fail(CommandNotFoundError.Create(commandKey));
        }

        commandKey = RemoveDash(commandKey);
        return Result<CommandRequest>.Ok(CommandRequest.CreateTest(commandKey, filepathResult.Value));
    }
    #endregion Test

    #region Private Methods
    private static Boolean IsConfigurationMissing([NotNullWhen(false)] ParseOptions? options)
        => options is null ||
        options.DefaultCommands is null ||
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
        CommandKey[] defaultCommands,
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

    private static Result<CommandRequest> ParseToUserCommand(
        String commandValue,
        String allowedCommandPattern,
        String directory,
        String filename,
        String allowedExtension)
    {
        var commandRegex = new Regex(allowedCommandPattern);
        if (!commandRegex.IsMatch(commandValue))
        {
            return Result<CommandRequest>.Fail(CommandNotFoundError.Create(commandValue));
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
