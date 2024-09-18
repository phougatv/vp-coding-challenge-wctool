[assembly: InternalsVisibleTo("VP.CodingChallenge.WCNet.Test")]
namespace VP.CodingChallenge.WCNet.Commands;

internal interface ICommand
{
<<<<<<< HEAD
	void Execute();
=======
	Result<UInt64> Execute(String filepath);
>>>>>>> master
}
