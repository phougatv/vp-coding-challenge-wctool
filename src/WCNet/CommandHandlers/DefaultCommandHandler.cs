namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class DefaultCommandHandler
{
    private readonly ICommandResolver _commandResolver;
    private readonly ICommandInvoker _invoker;

    public DefaultCommandHandler(ICommandResolver commandResolver, ICommandInvoker invoker)
	{
		_commandResolver = commandResolver;
        _invoker = invoker;
	}

    internal void Main(CommandRequest request)
    {
        var messageResult = Handle(request);
        if (messageResult.IsFailed)
        {
            Console.WriteLine(messageResult.Error);
            Usage();
            return;
        }

        PostHandle(messageResult.Value);
    }

    private Result<Message> Handle(CommandRequest request)
	{
        var command = _commandResolver.ResolveCommand(request);
        _invoker.SetCommand(command);
        
        var countResult = _invoker.InvokeCommand();
        var messageResult = GetMessage(countResult, request.Filepath.Filename);

        return messageResult;
	}

    private static Result<Message> GetMessage(Result<Count> countResult, String filename)
    {
        if (countResult.IsFailed)
        {
            return Result<Message>.Fail(countResult.Error);
        }

        //var builder = new StringBuilder(countResult.Value.Count);
        //foreach (var count in countResult.Value)
        //{
        //    builder.Append(count);
        //    builder.Append(' ');
        //}

        //builder.Append(filename);
        //return Result<Message>.Ok(builder);

        var textToDisplay = $"{countResult.Value} {filename}";
        return Result<Message>.Ok(textToDisplay);
    }

    private static Result PostHandle(Message message)
    {
        Console.WriteLine(message);
        return Result.Ok();
    }

    private static void Usage()
    {
        Console.WriteLine("Usage: wc.NET [OPTIONS] [FILE]");
        Console.WriteLine("Counts lines, characters, words, and bytes in the specified FILE.");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  -c,         Print the byte counts.");
        Console.WriteLine("  -m,         Print the character counts.");
        Console.WriteLine("  -l,         Print the line counts.");
        Console.WriteLine("  -w,         Print the word counts.");
        Console.WriteLine("              Display this help and exit.");
        Console.WriteLine();
        Console.WriteLine("Example:");
        Console.WriteLine("  wc.NET -lwm filename.txt");
        Console.WriteLine("  wc.NET --lines --words --chars filename.txt");
    }
}
