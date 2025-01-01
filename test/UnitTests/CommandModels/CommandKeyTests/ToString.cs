namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.CommandKeyTests;

public class ToString
{
	private static String Actual_ToString(CommandKey key) => key.ToString();
	private static String Expected_ToString(String key) => $"CommandKey=[Key: \"{key}\"]";

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCommandKeyHasValue() =>
		//Arrange, Act & Assert
		Actual_ToString("c").Should().Be(Expected_ToString("c"));

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCommandKeyIsDefault() =>
		//Arrange, Act & Assert
		Actual_ToString(default).Should().Be(Expected_ToString(String.Empty));

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCommandKeyIsSetEmpty() =>
		//Arrange, Act & Assert
		Actual_ToString(String.Empty).Should().Be(Expected_ToString(String.Empty));

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCommandKeyHasSpecialCharacters() =>
		//Arrange, Act & Assert
		Actual_ToString("!@#$%^&*()").Should().Be(Expected_ToString("!@#$%^&*()"));

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCommandKeyHasWhitespace() =>
		//Arrange, Act & Assert
		Actual_ToString(" c ").Should().Be(Expected_ToString(" c "));

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCommandKeyContainsOnlyWhitespace() =>
		//Arrange, Act & Assert
		Actual_ToString(" ").Should().Be(Expected_ToString(" "));
}