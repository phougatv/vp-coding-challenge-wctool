namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.FilePathTests;

public class CastingOperators
{
	[Fact]
	public void Successfully_ConvertsStringToFilePath()
	{
		//Arrange
		var path = @"c:\temp\file.txt";

		//Act
		FilePath filePath = path;

		//Assert
		filePath.Value.Should().Be(path);
	}

	[Fact]
	public void Successfully_ConvertsFilePathToString()
	{
		//Arrange
		var path = @"c:\temp\file.txt";
		var filePath = new FilePath(path);

		//Act
		String actualPath = filePath;

		//Assert
		actualPath.Should().Be(path);
	}

	[Fact]
	public void Successfully_ConvertsDefaultFilePathToNullString()
	{
		//Arrange
		var filePath = default(FilePath);
		var path = filePath.Value;

		//Act
		String actualPath = filePath;

		//Assert
		actualPath.Should().Be(path);
	}

	[Fact]
	public void ThrowsArgumentException_WhenNullStringIsCastedAsFilePath()
	{
		//Arrange
		var path = (String)null!;

		//Act
		Action act = () => { FilePath filePath = path; };

		//Assert
		act.Should().Throw<ArgumentException>().WithMessage("Filepath cannot be null or empty or only whitespace. (Parameter 'path')");
	}

	[Fact]
	public void ThrowsArgumentException_WhenEmptyStringIsCastedAsFilePath()
	{
		//Arrange
		var path = String.Empty;

		//Act
		Action act = () => { FilePath filePath = path; };

		//Assert
		act.Should().Throw<ArgumentException>().WithMessage("Filepath cannot be null or empty or only whitespace. (Parameter 'path')");
	}

	[Fact]
	public void ThrowsArgumentException_WhenStringContainingSingleWhitespaceIsCastedAsFilePath()
	{
		//Arrange
		var path = " ";

		//Act
		Action act = () => { FilePath filePath = path; };

		//Assert
		act.Should().Throw<ArgumentException>().WithMessage("Filepath cannot be null or empty or only whitespace. (Parameter 'path')");
	}

	[Theory]
	[InlineData("  ")]
	[InlineData("   ")]
	[InlineData("    ")]
	[InlineData("     ")]
	[InlineData("      ")]
	public void ThrowsArgumentException_WhenStringContainingMultipleWhitespaceIsCastedAsFilePath(String path)
	{
		//Act
		Action act = () => { FilePath filePath = path; };

		//Assert
		act.Should().Throw<ArgumentException>().WithMessage("Filepath cannot be null or empty or only whitespace. (Parameter 'path')");
	}
}
