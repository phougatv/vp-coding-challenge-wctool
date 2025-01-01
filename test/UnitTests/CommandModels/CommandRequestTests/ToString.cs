namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.CommandRequestTests;

public class ToString
{
	private static readonly String NameOf_CommandRequest = nameof(CommandRequest);

	private static String Actual_ToString(CommandRequest request) => request.ToString();

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCommandKeysIsNull()
	{
		//Arrange
		var expected = $"{NameOf_CommandRequest}=[CommandKeys: null, FilePath: \"fake/file/path/file.txt\"]";
		var nullKeys = (IReadOnlyCollection<CommandKey>)null!;
		var request = CommandRequest.Create(nullKeys, "fake/file/path/file.txt");

		//Act
		var actual = Actual_ToString(request);

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCommandKeysIsEmpty()
	{
		//Arrange
		var expected = $"{NameOf_CommandRequest}=[CommandKeys: empty, FilePath: \"fake/file/path/file.txt\"]";
		var request = CommandRequest.Create([], "fake/file/path/file.txt");

		//Act
		var actual = Actual_ToString(request);

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCommandKeysHasSingleValue()
	{
		//Arrange
		var expected = $"{NameOf_CommandRequest}=[CommandKeys: c, FilePath: \"fake/file/path/file.txt\"]";
		var request = CommandRequest.Create(["c"], "fake/file/path/file.txt");

		//Act
		var actual = Actual_ToString(request);

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenCommandKeysHasMultipleValues()
	{
		//Arrange
		var expected = $"{NameOf_CommandRequest}=[CommandKeys: c, m, w, FilePath: \"fake/file/path/file.txt\"]";
		var request = CommandRequest.Create(["c", "m", "w"], "fake/file/path/file.txt");

		//Act
		var actual = Actual_ToString(request);

		//Assert
		actual.Should().Be(expected);
	}
}
