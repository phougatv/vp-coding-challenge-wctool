namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.FilePathTests;

public class GetFileName
{
	[Fact]
	public void ReturnsTheFileName()
	{
		//Arrange
		var filePath = new FilePath(@"C:\Users\User\Desktop\file.txt");

		//Act
		var fileName = filePath.GetFileName();

		//Assert
		fileName.Should().Be("file.txt");
	}
}
