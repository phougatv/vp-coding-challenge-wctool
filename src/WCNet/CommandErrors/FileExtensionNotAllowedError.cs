namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class FileExtensionNotAllowedError : Error
{
	private FileExtensionNotAllowedError(String message)
		: base(message)
	{

	}

	internal static FileExtensionNotAllowedError Create(String fileExtension)
		=> new FileExtensionNotAllowedError($"File extension: .{fileExtension}, is not allowed.");
}
