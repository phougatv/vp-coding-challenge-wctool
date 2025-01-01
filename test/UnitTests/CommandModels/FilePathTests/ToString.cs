namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.FilePathTests;

public class ToString
{
	[Fact]
	public void ReturnsValueInExpectedFormat_WhenFilePathHasValue()
	{
		//Arrange
		var filePath = new FilePath(@"Z:\fake\file\path\file.txt");
		var expected = "FilePath=[Path: \"Z:\\fake\\file\\path\\file.txt\"]";

		//Act
		var actual = filePath.ToString();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenFilePathIsDefault()
	{
		//Arrange
		var filePath = default(FilePath);
		var expected = "FilePath=[Path: \"null\"]";

		//Act
		var actual = filePath.ToString();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsValueInExpectedFormat_WhenFilePathContainsSpecialCharacters()
	{
		//Arrange
		var filePath = new FilePath(@"Z:\fake\file\path\file!@#$%^&*().txt");
		var expected = "FilePath=[Path: \"Z:\\fake\\file\\path\\file!@#$%^&*().txt\"]";

		//Act
		var actual = filePath.ToString();

		//Assert
		actual.Should().Be(expected);
	}

	[Theory]
	[InlineData(@" Z:\fake\file\path\file.txt", "FilePath=[Path: \" Z:\\fake\\file\\path\\file.txt\"]")]	//Leading whitespace
	[InlineData(@"Z:\fake\file\path\file.txt ", "FilePath=[Path: \"Z:\\fake\\file\\path\\file.txt \"]")]    //Trailing whitespace
	public void ReturnsValueInExpectedFormat_WhenFilePathContainsWhitespace(String path, String expected)
	{
		//Arrange
		var filePath = new FilePath(path);

		//Act
		var actual = filePath.ToString();

		//Assert
		actual.Should().Be(expected);
	}
}
