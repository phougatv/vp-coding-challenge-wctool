namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.CommandKeyTests;

public class GetHashCode
{
    [Fact]
    public void ReturnsSameValue_WhenSameInstanceIsCalledMultipleTimes()
    {
        //Arrange
        var key = new CommandKey("-c");
        var hash_1 = key.GetHashCode();
        var hash_2 = key.GetHashCode();

        //Act
        var actual = hash_1.Equals(hash_2);

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void ReturnsSameValue_ForDifferentInstancesWhenTheyAreEqual()
    {
        //Arrange
        var key_1 = new CommandKey("-c");
        var key_2 = new CommandKey("-c");

        //Act
        var hash_1 = key_1.GetHashCode();
        var hash_2 = key_2.GetHashCode();

        //Assert
        hash_1.Should().Be(hash_2);
    }

    [Fact]
    public void ReturnsDifferentValue_ForDifferentInstancesWhenTheyAreNotEqual()
    {
        //Arrange
        var key_1 = new CommandKey("-c");
        var key_2 = new CommandKey("-w");

        //Act
        var hash_1 = key_1.GetHashCode();
        var hash_2 = key_2.GetHashCode();

        //Assert
        hash_1.Should().NotBe(hash_2);
    }
}
