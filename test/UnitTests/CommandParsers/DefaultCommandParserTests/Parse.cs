namespace VP.CodingChallenge.WCNet.UnitTest.CommandParsers.DefaultCommandParserTests;

public class Parse
{
	[Fact]
	public void ReturnsCommandFormatError_WhenArgsIsNull()
	{
		//Arrange
		var expectedErrorMessage = "Incorrect command format, try -<command> <filepath_along_with_filename.extension>.";
		var args = (String[])null!;
		var options = new CommandParsingOptions();
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<CommandFormatError>().And
			.Subject.As<CommandFormatError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsCommandFormatError_WhenArgsIsEmpty()
	{
		//Arrange
		var expectedErrorMessage = "Incorrect command format, try -<command> <filepath_along_with_filename.extension>.";
		var args = Array.Empty<String>();
		var options = new CommandParsingOptions();
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<CommandFormatError>().And
			.Subject.As<CommandFormatError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsCommandFormatError_WhenArgsHasMoreThanTwoElements()
	{
		//Arrange
		var expectedErrorMessage = "Incorrect command format, try -<command> <filepath_along_with_filename.extension>.";
		var args = new[] { "-c", "file.txt", "extra" };
		var options = new CommandParsingOptions();
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<CommandFormatError>().And
			.Subject.As<CommandFormatError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsCommandParsingOptionsMissingError_WhenOptionsIsNull()
	{
		//Arrange
		var expectedErrorMessage = "CommandParsingOptions and its required properties cannot be null or empty.";
		var args = new[] { "-c", "file.txt" };
		var options = (CommandParsingOptions)null!;
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<CommandParsingOptionsMissingError>().And
			.Subject.As<CommandParsingOptionsMissingError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsCommandParsingOptionsMissingError_WhenOptionsDefaultCommandsIsNull()
	{
		//Arrange
		var expectedErrorMessage = "CommandParsingOptions and its required properties cannot be null or empty.";
		var args = new[] { "-c", "file.txt" };
		var options = new CommandParsingOptions { DefaultCommands = null! };
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<CommandParsingOptionsMissingError>().And
			.Subject.As<CommandParsingOptionsMissingError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsCommandParsingOptionsMissingError_WhenOptionsDefaultCommandsIsEmpty()
	{
		//Arrange
		var expectedErrorMessage = "CommandParsingOptions and its required properties cannot be null or empty.";
		var args = new[] { "-c", "file.txt" };
		var options = new CommandParsingOptions { DefaultCommands = [] };
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<CommandParsingOptionsMissingError>().And
			.Subject.As<CommandParsingOptionsMissingError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsCommandParsingOptionsMissingError_WhenOptionsAllowedCommandPatternIsNull()
	{
		//Arrange
		var expectedErrorMessage = "CommandParsingOptions and its required properties cannot be null or empty.";
		var args = new[] { "-c", "file.txt" };
		var options = new CommandParsingOptions { AllowedCommandPattern = null! };
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<CommandParsingOptionsMissingError>().And
			.Subject.As<CommandParsingOptionsMissingError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsCommandParsingOptionsMissingError_WhenOptionsAllowedCommandPatternIsEmpty()
	{
		//Arrange
		var expectedErrorMessage = "CommandParsingOptions and its required properties cannot be null or empty.";
		var args = new[] { "-c", "file.txt" };
		var options = new CommandParsingOptions { AllowedCommandPattern = String.Empty };
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<CommandParsingOptionsMissingError>().And
			.Subject.As<CommandParsingOptionsMissingError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsCommandParsingOptionsMissingError_WhenOptionsAllowedFileExtensionIsNull()
	{
		//Arrange
		var expectedErrorMessage = "CommandParsingOptions and its required properties cannot be null or empty.";
		var args = new[] { "-c", "file.txt" };
		var options = new CommandParsingOptions { AllowedFileExtension = null! };
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<CommandParsingOptionsMissingError>().And
			.Subject.As<CommandParsingOptionsMissingError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsCommandParsingOptionsMissingError_WhenOptionsAllowedFileExtensionIsEmpty()
	{
		//Arrange
		var expectedErrorMessage = "CommandParsingOptions and its required properties cannot be null or empty.";
		var args = new[] { "-c", "file.txt" };
		var options = new CommandParsingOptions { AllowedFileExtension = String.Empty };
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<CommandParsingOptionsMissingError>().And
			.Subject.As<CommandParsingOptionsMissingError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsFileExtensionNotAllowedError_WhenFileDoesNotHaveAnyExtension()
	{
		//Arrange
		var expectedErrorMessage = "File extension not found, file name with an extension is expected.";
		var args = new[] { "-c", "file" };
		var options = new CommandParsingOptions
		{
			AllowedFileExtension = ".txt",
			AllowedCommandPattern = "^(-[clwm])",
			DefaultCommands = ["l", "w", "c"],
			Directory = ".\\Files"
		};
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<FileExtensionNotFoundError>().And
			.Subject.As<FileExtensionNotFoundError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsFileExtensionNotAllowedError_WhenFileExtensionIsNotAllowed()
	{
		//Arrange
		var expectedErrorMessage = "File extension: \".doc\" not allowed, file path with correct extension is expected.";
		var args = new[] { "-c", "file.doc" };
		var options = new CommandParsingOptions
		{
			AllowedFileExtension = ".txt",
			AllowedCommandPattern = "^(-[clwm])",
			DefaultCommands = ["l", "w", "c"],
			Directory = ".\\Files"
		};
		var fileOperation = Substitute.For<IFile>();
		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<FileExtensionNotAllowedError>().And
			.Subject.As<FileExtensionNotAllowedError>().ToString().Should().Be(expectedErrorMessage);
	}

	[Fact]
	public void ReturnsFileNotFoundError_WhenFileDoesNotExist()
	{
		//Arrange
		var args = new[] { "-c", "file.txt" };
		var options = new CommandParsingOptions
		{
			AllowedFileExtension = ".txt",
			AllowedCommandPattern = "^(-[clwm])",
			DefaultCommands = ["l", "w", "c"],
			Directory = ".\\Files"
		};
		var fileOperation = Substitute.For<IFile>();
		fileOperation.Exists(".\\Files\\file.txt").Returns(false);

		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<FileNotFoundError>().And
			.Subject.As<FileNotFoundError>().ToString().Should().Be("File: \"file.txt\", not found.");
	}

	[Fact]
	public void ReturnsCommandNotFoundError_WhenCommandKeyIsNotInAllowedCommandPattern()
	{
		//Arrange
		var expectedKey = new CommandKey("a");
		var args = new[] { "-a", "file.txt" };
		var options = new CommandParsingOptions
		{
			AllowedFileExtension = ".txt",
			AllowedCommandPattern = "^(-[clwm])",
			DefaultCommands = ["l", "w", "c"],
			Directory = ".\\Files"
		};
		var fileOperation = Substitute.For<IFile>();
		fileOperation.Exists(".\\Files\\file.txt").Returns(true);

		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsFailed.Should().BeTrue();
		actual.Error.Should()
			.BeOfType<CommandNotFoundError>().And
			.Subject.As<CommandNotFoundError>().ToString().Should().Be($"Command '{expectedKey}' not found.");
	}

	[Fact]
	public void ReturnsCommandRequest_WhenItIsDefaultCommand()
	{
		//Arrange
		var args = new[] { "file.txt" };
		var options = new CommandParsingOptions
		{
			AllowedFileExtension = ".txt",
			AllowedCommandPattern = "^(-[clwm])",
			DefaultCommands = ["l", "w", "c"],
			Directory = ".\\Files"
		};
		var fileOperation = Substitute.For<IFile>();
		fileOperation.Exists(".\\Files\\file.txt").Returns(true);

		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsSuccess.Should().BeTrue();
		actual.Value.Should().NotBeNull();
		actual.Value.CommandKeys.Should().BeEquivalentTo(options.DefaultCommands);
		actual.Value.FilePath.Value.Should().Be(".\\Files\\file.txt");
	}

	[Fact]
	public void ReturnsCommandRequest_WhenItIsNotDefaultCommand()
	{
		//Arrange
		var expectedKey = (CommandKey[])[new CommandKey("c")];
		var args = new[] { "-c", "file.txt" };
		var options = new CommandParsingOptions
		{
			AllowedFileExtension = ".txt",
			AllowedCommandPattern = "^(-[clwm])",
			DefaultCommands = ["l", "w", "c"],
			Directory = ".\\Files"
		};
		var fileOperation = Substitute.For<IFile>();
		fileOperation.Exists(".\\Files\\file.txt").Returns(true);

		var parser = new DefaultCommandParser(fileOperation);

		//Act
		var actual = parser.Parse(args, options);

		//Assert
		actual.Should().NotBeNull();
		actual.Should().BeOfType<Result<CommandRequest>>();
		actual.IsSuccess.Should().BeTrue();
		actual.Value.Should().NotBeNull();
		actual.Value.CommandKeys.Should().BeEquivalentTo(expectedKey);
		actual.Value.FilePath.Value.Should().Be(".\\Files\\file.txt");
	}
}
