namespace VP.CodingChallenge.WCNet.CommandReceivers.FileHandlers;

internal class Document(Filepath filepath) : IByteCountable, ICharacterCountable, ILineCountable, IWordCountable
{
    private readonly Filepath _filepath = Path.GetFullPath(filepath);

    Int64 IByteCountable.GetCount()
    {
        var fileInfo = new FileInfo(_filepath);
        return fileInfo.Length;
    }

    Int64 ICharacterCountable.GetCount()
    {
        var characterCount = 0L;
        using var streamReader = new StreamReader(_filepath);
        var line = streamReader.ReadLine();
        while (line != null)
        {
            characterCount += line.Length;
            line = streamReader.ReadLine();
        }

        return characterCount;
    }

    Int64 ILineCountable.GetCount()
    {
        var lineCount = 0L;
        using var streamReader = new StreamReader(_filepath);
        while (streamReader.ReadLine() != null)
        {
            lineCount++;
        }

        return lineCount;
    }

    Int64 IWordCountable.GetCount()
    {
        var content = File.ReadAllText(_filepath);
        var pattern = @"\b\w+\b";
        var matchCollection = Regex.Matches(content, pattern);

        return matchCollection.Count;
    }
}
