namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.FilePathTests;

/// <summary>
/// This class tests the equality logic for the <see cref="FilePath"/> class.
/// It includes tests for the following methods and operators:
///		* <see cref="FilePath.Equals(FilePath)"/>
///		* <see cref="FilePath.Equals(Object?)"/>
///		* == operator
///		* != operator
/// </summary>
public class Equals
{
	#region Equals(FilePath)
	[Fact]
	public void ReturnsFalse_WhenOtherIsDefault()
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = default;

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Theory]
	[InlineData(@"C:\fake\file\path\file-name.doc")]
	[InlineData(@"C:\fake\file\path\file-name.csv")]
	public void ReturnsFalse_WhenFilePathDiffersInValueDueToFileExtension(String path)
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = path;

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Theory]
	[InlineData(@"C:\fake\file\path\file-name.TXT")]
	[InlineData(@"C:\fake\file\path\file-name.tXt")]
	public void ReturnsFalse_WhenFilePathDiffersInValueDueToFileExtensionCasing(String path)
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = path;

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Theory]
	[InlineData(@"C:\fake\file\path\File-name.txt")]
	[InlineData(@"C:\fake\file\path\FILE-NAME.txt")]
	public void ReturnsFalse_WhenFilePathDiffersInValueDueToCasing(String path)
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = path;

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Theory]
	[InlineData(@" C:\fake\file\path\file-name.txt")]	//Leading whitespace
	[InlineData(@"C:\fake\file\path\file-name.txt ")]	//Trailing whitespace
	public void ReturnsFalse_WhenFilePathDiffersInValueDueToTrailingAndLeadingWhitespaces(String path)
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = path;

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Theory]
	[InlineData(@"C:\fake\file\path\file-name.txt" + "\n")]		//Newline
	[InlineData(@"C:\fake\file\path\file-name.txt" + "\t")]		//Tab
	[InlineData(@"C:\fake\file\path\file-name.txt" + "\r")]		//Carriage return
	[InlineData(@"C:\fake\file\path\file-name.txt" + "\0")]		//Null character
	[InlineData(@"C:\fake\file\path\file-name$.txt")]			//Dollar sign in the filename
	public void ReturnsFalse_WhenFilePathDiffersInValueDueToSpecialCharacters(String path)
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = path;

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenFilePathDiffersInValueDueToFileName()
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = @"C:\fake\file\path\other-file-name.txt";

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenFilePathDiffersInRedundantSlashes()
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = @"C:\\fake\\file\\path\\file-name.txt";

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenFilePathDiffersInFilePath()
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = @"C:\real\file\path\file-name.txt";

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCurrentIsDefault()
	{
		//Arrange
		FilePath current = default;
		FilePath other = @"C:\fake\file\path\file-name.txt";

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenCurrentAndOtherAreDefault()
	{
		//Arrange
		FilePath current = default;
		FilePath other = default;

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenBothFilePathsAreEqualInValue()
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = @"C:\fake\file\path\file-name.txt";

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeTrue();
	}
	#endregion Equals(FilePath)

	#region Equals(Object?)
	[Fact]
	public void ReturnsFalse_WhenObjectIsNull()
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		Object? other = null;

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenObjectIsNotOfTypeFilePath()
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		CommandKey other = @"C:\fake\file\path\file-name.txt";

		//Act
		var isEqual = current.Equals((Object?)other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenObjectIsOfTypeFilePathButDiffersInValue()
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = @"C:\fake\file\path\other-file-name.txt";

		//Act
		var isEqual = current.Equals((Object?)other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenObjectIsOfTypeFilePathAndValueMatches()
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = @"C:\fake\file\path\file-name.txt";

		//Act
		var isEqual = current.Equals((Object?)other);

		//Assert
		isEqual.Should().BeTrue();
	}
	#endregion Equals(Object?)

	#region ==
	[Fact]
	public void ReturnsFalse_WhenLeftAndRigthAreNotEqual()
	{
		//Arrange
		FilePath left = @"C:\fake\file\path\file-name.txt";
		FilePath right = @"C:\fake\file\path\other-file-name.txt";

		//Act
		var isEqual = left == right;

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenLeftAndRightAreEqual()
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = @"C:\fake\file\path\file-name.txt";

		//Act
		var isEqual = current == other;

		//Assert
		isEqual.Should().BeTrue();
	}
	#endregion ==

	#region !=
	[Fact]
	public void ReturnsTrue_WhenLeftAndRigthAreNotEqual()
	{
		//Arrange
		FilePath left = @"C:\fake\file\path\file-name.txt";
		FilePath right = @"C:\fake\file\path\other-file-name.txt";

		//Act
		var isEqual = left != right;

		//Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsFalse_WhenLeftAndRightAreEqual()
	{
		//Arrange
		FilePath current = @"C:\fake\file\path\file-name.txt";
		FilePath other = @"C:\fake\file\path\file-name.txt";

		//Act
		var isEqual = current != other;

		//Assert
		isEqual.Should().BeFalse();
	}
	#endregion !=
}
