namespace VP.CodingChallenge.WCNet.CommandHandlers;

public abstract class CommandHandlerBase
{
<<<<<<< HEAD
    protected abstract Result<Message> Handle(CommandRequest commandRequest);
    protected abstract Result PostHandle(Message message);

    public void Main(CommandRequest commandRequest)
    {
        var messageResult = Handle(commandRequest);
        if (messageResult.IsFailed)
        {
            Console.WriteLine(messageResult.Error);
            Usage();
            return;
        }

        PostHandle(messageResult.Value);
    }

    private void Usage()
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
=======
    protected abstract Result<CommandArgument> PreHandle(String[] args);
    protected abstract Result<Message> Handle(CommandArgument commandArgument);
    protected abstract Result PostHandle(Message message);

    public void Main(String[] args)
    {
        CommandKey[] keys = [];

        try
        {
            var argumentResult = PreHandle(args);
            if (argumentResult.IsFailed)
            {
                Console.WriteLine(argumentResult.Error);
                return;
            }

            keys = argumentResult.Value.CommandKeys;
            var messageResult = Handle(argumentResult.Value);
            if (messageResult.IsFailed)
            {
                Console.WriteLine(messageResult.Error);
                return;
            }

            PostHandle(messageResult.Value);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing command: {String.Join(',', keys)}: {ex.Message}");
        }
>>>>>>> master
    }
}
