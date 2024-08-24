namespace VP.CodingChallenge.WCTool;

public class Program
{
	private const String Directory = @".\Files";

	static void Main(String[] args)
	{
		if (args.Length != 2)
		{
			Console.WriteLine("Incorrect command format, -<command> <filename.extension>");
			return;
		}

		var command = args[0];
		var filename = args[1];
		var filepath = Path.Combine(Directory, filename);
		if (!Path.Exists(filepath))
		{
			Console.WriteLine($"File: {filename}, not found");
			return;
		}

		if (command == "-c")
		{
			var fileInfo = new FileInfo(filepath);
			Console.WriteLine($"{fileInfo.Length} {filename}");
		}
	}
}
