namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.CommandKeyTests;

public class GetHashCode
{
	private static Int32 Actual_HashCode(CommandKey key) => key.GetHashCode();

	[Fact]
	public void ReturnsSameValue_WhenSameInstanceIsCalledMultipleTimes()
	{
		//Arrange
		var key = new CommandKey("c");

		//Act & Assert
		Actual_HashCode(key).Should().Be(Actual_HashCode(key));
	}

	[Fact]
	public void ReturnsSameValue_ForDifferentInstancesWhenTheyAreEqual() =>
		//Arrange, Act & Assert
		Actual_HashCode("c").Should().Be(Actual_HashCode("c"));

	[Fact]
	public void ReturnsSameValue_WhenCommandKeysAreDefault() =>
		//Act & Assert
		Actual_HashCode(default).Should().Be(Actual_HashCode(default));

	[Fact]
	public void ReturnsSameValue_WhenCommandKeyIsEmpty() =>
		//Arrange, Act & Assert
		Actual_HashCode(String.Empty).Should().Be(Actual_HashCode(String.Empty));

	[Fact]
	public void ReturnsDifferentValue_WhenCommandKeysDiffersInCasing() =>
		//Arrange, Act & Assert
		Actual_HashCode("c").Should().NotBe(Actual_HashCode("C"));

	[Fact]
	public void ReturnsDifferentValue_WhenCommandKeysDiffersInWhitespace() =>
		//Arrange, Act & Assert
		Actual_HashCode("c").Should().NotBe(Actual_HashCode(" c "));

	[Fact]
	public void ReturnsDifferentValue_ForDifferentInstancesWhenTheyAreNotEqual() =>
		//Arrange, Act & Assert
		Actual_HashCode("c").Should().NotBe(Actual_HashCode("w"));
}
