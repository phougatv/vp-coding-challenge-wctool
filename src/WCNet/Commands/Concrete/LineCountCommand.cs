namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("l")]
internal class LineCountCommand : ICommand
{
    private readonly String _filepath;

    public LineCountCommand(String filepath)
    {
        _filepath = filepath;
    }

    public Result<UInt64> Execute()
	{
		var fileInfo = new FileInfo(_filepath);
		var lineCount = 0UL;
		using var streamReader = new StreamReader(fileInfo.FullName);
		while (streamReader.ReadLine() != null)
		{
			lineCount++;
		}

		return Result<UInt64>.Ok(lineCount);
	}
}
