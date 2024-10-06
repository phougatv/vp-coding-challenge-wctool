namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("c")]
internal class ByteCountCommand(IByteCountable byteCountable) : ICommand
{
    public Result<Count> Execute()
    {
        var count = byteCountable.GetCount();

        return Result<Count>.Ok(count);
    }
}
