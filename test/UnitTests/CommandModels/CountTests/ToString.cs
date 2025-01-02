namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.CountTests;

public class ToString
{
	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCountIsPositive()
	{
		//Arrange
		var count = new Count(101);
		var expected = "Count=[Value: \"101\"]";

		//Act
		var actual = count.ToString();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCountIsZero()
	{
		//Arrange
		var count = new Count(0);
		var expected = "Count=[Value: \"0\"]";

		//Act
		var actual = count.ToString();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCountIsNegative()
	{
		//Arrange
		var count = new Count(-101);
		var expected = "Count=[Value: \"-101\"]";

		//Act
		var actual = count.ToString();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCountIsDefault()
	{
		//Arrange
		var count = default(Count);
		var expected = "Count=[Value: \"0\"]";

		//Act
		var actual = count.ToString();

		//Assert
		actual.Should().Be(expected);
	}
}
