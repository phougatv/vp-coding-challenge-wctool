namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.CommandRequestTests;

public class GetHashCode
{
	[Fact]
	public void ReturnsSameValue_WhenSameInstanceIsCalledMultipleTimes()
	{
		//Arrange
		var request = CommandRequest.Create(["c", "m"], "fake/file/path/file.txt");
		var expected = request.GetHashCode();

		//Act
		var actual = request.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsSameValue_WhenDifferentInstancesAreEqual()
	{
		//Arrange
		var request_1 = CommandRequest.Create(["c", "m"], "fake/file/path/file.txt");
		var request_2 = CommandRequest.Create(["c", "m"], "fake/file/path/file.txt");

		//Act
		var actual_1 = request_1.GetHashCode();
		var actual_2 = request_2.GetHashCode();

		//Assert
		actual_1.Should().Be(actual_2);
	}

	[Fact]
	public void ReturnsSameValue_WhenDifferentInstancesAreEqualAndCommandKeysAreDefault()
	{
		//Arrange
		var defaultCommandKeys = (IReadOnlyCollection<CommandKey>)[default, default];
		var request_1 = CommandRequest.Create(defaultCommandKeys, "fake/file/path/file.txt");
		var request_2 = CommandRequest.Create(defaultCommandKeys, "fake/file/path/file.txt");

		//Act
		var actual_1 = request_1.GetHashCode();
		var actual_2 = request_2.GetHashCode();

		//Assert
		actual_1.Should().Be(actual_2);
	}

	[Fact]
	public void ReturnsSameValue_WhenDifferentInstancesAreEqualAndCommandKeysAreEmpty()
	{
		//Arrange
		var request_1 = CommandRequest.Create([], "fake/file/path/file.txt");
		var request_2 = CommandRequest.Create([], "fake/file/path/file.txt");

		//Act
		var actual_1 = request_1.GetHashCode();
		var actual_2 = request_2.GetHashCode();

		//Assert
		actual_1.Should().Be(actual_2);
	}

	[Fact]
	public void ReturnsSameValue_WhenDifferentInstancesAreEqualAndCommandKeysAreNull()
	{
		//Arrange
		var nullKeys = (IReadOnlyCollection<CommandKey>)null!;
		var request_1 = CommandRequest.Create(nullKeys, "fake/file/path/file.txt");
		var request_2 = CommandRequest.Create(nullKeys, "fake/file/path/file.txt");

		//Act
		var actual_1 = request_1.GetHashCode();
		var actual_2 = request_2.GetHashCode();

		//Assert
		actual_1.Should().Be(actual_2);
	}

	[Fact]
	public void ReturnsDifferentValue_WhenInstancesDifferInCommandKeysCount()
	{
		//Arrange
		var request_1 = CommandRequest.Create(["c", "m"], "fake/file/path/file.txt");
		var request_2 = CommandRequest.Create(["c", "m", "d"], "fake/file/path/file.txt");

		//Act
		var actual_1 = request_1.GetHashCode();
		var actual_2 = request_2.GetHashCode();

		//Assert
		actual_1.Should().NotBe(actual_2);
	}

	[Fact]
	public void ReturnsDifferentValue_WhenInstancesDifferInCommandKeysValue()
	{
		//Arrange
		var request_1 = CommandRequest.Create(["c", "m"], "fake/file/path/file.txt");
		var request_2 = CommandRequest.Create(["c", "d"], "fake/file/path/file.txt");

		//Act
		var actual_1 = request_1.GetHashCode();
		var actual_2 = request_2.GetHashCode();

		//Assert
		actual_1.Should().NotBe(actual_2);
	}

	[Fact]
	public void ReturnsDifferentValue_WhenInstancesDifferInCommandKeysCasing()
	{
		//Arrange
		var request_1 = CommandRequest.Create(["c", "m"], "fake/file/path/file.txt");
		var request_2 = CommandRequest.Create(["C", "m"], "fake/file/path/file.txt");

		//Act
		var actual_1 = request_1.GetHashCode();
		var actual_2 = request_2.GetHashCode();

		//Assert
		actual_1.Should().NotBe(actual_2);
	}

	[Fact]
	public void ReturnsDifferentValue_WhenInstancesDifferInFilePathValue()
	{
		//Arrange
		var request_1 = CommandRequest.Create(["c", "m"], "fak/file/path/file.txt");
		var request_2 = CommandRequest.Create(["c", "m"], "fake/file/path/file.txt");

		//Act
		var actual_1 = request_1.GetHashCode();
		var actual_2 = request_2.GetHashCode();

		//Assert
		actual_1.Should().NotBe(actual_2);
	}

	[Fact]
	public void ReturnsDifferentValue_WhenInstancesDifferInFilePathCasing()
	{
		//Arrange
		var request_1 = CommandRequest.Create(["c", "m"], "Fake/file/path/file.txt");
		var request_2 = CommandRequest.Create(["c", "m"], "fake/file/path/File.txt");

		//Act
		var actual_1 = request_1.GetHashCode();
		var actual_2 = request_2.GetHashCode();

		//Assert
		actual_1.Should().NotBe(actual_2);
	}
}
