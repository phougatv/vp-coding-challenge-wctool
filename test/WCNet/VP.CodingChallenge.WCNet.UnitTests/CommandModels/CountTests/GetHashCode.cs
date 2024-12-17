namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.CountTests;

public class GetHashCode
{
    [Fact]
    public void ReturnsSameValue_WhenSameInstanceIsCalledMultipleTimes()
    {
        //Arrange
        var count = new Count(1);
        var hash_1 = count.GetHashCode();
        var hash_2 = count.GetHashCode();

        //Act
        var actual = hash_1.Equals(hash_2);

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void ReturnsSameValue_ForDifferentInstancesWhenTheyAreEqual()
    {
        //Arrange
        var count_1 = new Count(1);
        var count_2 = new Count(1);

        //Act
        var hash_1 = count_1.GetHashCode();
        var hash_2 = count_2.GetHashCode();

        //Assert
        hash_1.Should().Be(hash_2);
    }

    [Fact]
    public void ReturnsDifferentValue_ForDifferentInstancesWhenTheyAreNotEqual()
    {
        //Arrange
        var count_1 = new Count(1);
        var count_2 = new Count(2);

        //Act
        var hash_1 = count_1.GetHashCode();
        var hash_2 = count_2.GetHashCode();

        //Assert
        hash_1.Should().NotBe(hash_2);
    }
}
