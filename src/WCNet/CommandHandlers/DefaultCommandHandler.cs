namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class DefaultCommandHandler
{
	private const String Directory = @".\Files";
	private readonly ICommandResolver _commandResolver;

	public DefaultCommandHandler(ICommandResolver commandResolver)
	{
		_commandResolver = commandResolver;
	}

	public void Handle(String[] args)
	{
		if (args.Length != 2)
		{
			Console.WriteLine("Incorrect command format, -<command> <filename.extension>");
			return;
		}

		Command commandKey = args[0];
		var filename = args[1];
		var filepath = Path.Combine(Directory, filename);
		if (!File.Exists(filepath))
		{
			Console.WriteLine($"File: {filename} not found");
			return;
		}

		var command = _commandResolver.Resolve(commandKey);
		var text = command.Execute(filepath);
		Console.WriteLine(text);
	}
}
