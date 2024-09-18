namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("c")]
internal class ByteCountCommand : ICommand
{
<<<<<<< HEAD
    private readonly Filepath _filepath;
    private readonly IOutput _output;

    public ByteCountCommand(Filepath filepath, IOutput output)
    {
        _filepath = filepath;
        _output = output;
    }

    public void Execute()
    {
        var fileInfo = new FileInfo(_filepath);
        _output.Sink(fileInfo.Length, fileInfo.Name);
=======
    public Result<UInt64> Execute(String filepath)
    {
        var fileInfo = new FileInfo(filepath);
        return Result<UInt64>.Ok((UInt64)fileInfo.Length);
>>>>>>> master
    }
}
