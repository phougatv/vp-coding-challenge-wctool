namespace VP.CodingChallenge.WCNet.CommandHandlers;

public abstract class CommandHandlerBase
{
    protected abstract Result<CommandArgument> PreHandle(String[] args);
    protected abstract Result<Message> Handle(CommandArgument commandArgument);
    protected abstract Result PostHandle(Message message);

    public void Main(String[] args)
    {
        var commandKey = new CommandKey();

        try
        {
            var argumentResult = PreHandle(args);
            if (argumentResult.IsFailed)
            {
                Console.WriteLine(argumentResult.Error);
                return;
            }

            commandKey = argumentResult.Value.CommandKey;
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
            Console.WriteLine($"Error executing command: {commandKey}: {ex.Message}");
        }
    }
}
