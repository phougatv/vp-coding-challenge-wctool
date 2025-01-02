namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.CountTests;

public class CastingOperators
{
	[Theory]
	[InlineData(0)]
	[InlineData(Int64.MinValue)]
	[InlineData(Int64.MaxValue)]
	public void Successfully_ConvertsInt64ToCount(Int64 expected)
	{
		//Arrange
		Count count = expected;

		//Act
		var actual = count.Value;

		//Assert
		actual.Should().Be(expected);
	}

	[Theory]
	[InlineData(0)]
	[InlineData(Int32.MinValue)]
	[InlineData(Int32.MaxValue)]
	public void Successfully_ConvertsInt32ToCount(Int32 expected)
	{
		//Arrange
		Count count = expected;

		//Act
		var actual = count.Value;

		//Assert
		actual.Should().Be(expected);
	}

	[Theory]
	[InlineData(0)]
	[InlineData(Int16.MinValue)]
	[InlineData(Int16.MaxValue)]
	public void Successfully_ConvertsInt16ToCount(Int16 expected)
	{
		//Arrange
		Count count = expected;

		//Act
		var actual = count.Value;

		//Assert
		actual.Should().Be(expected);
	}

	[Theory]
	[InlineData(0)]
	[InlineData(Byte.MinValue)]
	[InlineData(Byte.MaxValue)]
	public void Successfully_ConvertsByteToCount(Byte expected)
	{
		//Arrange
		Count count = expected;

		//Act
		var actual = count.Value;

		//Assert
		actual.Should().Be(expected);
	}

	[Theory]
	[InlineData(0)]
	[InlineData(Int64.MinValue)]
	[InlineData(Int64.MaxValue)]
	public void Successfully_ConvertsCountToInt64(Int64 int64)
	{
		//Arrange
		var count = new Count(int64);
		var expected = count.Value;

		//Act
		Int64 actual = count;

		//Assert
		actual.Should().Be(expected);
	}
}
