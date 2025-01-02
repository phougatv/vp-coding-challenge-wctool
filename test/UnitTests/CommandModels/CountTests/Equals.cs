namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.CountTests;

public class Equals
{
	#region Equals(Count)
	[Fact]
	public void ReturnsFalse_WhenNotEqualAndOtherIsDefaultCount()
	{
		//Arrange
		var current = new Count(Int64.MaxValue);
		var other = default(Count);

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenNotEqualAndCurrentIsDefaultCount()
	{
		//Arrange
		var current = default(Count);
		var other = new Count(Int64.MaxValue);

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenNotEqual()
	{
		//Arrange
		var current = new Count(Int64.MaxValue);
		var other = new Count(Int64.MinValue);

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenEqualAndBothHaveDefaultValue()
	{
		//Arrange
		var current = default(Count);
		var other = default(Count);

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeTrue();
	}

	[Theory]
	[InlineData(0)]
	[InlineData(Int64.MinValue)]
	[InlineData(Int64.MaxValue)]
	public void ReturnsTrue_WhenEqualAndBothHaveSameValue(Int64 int64)
	{
		//Arrange
		var current = new Count(int64);
		var other = new Count(int64);

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeTrue();
	}
	#endregion Equals(Count)

	#region Equals(Object)
	[Fact]
	public void ReturnsFalse_WhenObjectIsNull()
	{
		//Arrange
		var @this = new Count(Int64.MaxValue);
		Object? obj = null;

		//Act
		var actual = @this.Equals(obj);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenObjectIsNotOfTypeCount()
	{
		//Arrange
		var @this = new Count(Int64.MaxValue);
		Object obj = new CommandKey(Int64.MaxValue.ToString());

		//Act
		var actual = @this.Equals(obj);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenObjectIsOfTypeCountButIsNotEqual()
	{
		//Arrange
		var @this = new Count(Int64.MaxValue);
		Object obj = new Count(Int64.MinValue);

		//Act
		var actual = @this.Equals(obj);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenObjectIsOfTypeCountAndIsEqual()
	{
		//Arrange
		var @this = new Count(Int64.MaxValue);
		Object obj = new Count(Int64.MaxValue);

		//Act
		var actual = @this.Equals(obj);

		//Assert
		actual.Should().BeTrue();
	}
	#endregion Equals(Object)

	#region == Operator
	[Fact]
	public void ReturnsFalse_WhenLeftIsNull()
	{
		//Arrange
		Count? left = null;
		var right = new Count(Int64.MaxValue);

		//Act
		var actual = left == right;

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenRightIsNull()
	{
		//Arrange
		var left = new Count(Int64.MaxValue);
		Count? right = null;

		//Act
		var actual = left == right;

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenLeftAndRightAreNotEqual()
	{
		//Arrange
		var left = new Count(Int64.MaxValue);
		var right = new Count(Int64.MinValue);

		//Act
		var actual = left == right;

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenLeftAndRightAreNull()
	{
		//Arrange
		Count? left = null;
		Count? right = null;

		//Act
		var actual = left == right;

		//Assert
		actual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenLeftAndRightAreDefault()
	{
		//Arrange
		var left = default(Count);
		var right = default(Count);

		//Act
		var actual = left == right;

		//Assert
		actual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenLeftAndRightAreEqual()
	{
		//Arrange
		var left = new Count(Int64.MaxValue);
		var right = new Count(Int64.MaxValue);

		//Act
		var actual = left == right;

		//Assert
		actual.Should().BeTrue();
	}
	#endregion == Operator

	#region != Operator
	[Fact]
	public void ReturnsFalse_WhenLeftAndRightAreEqual()
	{
		//Arrange
		var left = new Count(Int64.MaxValue);
		var right = new Count(Int64.MaxValue);

		//Act
		var actual = left != right;

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenLeftAndRightAreNotEqual()
	{
		//Arrange
		var left = new Count(Int64.MaxValue);
		var right = new Count(Int64.MinValue);

		//Act
		var actual = left != right;

		//Assert
		actual.Should().BeTrue();
	}
	#endregion != Operator
}
