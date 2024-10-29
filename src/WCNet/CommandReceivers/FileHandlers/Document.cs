namespace VP.CodingChallenge.WCNet.CommandReceivers.FileHandlers;

internal class Document(Filepath filepath) : IByteCountable, IAsyncCharacterCountable, IAsyncLineCountable, IAsyncWordCountable
{
    private readonly Filepath _filepath = Path.GetFullPath(filepath);

    Int64 IByteCountable.GetCount()
    {
        var fileInfo = new FileInfo(_filepath);
        return fileInfo.Length;
    }

    async Task<Int64> IAsyncCharacterCountable.GetCountAsync()
    {
        var characterCount = 0L;
        var bufferSize64KB = 64 * 1024;
        using var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        var pipeReader = PipeReader.Create(fileStream, new StreamPipeReaderOptions(bufferSize: bufferSize64KB));
        while (true)
        {
            var readResult = await pipeReader.ReadAsync();
            var buffer = readResult.Buffer;
            characterCount += GetCharacterCountInBuffer(buffer);
            pipeReader.AdvanceTo(buffer.End);
            if (readResult.IsCompleted)
            {
                break;
            }
        }

        await pipeReader.CompleteAsync();

        return characterCount;
    }

    async Task<Int64> IAsyncLineCountable.GetCountAsync()
    {
        var lineCount = 0L;
        var bufferSize64KB = 64 * 1024;
        using var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        var pipeReader = PipeReader.Create(fileStream, new StreamPipeReaderOptions(bufferSize: bufferSize64KB));
        while (true)
        {
            var readResult = await pipeReader.ReadAsync();
            var buffer = readResult.Buffer;
            SequencePosition? endOfLinePosition;
            do
            {
                //Look for EOL in the buffer
                endOfLinePosition = buffer.PositionOf((Byte)'\n');

                if (endOfLinePosition != null)
                {
                    lineCount++;
                    buffer = buffer.Slice(buffer.GetPosition(1, endOfLinePosition.Value));
                }
            }
            while (endOfLinePosition != null);

            //Tell the PipeReader how much of the buffer has been consumed
            pipeReader.AdvanceTo(buffer.Start, buffer.End);

            //Stop reading if there is no more data coming
            if (readResult.IsCompleted)
            {
                break;
            }
        }

        await pipeReader.CompleteAsync();

        return lineCount;
    }

    async Task<Int64> IAsyncWordCountable.GetCountAsync()
    {
        var wordCount = 0L;
        var bufferSize64KB = 64 * 1024;
        using var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        var pipeReader = PipeReader.Create(fileStream, new StreamPipeReaderOptions(bufferSize: bufferSize64KB));
        while (true)
        {
            var readResult = await pipeReader.ReadAsync();
            var buffer = readResult.Buffer;
            wordCount += GetWordCountInBuffer(buffer);
            pipeReader.AdvanceTo(buffer.End);

            if (readResult.IsCompleted)
            {
                break;
            }
        }

        await pipeReader.CompleteAsync();

        return wordCount;
    }

    #region Private Methods
    private static Int64 GetCharacterCountInBuffer(ReadOnlySequence<Byte> buffer)
    {
        var characterCount = 0L;
        foreach (var segment in buffer)
        {
            characterCount += Encoding.Default.GetCharCount(segment.Span);
        }

        return characterCount;
    }
    private static Int64 GetLineCountInBuffer(ReadOnlySequence<Byte> buffer)
    {
        var lineCount = 0L;
        SequencePosition? endOfLinePosition;
        do
        {
            endOfLinePosition = buffer.PositionOf((Byte)'\n');      //Look for EOL in the buffer

            if (endOfLinePosition != null)
            {
                lineCount++;
                buffer = buffer.Slice(buffer.GetPosition(1, endOfLinePosition.Value));
            }
        }
        while (endOfLinePosition != null);

        return lineCount;
    }
    private static Int64 GetWordCountInBuffer(ReadOnlySequence<Byte> buffer)
    {
        var wordCount = 0L;
        var inWord = false;
        foreach (var segment in buffer)
        {
            var span = segment.Span;
            foreach (var byteValue in span)
            {
                if (byteValue is ((Byte)' ') or ((Byte)'\n') or ((Byte)'\r') or ((Byte)'\t'))
                {
                    if (inWord)
                    {
                        wordCount++;
                        inWord = false;
                    }
                }
                //else if (Char.IsPunctuation((Char)byteValue) && !inWord)
                //{
                //    continue;
                //}
                else
                {
                    inWord = true;
                }
            }
        }

        if (inWord)
        {
            wordCount++;    //Count the last word if it wasn't followed by a whitespace
        }

        return wordCount;
    }
    #endregion Private Methods
}
