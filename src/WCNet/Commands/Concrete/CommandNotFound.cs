namespace VP.CodingChallenge.WCNet.Commands.Concrete;

internal class CommandNotFound : ICommand
{
<<<<<<< HEAD
    private readonly IOutput _output;

    public CommandNotFound(IOutput output)
    {
        _output = output;
    }

	public void Execute()
        => _output.Sink(CommandNotFoundError.Create().ToString());
=======
	public Result<UInt64> Execute(String filepath)
        => Result<UInt64>.Fail(CommandNotFoundError.Create());
>>>>>>> master
}
