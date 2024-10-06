[assembly: InternalsVisibleTo("VP.CodingChallenge.WCNet.Test")]
namespace VP.CodingChallenge.WCNet.Commands;

internal interface ICommand
{
    Result<Count> Execute();
}
