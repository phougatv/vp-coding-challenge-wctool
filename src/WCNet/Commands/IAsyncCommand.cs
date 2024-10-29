[assembly: InternalsVisibleTo("VP.CodingChallenge.WCNet.Test")]
namespace VP.CodingChallenge.WCNet.Commands;

internal interface IAsyncCommand
{
    Task<Result<Count>> ExecuteAsync();
}
