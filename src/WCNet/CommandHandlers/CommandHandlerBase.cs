namespace VP.CodingChallenge.WCNet.CommandHandlers;

public abstract class CommandHandlerBase
{
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

    internal static void Usage()
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
