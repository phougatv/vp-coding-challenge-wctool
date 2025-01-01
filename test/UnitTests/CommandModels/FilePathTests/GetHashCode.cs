namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.FilePathTests;

using System.IO;

public class GetHashCode
{
	[Fact]
	public void ReturnsSameValue_WhenSameInstanceIsCalledMultipleTimes()
	{
		//Arrange
		var filePath = new FilePath(@"Z:\fake\file\path\file.txt");
		var expected = filePath.GetHashCode();

		//Act
		var actual = filePath.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsSameValue_ForDifferentInstancesWhenTheyAreEqual()
	{
		//Arrange
		var filePath1 = new FilePath(@"Z:\fake\file\path\file.txt");
		var filePath2 = new FilePath(@"Z:\fake\file\path\file.txt");
		var expected = filePath1.GetHashCode();

		//Act
		var actual = filePath2.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsSameValue_WhenFilePathsAreDefault()
	{
		//Arrange
		var filePath1 = default(FilePath);
		var filePath2 = default(FilePath);
		var expected = filePath1.GetHashCode();

		//Act
		var actual = filePath2.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsDifferentValue_WhenFilePathsDiffersInCasing()
	{
		//Arrange
		var filePath1 = new FilePath(@"Z:\fake\file\path\file.txt");
		var filePath2 = new FilePath(@"Z:\fake\file\path\File.txt");

		//Act
		var actual1 = filePath1.GetHashCode();
		var actual2 = filePath2.GetHashCode();

		//Assert
		actual1.Should().NotBe(actual2);
	}

	[Theory]
	[InlineData(@"Z:\fake\file\path\file.doc")]	//.doc
	[InlineData(@"Z:\fake\file\path\file.pdf")]	//.pdf
	public void ReturnsDifferentValue_WhenFilePathsDiffersInFileExtension(String path)
	{
		//Arrange
		var filePath1 = new FilePath(@"Z:\fake\file\path\file.txt");
		var filePath2 = new FilePath(path);
		var expected = filePath1.GetHashCode();

		//Act
		var actual = filePath2.GetHashCode();

		//Assert
		actual.Should().NotBe(expected);
	}

	[Theory]
	[InlineData(@" Z:\fake\file\path\file.txt")]	//Leading whitespace
	[InlineData(@"Z:\fake\file\path\file.txt ")]	//Trailing whitespace
	public void ReturnsDifferentValue_WhenFilePathsDiffersInLeadingOrTrailingWhitespaces(String path)
	{
		//Arrange
		var filePath1 = new FilePath(@"Z:\fake\file\path\file.txt");
		var filePath2 = new FilePath(path);
		var expected = filePath1.GetHashCode();

		//Act
		var actual = filePath2.GetHashCode();

		//Assert
		actual.Should().NotBe(expected);
	}

	[Fact]
	public void ReturnsDifferentValue_WhenFilePathsDiffersInFileName()
	{
		//Arrange
		var filePath1 = new FilePath(@"Z:\fake\file\path\file.txt");
		var filePath2 = new FilePath(@"Y:\fake\file\path\file1.txt");
		var expected = filePath1.GetHashCode();

		//Act
		var actual = filePath2.GetHashCode();

		//Assert
		actual.Should().NotBe(expected);
	}

	[Theory]
	[InlineData(@"Z:/fake/file/path/file.txt")] //Forward slashes
	[InlineData(@"Z:\fake/file\path/file.txt")] //Mix of forward and back slashes
	public void ReturnsDifferentValue_WhenFilePathsDiffersInSlashes(String path)
	{
		//Arrange
		var filePath1 = new FilePath(@"Z:\fake\file\path\file.txt");
		var filePath2 = new FilePath(path);
		var expected = filePath1.GetHashCode();

		//Act
		var actual = filePath2.GetHashCode();

		//Assert
		actual.Should().NotBe(expected);
	}

	[Theory]
	[InlineData(@"C:\fake\file\path\file.txt" + "\n")]     //Newline
	[InlineData(@"C:\fake\file\path\file.txt" + "\t")]     //Tab
	[InlineData(@"C:\fake\file\path\file.txt" + "\r")]     //Carriage return
	[InlineData(@"C:\fake\file\path\file.txt" + "\0")]     //Null character
	[InlineData(@"C:\fake\file\path\file$.txt")]           //Dollar sign in the filename
	public void ReturnsDifferentValue_WhenFilePathsDiffersInValueDueToSpecialCharacters(String path)
	{
		//Arrange
		var filePath1 = new FilePath(@"Z:\fake\file\path\file.txt");
		var filePath2 = new FilePath(path);
		var expected = filePath1.GetHashCode();

		//Act
		var actual = filePath2.GetHashCode();

		//Assert
		actual.Should().NotBe(expected);
	}
}
