namespace VP.CodingChallenge.WCNet.Sinks;

internal interface IOutput
{
    void Sink(String message);
    void Sink(Int64 count, String filename);
}
