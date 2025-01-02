namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.CountTests;

public class GetHashCode
{
	[Fact]
	public void ReturnsSameValue_WhenSameInstanceIsCalledMultipleTimes()
	{
		//Arrange
		var count = new Count(Int64.MaxValue);
		var expected = count.GetHashCode();

		//Act
		var actual = count.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsSameValue_WhenTwoInstancesAreEqual()
	{
		//Arrange
		var count1 = new Count(Int64.MaxValue);
		var count2 = new Count(Int64.MaxValue);
		var expected = count1.GetHashCode();

		//Act
		var actual = count2.GetHashCode();

		//Assert
		actual.Should().Be(expected);
		count1.Should().Be(count2);
	}

	[Fact]
	public void ReturnsSameValue_WhenTwoInstancesAreDefault()
	{
		//Arrange
		var count1 = default(Count);
		var count2 = default(Count);
		var expected = count1.GetHashCode();

		//Act
		var actual = count2.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsDifferentValue_WhenOneOfTheInstancesIsDefault()
	{
		//Arrange
		var count1 = new Count(Int64.MaxValue);
		var count2 = default(Count);
		var expected = count1.GetHashCode();

		//Act
		var actual = count2.GetHashCode();

		//Assert
		actual.Should().NotBe(expected);
	}

	[Fact]
	public void ReturnsDifferentValue_WhenTwoInstancesAreNotEqual()
	{
		//Arrange
		var count1 = new Count(Int64.MaxValue);
		var count2 = new Count(0L);
		var expected = count1.GetHashCode();

		//Act
		var actual = count2.GetHashCode();

		//Assert
		actual.Should().NotBe(expected);
		count1.Should().NotBe(count2);
	}
}
