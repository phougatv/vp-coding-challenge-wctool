namespace VP.CodingChallenge.WCNet.Benchmark;

using BenchmarkDotNet.Running;

internal class Program
{
	static void Main(String[] args)
	{
		var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
	}
}