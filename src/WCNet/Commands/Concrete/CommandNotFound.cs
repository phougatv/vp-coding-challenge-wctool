namespace VP.CodingChallenge.WCNet.Commands.Concrete;

internal class CommandNotFound : ICommand
{
	public String Execute(String filepath) => $"Command not found";
}
