namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.CountTests;

public class ImplicitOperations
{
    [Fact]
    public void ReturnsCount_WhenConvertingInt64ToCount()
    {
        // Arrange
        var i64 = Int64.MaxValue;
        var expectedCount = new Count(Int64.MaxValue);

        // Act
        Count actualCount = i64;

        // Assert
        actualCount.Should().Be(expectedCount);
    }

    [Fact]
    public void ReturnsInt64_WhenConvertingCountToInt64()
    {
        // Arrange
        var count = new Count(Int64.MaxValue);

        // Act
        Int64 actual = count;

        // Assert
        actual.Should().Be(Int64.MaxValue);
    }

    [Fact]
    public void ReturnsCount_WhenConvertingInt32ToCount()
    {
        // Arrange
        var i32 = Int32.MaxValue;
        var expectedCount = new Count(Int32.MaxValue);

        // Act
        Count actualCount = i32;

        // Assert
        actualCount.Should().Be(expectedCount);
    }

    [Fact]
    public void ReturnsCount_WhenConvertingInt16ToCount()
    {
        // Arrange
        var i16 = Int16.MaxValue;
        var expectedCount = new Count(Int16.MaxValue);

        // Act
        Count actualCount = i16;

        // Assert
        actualCount.Should().Be(expectedCount);
    }

    [Fact]
    public void ReturnsCount_WhenConvertingByteToCount()
    {
        // Arrange
        var b = Byte.MaxValue;
        var expectedCount = new Count(Byte.MaxValue);

        // Act
        Count actualCount = b;

        // Assert
        actualCount.Should().Be(expectedCount);
    }
}
