[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace VP.CodingChallenge.WCNet.CommandReceivers.FileHandlers.Contracts;

internal interface IByteCountable
{
    Int64 GetCount();
}
