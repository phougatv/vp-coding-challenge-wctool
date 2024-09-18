namespace VP.CodingChallenge.WCNet.CommandExceptions;

public class CommandNotSetException : Exception
{
    public CommandNotSetException()
        : base("Failed to invoke command, use 'SetCommand' method to set it, before invoking.")
    {
    }

    public CommandNotSetException(String message)
        : base(message)
    {
    }

    public CommandNotSetException(String message, Exception innerException)
        : base(message, innerException)
    {
    }
}
