namespace VP.CodingChallenge.WCNet.Test.UnitTests;

using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Text;

public class Test
{
    [Fact]
    public async Task AssertLineCount()
    {
        var filepath = "C:\\source\\vp-coding-challenge-wctool\\test\\WCNet\\bin\\Debug\\net8.0\\test.txt";
        var lineCount = 0L;
        var bufferSize64KB = 64 * 1024;
        using var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        var pipeReader = PipeReader.Create(fileStream, new StreamPipeReaderOptions(bufferSize: bufferSize64KB));
        while (true)
        {
            var readResult = await pipeReader.ReadAsync();
            var buffer = readResult.Buffer;
            lineCount += GetLineCountInBuffer(buffer);

            //Tell the PipeReader how much of the buffer has been consumed
            pipeReader.AdvanceTo(buffer.Start, buffer.End);

            //Stop reading if there is no more data coming
            if (readResult.IsCompleted)
            {
                break;
            }
        }

        await pipeReader.CompleteAsync();

        lineCount.Should().Be(7145);
    }

    [Fact]
    public async Task AssertCharacterCount()
    {
        var filepath = "C:\\source\\vp-coding-challenge-wctool\\test\\WCNet\\bin\\Debug\\net8.0\\test.txt";
        var characterCount = 0L;
        if (Encoding.Default.IsSingleByte)
        {
            characterCount = GetByteCount(filepath);
        }
        else
        {
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
        }

        characterCount.Should().Be(339292);
    }

    [Fact]
    public async Task AssertWordCount()
    {
        var filepath = "C:\\source\\vp-coding-challenge-wctool\\test\\WCNet\\bin\\Debug\\net8.0\\test.txt";
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

        wordCount.Should().Be(58164);
    }

    private Int64 GetByteCount(String filepath)
    {
        var fileInfo = new FileInfo(filepath);
        return fileInfo.Length;
    }

    private static Int64 GetCharacterCountInBuffer(ReadOnlySequence<Byte> buffer)
    {
        var characterCount = 0L;
        foreach (var segment in buffer)
        {
            characterCount += Encoding.Default.GetCharCount(segment.Span);
        }

        return characterCount;
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

    private static Int64 GetLineCountInBuffer(ReadOnlySequence<Byte> buffer)
    {
        var lineCount = 0L;
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

        return lineCount;
    }
}
