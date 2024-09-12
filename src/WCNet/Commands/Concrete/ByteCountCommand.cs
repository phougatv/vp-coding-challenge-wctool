namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("c")]
internal class ByteCountCommand : ICommand
{
    public Result<UInt64> Execute(String filepath)
    {
        var fileInfo = new FileInfo(filepath);
        return Result<UInt64>.Ok((UInt64)fileInfo.Length);
    }
}
