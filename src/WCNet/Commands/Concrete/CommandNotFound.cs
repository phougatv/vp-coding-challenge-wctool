namespace VP.CodingChallenge.WCNet.Commands.Concrete;

internal class CommandNotFound : ICommand
{
    private readonly IOutput _output;

    public CommandNotFound(IOutput output)
    {
        _output = output;
    }

	public void Execute()
        => _output.Sink(CommandNotFoundError.Create().ToString());
}
