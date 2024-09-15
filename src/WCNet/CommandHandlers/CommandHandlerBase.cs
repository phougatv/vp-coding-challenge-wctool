namespace VP.CodingChallenge.WCNet.CommandHandlers;

public abstract class CommandHandlerBase
{
    //protected abstract Result<CommandArgument> PreHandle(String[] args);
    protected abstract Result<Message> Handle(CommandArgument commandArgument);
    protected abstract Result PostHandle(Message message);

    public void Main(CommandArgument commandArgument)
    {
        CommandKey[] keys = [];

        try
        {
            //var argumentResult = PreHandle(args);
            //if (argumentResult.IsFailed)
            //{
            //    Console.WriteLine(argumentResult.Error);
            //    return;
            //}

            //keys = argumentResult.Value.CommandKeys;
            //var messageResult = Handle(argumentResult.Value);
            //if (messageResult.IsFailed)
            //{
            //    Console.WriteLine(messageResult.Error);
            //    return;
            //}

            //PostHandle(messageResult.Value);

            var messageResult = Handle(commandArgument);
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
    }
}
