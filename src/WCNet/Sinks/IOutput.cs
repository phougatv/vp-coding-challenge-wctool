namespace VP.CodingChallenge.WCNet.Sinks;

public interface IOutput
{
    void Sink(String message);
    void Sink(Int64 count, String filename);
}
