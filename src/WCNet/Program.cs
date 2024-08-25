namespace VP.CodingChallenge.WCNet;

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

		var fileInfo = new FileInfo(filepath);
		if (command == "-c")
		{
			Console.WriteLine($"{fileInfo.Length} {filename}");
			return;
		}

		if (command == "-l")
		{
			var lineCount = 0UL;
			using var streamReader = new StreamReader(fileInfo.FullName);
			while (streamReader.ReadLine() != null)
			{
				lineCount++;
			}

			Console.WriteLine($"{lineCount} {filename}");
		}
	}
}
