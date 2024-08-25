namespace VP.CodingChallenge.WCNet.Commands.Concrete;

internal class ByteCountCommand : ICommand
{
	public String Execute(String filepath)
	{
		var fileInfo = new FileInfo(filepath);
		var filename = Path.GetFileName(filepath);
		return $"{fileInfo.Length} {filename}";
	}
}
