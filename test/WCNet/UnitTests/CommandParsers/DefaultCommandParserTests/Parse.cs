namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandParsers.DefaultCommandParserTests;

public class Parse
{
    [Fact]
    public void FailsWithCommandFormatError_WhenNumberOfArgumentsIsLessThanTwo()
    {
        //Arrange
        var args = new String[] { "filename.txt" };
        var mockedOptions = Substitute.For<IOptions<ParserOptions>>();
        var parser = new DefaultCommandParser(mockedOptions);

        //Act
        var actualResult = parser.Parse(args);

        //Assert
        actualResult.Should().NotBeNull().And.BeOfType<Result<CommandArgument>>();
        actualResult.IsFailed.Should().BeTrue();
        actualResult.Error.Should().NotBeNull().And.BeOfType<CommandFormatError>();
        actualResult.Error.Message.Should().NotBeNullOrEmpty().And.Be("Incorrect command format, try -<command> <filepath_along_with_filename.extension>.");
    }

    [Fact]
    public void FailsWithCommandFormatError_WhenNumberOfArgumentsIsGreaterThanTwo()
    {
        //Arrange
        var args = new String[] { "-c", "", "filename.txt" };
        var mockedOptions = Substitute.For<IOptions<ParserOptions>>();
        var parser = new DefaultCommandParser(mockedOptions);

        //Act
        var actualResult = parser.Parse(args);

        //Assert
        actualResult.Should().NotBeNull().And.BeOfType<Result<CommandArgument>>();
        actualResult.IsFailed.Should().BeTrue();
        actualResult.Error.Should().NotBeNull().And.BeOfType<CommandFormatError>();
        actualResult.Error.Message.Should().NotBeNullOrEmpty().And.Be("Incorrect command format, try -<command> <filepath_along_with_filename.extension>.");
    }

    [Fact]
    public void FailsWithCommandNotFoundError_WhenSpecifiedCommandIsNotFound()
    {
        //Arrange
        var args = new String[] { "-w", "filename.txt" };
        var mockedOptions = Substitute.For<IOptions<ParserOptions>>();
        mockedOptions.Value.Returns(new ParserOptions { CommandExpression = "^(-[cl])" });

        var parser = new DefaultCommandParser(mockedOptions);

        //Act
        var actualResult = parser.Parse(args);

        //Assert
        actualResult.Should().NotBeNull().And.BeOfType<Result<CommandArgument>>();
        actualResult.IsFailed.Should().BeTrue();
        actualResult.Error.Should().NotBeNull().And.BeOfType<CommandNotFoundError>();
        actualResult.Error.Message.Should().NotBeNullOrEmpty().And.Be("Command: \"-w\" not found.");
    }

    [Fact]
    public void FailsWithFilesExtensionNotAllowedError_WhenSpecifiedFilenameHasIncorrectExtension()
    {
        //Arrange
        var args = new String[] { "-c", "filename.exe" };
        var fileExtension = Path.GetExtension(args[^1]);
        var mockedOptions = Substitute.For<IOptions<ParserOptions>>();
        mockedOptions.Value.Returns(new ParserOptions
        {
            CommandExpression = "^(-[cl])",
            AllowedFileExtension = ".txt"
        });

        var parser = new DefaultCommandParser(mockedOptions);

        //Act
        var actualResult = parser.Parse(args);

        //Assert
        actualResult.Should().NotBeNull().And.BeOfType<Result<CommandArgument>>();
        actualResult.IsFailed.Should().BeTrue();
        actualResult.Error.Should().NotBeNull().And.BeOfType<FileExtensionNotAllowedError>();
        actualResult.Error.Message.Should().NotBeNullOrEmpty().And.Be($"File extension: \".{fileExtension}\", is not allowed.");
    }

    [Fact]
    public void FailsWithFileNotFoundError_WhenSpecifiedFileDoesNotExist()
    {
        //Arrange
        var args = new String[] { "-c", "filename.txt" };
        var filename = args[^1];
        var mockedOptions = Substitute.For<IOptions<ParserOptions>>();
        mockedOptions.Value.Returns(new ParserOptions
        {
            CommandExpression = "^(-[cl])",
            AllowedFileExtension = ".txt"
        });

        var parser = new DefaultCommandParser(mockedOptions);

        //Act
        var actualResult = parser.Parse(args);

        //Assert
        actualResult.Should().NotBeNull().And.BeOfType<Result<CommandArgument>>();
        actualResult.IsFailed.Should().BeTrue();
        actualResult.Error.Should().NotBeNull().And.BeOfType<FileNotFoundError>();
        actualResult.Error.Message.Should().NotBeNullOrEmpty().And.Be($"File: {filename}, not found.");
    }

    [Fact]
    public void ReturnsCommandArgumentResult_WhenBothCommandAndFilenameAreSuccessfullyParsed()
    {
        //Arrange
        var tempPath = Path.GetTempPath();
        var command = "c";
        var filename = "testfile.txt";
        var args = new String[] { "-c", filename };
        var stubOptions = Substitute.For<IOptions<ParserOptions>>();
        stubOptions.Value.Returns(new ParserOptions
        {
            CommandExpression = "^(-[cl])",
            AllowedFileExtension = ".txt",
            Directory = tempPath
        });

        var parser = new DefaultCommandParser(stubOptions);
        var expectedResult = CommandArgument.Create(command, Path.Combine(tempPath, filename));

        //Act
        var actualResult = parser.Parse(args);

        //Assert
        actualResult.Should().NotBeNull().And.BeOfType<Result<CommandArgument>>();
        actualResult.Errors.Should().BeEmpty();
        actualResult.IsSuccess.Should().BeTrue();
        actualResult.Value.Should().Be(expectedResult);
    }
}
