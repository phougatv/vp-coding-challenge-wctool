namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("c")]
internal class ByteCountCommand : ICommand
{
    private readonly String _filepath;

    public ByteCountCommand(String filepath)
    {
        _filepath = filepath;
    }

    public Result<UInt64> Execute()
    {
        var fileInfo = new FileInfo(_filepath);
        return Result<UInt64>.Ok((UInt64)fileInfo.Length);
    }
}
