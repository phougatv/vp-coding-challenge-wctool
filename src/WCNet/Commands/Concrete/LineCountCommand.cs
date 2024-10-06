//namespace VP.CodingChallenge.WCNet.Commands.Concrete;

//[CommandKey("l")]
//internal class LineCountCommand : ICommand
//{
//    private readonly Filepath _filepath;
//    private readonly IOutput _output;

//    public LineCountCommand(Filepath filepath, IOutput output)
//    {
//        _filepath = filepath;
//        _output = output;
//    }

//    public void Execute()
//	{
//		var fileInfo = new FileInfo(_filepath);
//		var lineCount = 0L;
//		using var streamReader = new StreamReader(fileInfo.FullName);
//		while (streamReader.ReadLine() != null)
//		{
//			lineCount++;
//		}

//        _output.Sink(lineCount, fileInfo.Name);
//    }
//}
