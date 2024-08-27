using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VP.CodingChallenge.WCNet.Test")]
namespace VP.CodingChallenge.WCNet.Commands;

internal interface ICommand
{
	String Execute(String filepath);
}
