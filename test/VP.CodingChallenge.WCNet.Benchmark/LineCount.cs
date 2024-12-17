namespace VP.CodingChallenge.WCNet.Benchmark;

using BenchmarkDotNet.Attributes;
using System.Buffers;
using System.IO.Pipelines;

[MemoryDiagnoser]
public class LineCount
{
	[Benchmark(Baseline = true)]
	public Int64 StreamReader()
	{
		var lineCount = 0L;
		using var streamReader = new StreamReader("./test-239MB.txt");
		while (streamReader.ReadLine() != null)
		{
			lineCount++;
		}

		return lineCount;
	}

	//[Benchmark]
	//public Int64 FileReadAllLines()
	//{
	//	var lines = File.ReadAllLines("./test-239MB.txt");
	//	return lines.Length;
	//}

	[Benchmark]
	public async Task<Int64> Pipeline()
	{
		var lineCount = 0L;
		var bufferSize64KB = 64 * 1024;
		using var fileStream = new FileStream("./test-239MB.txt", FileMode.Open, FileAccess.Read);
		var pipeReader = PipeReader.Create(fileStream, new StreamPipeReaderOptions(bufferSize: bufferSize64KB));
		while (true)
		{
			var readResult = await pipeReader.ReadAsync();
			//pipeReader.TryRead(out var readResult);
			var buffer = readResult.Buffer;
			var position = (SequencePosition?)null;
			do
			{
				//Look for a EOL in the buffer
				position = buffer.PositionOf((Byte)'\n');

				if (position != null)
				{
					lineCount++;
					buffer = buffer.Slice(buffer.GetPosition(1, position.Value));
				}
			} while (position != null);

			//Tell the PipeReader how much of the buffer has been consumed
			pipeReader.AdvanceTo(buffer.Start, buffer.End);

			//Stop reading if there is no more data coming
			if (readResult.IsCompleted)
			{
				break;
			}
		}

		await pipeReader.CompleteAsync();
		//pipeReader.Complete();
		return lineCount;
	}
}
