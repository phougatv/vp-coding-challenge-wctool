namespace VP.CodingChallenge.WCNet.UnitTests.CommandErrors.ParserOptionsMissingErrorTests;

public class ToString
{
    [Fact]
    public void ReturnsErrorMessage()
    {
        //Arrange
        var error = ParserOptionsMissingError.Create();

        //Act
        var result = error.ToString();

        //Assert
        result.Should().Be("Either ParserOptions object is null or one of its properties is null/empty.");
    }
}
