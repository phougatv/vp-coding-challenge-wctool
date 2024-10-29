namespace VP.CodingChallenge.WCNet.CommandReceivers.FileHandlers.Contracts;

internal interface IAsyncCharacterCountable
{
    Task<Int64> GetCountAsync();
}
