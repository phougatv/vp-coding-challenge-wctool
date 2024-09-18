namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("l")]
internal class LineCountCommand : ICommand
{
<<<<<<< HEAD
    private readonly Filepath _filepath;
    private readonly IOutput _output;

    public LineCountCommand(Filepath filepath, IOutput output)
    {
        _filepath = filepath;
        _output = output;
    }

    public void Execute()
	{
		var fileInfo = new FileInfo(_filepath);
		var lineCount = 0L;
=======
	public Result<UInt64> Execute(String filepath)
	{
		var fileInfo = new FileInfo(filepath);
		var lineCount = 0UL;
>>>>>>> master
		using var streamReader = new StreamReader(fileInfo.FullName);
		while (streamReader.ReadLine() != null)
		{
			lineCount++;
		}

<<<<<<< HEAD
        _output.Sink(lineCount, fileInfo.Name);
    }
=======
		return Result<UInt64>.Ok(lineCount);
	}
>>>>>>> master
}
