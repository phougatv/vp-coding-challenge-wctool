namespace VP.CodingChallenge.WCNet.Sinks;

internal class ConsoleOutput : IOutput
{
    public void Sink(String message) => SinkToConsole(message);
    public void Sink(Int64 count, String filename)
    {
        var message = $"{count} {filename}";
        SinkToConsole(message);
    }

    #region Private Methods
    private static void SinkToConsole(String message) => Console.WriteLine(message);
    #endregion Private Methods
}
