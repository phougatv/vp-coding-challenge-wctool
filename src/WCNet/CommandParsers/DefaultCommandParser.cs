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
		if (args.Length != 2)
		{
			return Result<CommandArgument>.Fail(CommandFormatError.Create());
		}

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

		return Result<CommandArgument>.Ok(CommandArgument.Create(commandValue, filepath));
	}

	#region Private Methods
	private static Boolean FileDoesNotExists(String filepath)
		=> !File.Exists(filepath);
	private Boolean IsFileExtensionAllowed(String filename)
		=> _options.AllowedFileExtension.Equals(Path.GetExtension(filename));
	#endregion Private Methods
}
