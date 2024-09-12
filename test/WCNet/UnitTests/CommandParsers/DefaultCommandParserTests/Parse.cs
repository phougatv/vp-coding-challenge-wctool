namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandParsers.DefaultCommandParserTests;

public class Parse
{
    #region Failure Cases
    [Fact]
    public void FailsWithCommandFormatError_WhenArgumentArrayIsEmpty()
    {
        //Arrange
        var args = Array.Empty<String>();
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
    public void FailsWithCommandFormatError_WhenArgumentArrayHasMoreThanTwoItems()
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
    public void FailsWithFileExtensionNotAllowedError_WhenFilenameIsTheOnlyItemInTheArgumentArray_AndItsExtensionIsNotAllowed()
    {
        //Arrange
        var args = new String[] { "filename.exe" };
        var fileExtension = Path.GetExtension(args[^1]);
        var mockedOptions = Substitute.For<IOptions<ParserOptions>>();
        mockedOptions.Value.Returns(new ParserOptions
        {
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
    public void FailsWithFileNotFounError_WhenFilenameIsTheOnlyItemInTheArgumentArray_AndItDoesNotExists()
    {
        //Arrange
        var args = new String[] { "filename.txt" };
        var filename = args[^1];
        var mockedOptions = Substitute.For<IOptions<ParserOptions>>();
        mockedOptions.Value.Returns(new ParserOptions
        {
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
    public void FailsWithCommandNotFoundError_WhenArgumentArrayHasCommandAndFilename_AndCommandDoesNotExists()
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
    public void FailsWithFileExtensionNotAllowedError_WhenArgumentArrayHasCommandAndFilename_AndFileExtensionIsNotAllowed()
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
    public void FailsWithFileNotFoundError_WhenArgumentArrayHasCommandAndFilename_AndFileDoesNotExists()
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
    #endregion Failure Cases

    #region Success Cases
    [Fact]
    public void SuccessfullyReturnsInstanceOfCommandArgumentWithDefaultCommands_WhenFilenameIsTheOnlyItemInTheArgumentArray()
    {
        //Arrange
        var tempPath = Path.GetTempPath();
        var filename = "testfile.txt";
        var args = new String[] { filename };
        var stubOptions = Substitute.For<IOptions<ParserOptions>>();
        var parserOptions = new ParserOptions
        {
            DefaultCommands = ["l", "w", "c"],
            CommandExpression = "^(-[cl])",
            AllowedFileExtension = ".txt",
            Directory = tempPath
        };
        stubOptions.Value.Returns(parserOptions);

        var parser = new DefaultCommandParser(stubOptions);
        var expectedResult = CommandArgument.Create(parserOptions.DefaultCommands, Path.Combine(tempPath, filename));

        //Act
        var actualResult = parser.Parse(args);

        //Assert
        actualResult.Should().NotBeNull().And.BeOfType<Result<CommandArgument>>();
        actualResult.Errors.Should().BeEmpty();
        actualResult.IsSuccess.Should().BeTrue();
        actualResult.Value.Should().Be(expectedResult);
    }

    [Fact]
    public void SuccessfullyReturnsInstanceOfCommandArgumentWithSpecifiedCommand_WhenArgumentArrayHasCorrectCommandAndFilename()
    {
        //Arrange
        var tempPath = Path.GetTempPath();
        var commandKey = "c";
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
        var expectedResult = CommandArgument.Create([commandKey], Path.Combine(tempPath, filename));

        //Act
        var actualResult = parser.Parse(args);

        //Assert
        actualResult.Should().NotBeNull().And.BeOfType<Result<CommandArgument>>();
        actualResult.Errors.Should().BeEmpty();
        actualResult.IsSuccess.Should().BeTrue();
        actualResult.Value.Should().Be(expectedResult);
    }
    #endregion Success Cases
}
