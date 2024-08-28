namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class FileNotFoundError : Error
{
	private FileNotFoundError(String message)
		: base(message)
	{

	}

	internal static FileNotFoundError Create(String filename)
		=> new FileNotFoundError($"File: {filename}, not found.");
}
