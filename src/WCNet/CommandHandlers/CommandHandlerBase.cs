namespace VP.CodingChallenge.WCNet.CommandHandlers;

public abstract class CommandHandlerBase
{
    internal abstract Result<CommandArgument> PreHandle(String[] args);
    internal abstract Result<Message> Handle(CommandArgument commandArgument);
    internal abstract Result PostHandle(Message message);

    public void Main(String[] args)
    {
        var argumentResult = PreHandle(args);
        if (argumentResult.IsFailed)
        {
            //Write to console why it failed
        }

        var messageResult = Handle(argumentResult.Value);
        if (messageResult.IsFailed)
        {
            //Write to console why it failed
        }

        PostHandle(messageResult.Value);
    }
}
