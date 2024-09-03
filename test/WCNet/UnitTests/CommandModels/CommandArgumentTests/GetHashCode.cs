namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.CommandArgumentTests;

public class GetHashCode
{
    [Fact]
    public void ReturnsSameValue_WhenSameObjectIsCalledMultipleTimes()
    {
        //Arrange
        var commandArgs = CommandArgument.Create(["c"], "filepath");
        var hash_1 = commandArgs.GetHashCode();
        var hash_2 = commandArgs.GetHashCode();

        //Act
        var actual = hash_1.Equals(hash_2);

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void ReturnsSameValue_ForEqualObjects()
    {
        //Arrange
        var commandArgs_1 = CommandArgument.Create(["c"], "filepath");
        var commandArgs_2 = CommandArgument.Create(["c"], "filepath");

        //Act
        var hash_1 = commandArgs_1.GetHashCode();
        var hash_2 = commandArgs_2.GetHashCode();

        //Assert
        hash_1.Should().Be(hash_2);
    }

    [Fact]
    public void ReturnsDifferentValue_WhenCommandKeyMatchesButFilepathDoesNotMatch()
    {
        //Arrange
        var commandArgs_1 = CommandArgument.Create(["c"], "filepath");
        var commandArgs_2 = CommandArgument.Create(["c"], "fake-filepath");

        //Act
        var hash_1 = commandArgs_1.GetHashCode();
        var hash_2 = commandArgs_2.GetHashCode();

        //Assert
        hash_1.Should().NotBe(hash_2);
    }

    [Fact]
    public void ReturnsDifferentValue_WhenFilepathMatchesButCommandKeyDoesNotMatch()
    {
        //Arrange
        var commandArgs_1 = CommandArgument.Create(["c"], "filepath");
        var commandArgs_2 = CommandArgument.Create(["l"], "filepath");

        //Act
        var hash_1 = commandArgs_1.GetHashCode();
        var hash_2 = commandArgs_2.GetHashCode();

        //Assert
        hash_1.Should().NotBe(hash_2);
    }
}
