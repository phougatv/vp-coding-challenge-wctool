namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.MessageTests;

public class ToString
{
    [Fact]
    public void ReturnsStringContainingCommandKeyAndFilepath()
    {
        //Arrange
        var commandKey = new Message("message");
        var expected = "message";

        //Act
        var actual = commandKey.ToString();

        //Assert
        actual.Should().Be(expected);
    }
}
