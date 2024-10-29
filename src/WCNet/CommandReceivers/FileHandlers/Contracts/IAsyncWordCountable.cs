namespace VP.CodingChallenge.WCNet.CommandReceivers.FileHandlers.Contracts;

internal interface IAsyncWordCountable
{
    Task<Int64> GetCountAsync();
}
