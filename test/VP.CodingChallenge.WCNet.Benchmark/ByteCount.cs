namespace VP.CodingChallenge.WCNet.Benchmark;

using BenchmarkDotNet.Attributes;
using System.Buffers;
using System.IO.Pipelines;
using System.Runtime.CompilerServices;

[MemoryDiagnoser]
public class ByteCount
{
	//[Benchmark(Baseline = true)]
	//public Int64 FileInfo()
	//{
	//	var fileInfo = new FileInfo("./test-60MB.txt");
	//	return fileInfo.Length;
	//}

	//[Benchmark]
	//public Int64 FileStream()
	//{
	//	var fileStream = new FileStream("./test-60MB.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
	//	return fileStream.Length;
	//}

	//[Benchmark]
	//public async Task<Int64> Pipeline()
	//{
	//	var byteCount = 0L;
	//	var bufferSize64KB = 64 * 1024;
	//	using var fileStream = new FileStream("./test-60MB.txt", FileMode.Open, FileAccess.Read);
	//	var pipeReader = PipeReader.Create(fileStream, new StreamPipeReaderOptions(bufferSize: bufferSize64KB));
	//	while (true)
	//	{
	//		var readResult = await pipeReader.ReadAsync();
	//		byteCount += readResult.Buffer.Length;
	//		pipeReader.AdvanceTo(readResult.Buffer.End);
	//		if (readResult.IsCompleted)
	//		{
	//			break;
	//		}
	//	}

	//	await pipeReader.CompleteAsync();

	//	return byteCount;
	//}

	private async Task<Int64> GetByteCountAsync(String filepath)
	{
		var bufferSize = 64 * 1024;
		using var fileStream = new FileStream(filepath, FileMode.Open);
		var pipeReader = PipeReader.Create(fileStream, new StreamPipeReaderOptions(bufferSize: bufferSize));
		var byteCount = 0L;
		while (true)
		{
			var readResult = await pipeReader.ReadAsync();
			var bufferLength = GetBufferLength(pipeReader, readResult);
			byteCount += bufferLength;
			if (readResult.IsCompleted)
			{
				break;
			}
		}

		await pipeReader.CompleteAsync();
		return byteCount;

		//var options = new PipeOptions(pauseWriterThreshold: 52428800, resumeWriterThreshold: 31457280);
		//var pipe = new Pipe(options);
		//var writing = await FillPipeAsync(filepath, pipe.Writer);
		//var reading = ReadPipeAsync(pipe.Reader);

		//await Task.WhenAll(writing, reading);

		//return writing;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private Int64 GetBufferLength(PipeReader reader, ReadResult readResult)
	{
		var sequenceReader = new SequenceReader<Byte>(readResult.Buffer);
		reader.AdvanceTo(sequenceReader.Position, readResult.Buffer.End);

		return sequenceReader.Length;
	}

	private async Task<Int64> FillPipeAsync(String filepath, PipeWriter writer)
	{
		var bytesCount = 0L;
		var minBufferSize = 209715200;
		using var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read, minBufferSize, FileOptions.Asynchronous);
		while (true)
		{
			//Allocate at least 1 block of memory (4096 bytes) to the PipeWriter
			var memory = writer.GetMemory(minBufferSize);
			try
			{
				var bytesRead = await fileStream.ReadAsync(memory);
				if (bytesRead == 0)
				{
					break;
				}

				bytesCount += bytesRead;

				//Tell the PipeWriter how much was read from the FileStream
				writer.Advance(bytesRead);
			}
			catch (Exception ex)
			{
				writer.Complete(ex);
				break;
			}

			//Make the data available to the PipeReader
			var flushResult = await writer.FlushAsync();
			if (flushResult.IsCompleted)
			{
				break;
			}
		}

		//By calling Complete, we are telling the PipeReader that there is no more data coming.
		await writer.CompleteAsync();

		return bytesCount;
	}

	private async Task<Int32> ReadPipeAsync(PipeReader reader)
	{
		var byteCount = 0;
		while (true)
		{
			var readResult = await reader.ReadAsync();
			var buffer = readResult.Buffer;
			try
			{
				//Stop reading if there is no more data coming.
				if (readResult.IsCompleted)
				{
					break;
				}

				foreach (var memory in buffer)
				{
					byteCount += memory.Length;
				}
			}
			finally
			{
				//Tell the PipeReader how much of the buffer we have consumed
				reader.AdvanceTo(buffer.Start, buffer.End);
			}
		}

		await reader.CompleteAsync();
		return byteCount;
	}
}
