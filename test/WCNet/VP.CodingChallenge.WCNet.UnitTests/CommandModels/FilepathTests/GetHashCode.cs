namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.FilepathTests;

public class GetHashCode
{
    [Fact]
    public void ReturnsSameValue_WhenSameInstanceIsCalledMultipleTimes()
    {
        //Arrange
        var filepath = new Filepath("C:\\test.txt");
        var hash_1 = filepath.GetHashCode();
        var hash_2 = filepath.GetHashCode();

        //Act
        var actual = hash_1.Equals(hash_2);

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void ReturnsSameValue_ForDifferentInstancesWhenTheyAreEqual()
    {
        //Arrange
        var filepath_1 = new Filepath("C:\\test.txt");
        var filepath_2 = new Filepath("C:\\test.txt");

        //Act
        var hash_1 = filepath_1.GetHashCode();
        var hash_2 = filepath_2.GetHashCode();

        //Assert
        hash_1.Should().Be(hash_2);
    }

    [Fact]
    public void ReturnsDifferentValue_ForDifferentInstancesWhenTheyAreNotEqual()
    {
        //Arrange
        var filepath_1 = new Filepath("C:\\test.txt");
        var filepath_2 = new Filepath("C:\\test2.txt");

        //Act
        var hash_1 = filepath_1.GetHashCode();
        var hash_2 = filepath_2.GetHashCode();

        //Assert
        hash_1.Should().NotBe(hash_2);
    }
}
