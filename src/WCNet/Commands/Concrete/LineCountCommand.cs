namespace VP.CodingChallenge.WCNet.Commands.Concrete;

using VP.CodingChallenge.WCNet.Attributes;

[CommandKey("-l")]
internal class LineCountCommand : ICommand
{
	public String Execute(String filepath)
	{
		var fileInfo = new FileInfo(filepath);
		var lineCount = 0UL;
		using var streamReader = new StreamReader(fileInfo.FullName);
		while (streamReader.ReadLine() != null)
		{
			lineCount++;
		}

		var filename = Path.GetFileName(filepath);
		return $"{lineCount} {filename}";
	}
}
