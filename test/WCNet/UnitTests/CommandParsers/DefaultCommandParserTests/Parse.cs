namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandParsers.DefaultCommandParserTests;

using VP.CodingChallenge.WCNet.Test.FileOperations;

public class Parse(FilesDirectoryFixture fixture) : IClassFixture<FilesDirectoryFixture>
{
    private readonly FilesDirectoryFixture _fixture = fixture;

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_WhenArgsIsNull()
    {
        //Arrange
        String[] args = null!;
        var options = new ParserOptions();

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<CommandFormatError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_WhenArgsIsEmpty()
    {
        //Arrange
        var args = Array.Empty<String>();
        var options = new ParserOptions();

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<CommandFormatError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_WhenArgsLengthIsGreaterThanTwo()
    {
        //Arrange
        var command = "-c";
        var filepath = @"c:\fake\file\path\filename.txt";
        var args = new[] { command, filepath, "extra" };
        var options = new ParserOptions();

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<CommandFormatError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_WhenParserOptionsIsNull()
    {
        //Arrange
        var command = "-c";
        var filepath = @"c:\fake\file\path\filename.txt";
        var args = new[] { command, filepath };
        ParserOptions? options = null;

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<ParserOptionsMissingError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_WhenDefaultCommandsIsNull()
    {
        //Arrange
        var command = "-c";
        var filepath = @"c:\fake\file\path\filename.txt";
        var args = new[] { command, filepath };
        var options = new ParserOptions { DefaultCommands = null! };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<ParserOptionsMissingError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_WhenDefaultCommandsIsEmpty()
    {
        //Arrange
        var command = "-c";
        var filepath = @"c:\fake\file\path\filename.txt";
        var args = new[] { command, filepath };
        var options = new ParserOptions { DefaultCommands = Array.Empty<CommandKey>() };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<ParserOptionsMissingError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_WhenAllowedCommandPatternIsNull()
    {
        //Arrange
        var command = "-c";
        var filepath = @"c:\fake\file\path\filename.txt";
        var args = new[] { command, filepath };
        var defaultCommands = new[] { new CommandKey("c"), new CommandKey("l"), new CommandKey("w") };
        var options = new ParserOptions { DefaultCommands = defaultCommands, AllowedCommandPattern = null! };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<ParserOptionsMissingError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_WhenAllowedCommandPatternIsEmpty()
    {
        //Arrange
        var command = "-c";
        var filepath = @"c:\fake\file\path\filename.txt";
        var args = new[] { command, filepath };
        var defaultCommands = new[] { new CommandKey("c"), new CommandKey("l"), new CommandKey("w") };
        var options = new ParserOptions { DefaultCommands = defaultCommands, AllowedCommandPattern = String.Empty };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<ParserOptionsMissingError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_WhenAllowedFileExtensionIsNull()
    {
        //Arrange
        var command = "-c";
        var filepath = @"c:\fake\file\path\filename.txt";
        var args = new[] { command, filepath };
        var defaultCommands = new[] { new CommandKey("c"), new CommandKey("l"), new CommandKey("w") };
        var options = new ParserOptions
        {
            DefaultCommands = defaultCommands,
            AllowedCommandPattern = "^(-[clwm])",
            AllowedFileExtension = null!
        };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<ParserOptionsMissingError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_WhenAllowedFileExtensionIsEmpty()
    {
        //Arrange
        var command = "-c";
        var filepath = @"c:\fake\file\path\filename.txt";
        var args = new[] { command, filepath };
        var defaultCommands = new[] { new CommandKey("c"), new CommandKey("l"), new CommandKey("w") };
        var options = new ParserOptions
        {
            DefaultCommands = defaultCommands,
            AllowedCommandPattern = "^(-[clwm])",
            AllowedFileExtension = String.Empty
        };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<ParserOptionsMissingError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_ForDefaultCommandWhenFileExtensionIsNotAllowed()
    {
        //Arrange
        var filepath = @"c:\fake\file\path\filename.docx";
        var args = new[] { filepath };
        var defaultCommands = new[] { new CommandKey("c"), new CommandKey("l"), new CommandKey("w") };
        var options = new ParserOptions
        {
            DefaultCommands = defaultCommands,
            AllowedCommandPattern = "^(-[clwm])",
            AllowedFileExtension = ".txt"
        };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<FileExtensionNotAllowedError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_ForDefaultCommandWhenFileDoesNotExists()
    {
        //Arrange
        var filepath = @"c:\fake\file\path\filename.txt";
        var args = new[] { filepath };
        var defaultCommands = new[] { new CommandKey("c"), new CommandKey("l"), new CommandKey("w") };
        var options = new ParserOptions
        {
            DefaultCommands = defaultCommands,
            AllowedCommandPattern = "^(-[clwm])",
            AllowedFileExtension = ".txt"
        };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<FileNotFoundError>();
    }

    [Fact]
    public void ReturnsSuccessfulResultOfCommandRequest_ForDefaultCommandWhenFileExtensionIsAllowedAndFileExists()
    {
        //Arrange
        var filename = "filename.txt";
        var args = new[] { filename };
        var filepath = Path.Combine(_fixture.FilesDirectory, filename);
        var defaultCommands = new[] { new CommandKey("c"), new CommandKey("l"), new CommandKey("w") };
        var options = new ParserOptions
        {
            DefaultCommands = defaultCommands,
            AllowedCommandPattern = "^(-[clwm])",
            AllowedFileExtension = ".txt",
            Directory = _fixture.FilesDirectory
        };
        CreateTestFile(filename, "Hello World!");

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeOfType<CommandRequest>();
        result.Value.IsDefault.Should().BeTrue();
        result.Value.Filepath.Value.Should().Be(filepath);
        result.Value.DefaultCommandKeys.Should().Equal(defaultCommands);
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_ForUserCommandWhenCommandIsNotFound()
    {
       //Arrange
        var command = "-x";
        var filepath = @"c:\fake\file\path\filename.txt";
        var args = new[] { command, filepath };
        var defaultCommands = new[] { new CommandKey("c"), new CommandKey("l"), new CommandKey("w") };
        var options = new ParserOptions
        {
            DefaultCommands = defaultCommands,
            AllowedCommandPattern = "^(-[clwm])",
            AllowedFileExtension = ".txt"
        };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<CommandNotFoundError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_ForUserCommandWhenFileExtensionIsNotAllowed()
    {
        //Arrange
        var command = "-c";
        var filepath = @"c:\fake\file\path\filename.docx";
        var args = new[] { command, filepath };
        var defaultCommands = new[] { new CommandKey("c"), new CommandKey("l"), new CommandKey("w") };
        var options = new ParserOptions
        {
            DefaultCommands = defaultCommands,
            AllowedCommandPattern = "^(-[clwm])",
            AllowedFileExtension = ".txt"
        };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<FileExtensionNotAllowedError>();
    }

    [Fact]
    public void ReturnsFailedResultOfCommandRequest_ForUserCommandWhenFileDoesNotExists()
    {
        //Arrange
        var command = "-c";
        var filename = "test-1.txt";
        var args = new[] { command, filename };
        var defaultCommands = new[] { new CommandKey("c"), new CommandKey("l"), new CommandKey("w") };
        var options = new ParserOptions
        {
            DefaultCommands = defaultCommands,
            AllowedCommandPattern = "^(-[clwm])",
            AllowedFileExtension = ".txt",
            Directory = _fixture.FilesDirectory
        };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsFailed.Should().BeTrue();
        result.Error.Should().BeOfType<FileNotFoundError>();
    }

    [Fact]
    public void ReturnsSuccessfulResultOfCommandRequest_ForUserCommandWhenCommandIsFoundAndFileExtensionIsAllowedAndFileExists()
    {
        //Arrange
        var command = "-c";
        var filename = "test.txt";
        var filepath = Path.Combine(_fixture.FilesDirectory, filename);
        var args = new[] { command, filename };
        var defaultCommands = new[] { new CommandKey("c"), new CommandKey("l"), new CommandKey("w") };
        var options = new ParserOptions
        {
            DefaultCommands = defaultCommands,
            AllowedCommandPattern = "^(-[clwm])",
            AllowedFileExtension = ".txt",
            Directory = _fixture.FilesDirectory
        };

        //Act
        var result = DefaultCommandParser.Parse(args, options);

        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeOfType<CommandRequest>();
        result.Value.IsDefault.Should().BeFalse();
        result.Value.Filepath.Value.Should().Be(filepath);
        result.Value.CommandKey.Should().Be(new CommandKey("c"));
    }

    #region Private Methods
    private String CreateTestFile(String filename, String content)
    {
        var filepath = Path.Combine(_fixture.FilesDirectory, filename);
        File.WriteAllText(filepath, content);
        return filepath;
    }
    #endregion Private Methods
}