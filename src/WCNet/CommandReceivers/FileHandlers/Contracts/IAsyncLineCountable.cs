namespace VP.CodingChallenge.WCNet.CommandReceivers.FileHandlers.Contracts;

internal interface IAsyncLineCountable
{
    Task<Int64> GetCountAsync();
}
