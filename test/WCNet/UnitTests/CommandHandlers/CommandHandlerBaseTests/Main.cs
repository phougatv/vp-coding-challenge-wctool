<<<<<<< HEAD
﻿//namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandHandlers.CommandHandlerBaseTests;

//public class Main
//{
//    /// <summary>
//    /// Executes the action and returns the output written to the Console.
//    /// It redirects "Console.Out" to a "StringWriter", so that output written to the console can be captured and examined during testing.
//    /// </summary>
//    /// <param name="action">The action</param>
//    /// <returns>A string from Console.</returns>
//    private static String CaptureConsoleOutput(Action action)
//    {
//        var stringWriter = new StringWriter();
//        var originalOutput = Console.Out;
//        Console.SetOut(stringWriter);

//        try
//        {
//            action();
//        }
//        finally
//        {
//            Console.SetOut(originalOutput);
//        }

//        return stringWriter.ToString();
//    }

//    [Fact]
//    public void OutputsCommandNotFoundErrorMessage_WhenPreHandleFails()
//    {
//        //Arrange
//        var commandKey = new CommandKey("-w");
//        var args = new String[] { "-c", "filename.txt" };
//        var preHandleResult = Result<CommandArgument>.Fail(CommandNotFoundError.Create(commandKey));
//        var commandArgs = CommandArgument.Create([commandKey], "filename.txt");
//        var messageResult = Result<Message>.Ok(new Message("Success"));
//        var message = messageResult.Value;
//        var testHandler = new TestCommandHandler(
//            args => preHandleResult,
//            commandArgs => messageResult,
//            message => Result.Ok());
//        var expectedOutput = $"Command: \"{commandKey}\" not found.";

//        //Act
//        var actualOutput = CaptureConsoleOutput(() => testHandler.Main(args)).TrimEnd('\r', '\n'); ;

//        //Assert
//        actualOutput.Should()
//            .NotBeNullOrEmpty().And
//            .Be(expectedOutput);
//    }

//    [Fact]
//    public void OutputsCommandExecutionErrorMessage_WhenHandleFails()
//    {
//        //Arrange
//        var commandKey = new CommandKey("-c");
//        var args = new String[] { "-c", "filename.txt" };
//        var commandArgs = CommandArgument.Create([commandKey], "filename.txt");
//        var preHandleResult = Result<CommandArgument>.Ok(commandArgs);
//        var message = new Message("Success");
//        var messageResult = Result<Message>.Fail(CommandExecutionError.Create(commandKey));
//        var testHandler = new TestCommandHandler(
//            args => preHandleResult,
//            commandArgs => messageResult,
//            message => Result.Ok());
//        var expectedOutput = $"Error executing command: {commandKey}.";

//        //Act
//        var actualOutput = CaptureConsoleOutput(() => testHandler.Main(args)).TrimEnd('\r', '\n');

//        //Assert
//        actualOutput.Should()
//            .NotBeNullOrEmpty().And
//            .Be(expectedOutput);
//    }

//    [Fact]
//    public void OutputsSuccessMessage_WhenCommandExecutesSuccessfully()
//    {
//        //Arrange
//        var commandKey = new CommandKey("-c");
//        var args = new String[] { "-c", "filename.txt" };
//        var commandArgs = CommandArgument.Create([commandKey], "filename.txt");
//        var preHandleResult = Result<CommandArgument>.Ok(commandArgs);
//        var message = new Message("342190 filename.txt");
//        var messageResult = Result<Message>.Ok(message);
//        var testHandler = new TestCommandHandler(
//            args => preHandleResult,
//            commandArgs => messageResult,
//            message =>
//            {
//                Console.WriteLine(message);
//                return Result.Ok();
//            });
//        var expectedOutput = "342190 filename.txt";

//        //Act
//        var actualOutput = CaptureConsoleOutput(() => testHandler.Main(args)).TrimEnd('\r', '\n');

//        //Assert
//        actualOutput.Should()
//            .NotBeNullOrEmpty().And
//            .Be(expectedOutput);
//    }
//}
=======
﻿namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandHandlers.CommandHandlerBaseTests;

public class Main
{
    /// <summary>
    /// Executes the action and returns the output written to the Console.
    /// It redirects "Console.Out" to a "StringWriter", so that output written to the console can be captured and examined during testing.
    /// </summary>
    /// <param name="action">The action</param>
    /// <returns>A string from Console.</returns>
    private static String CaptureConsoleOutput(Action action)
    {
        var stringWriter = new StringWriter();
        var originalOutput = Console.Out;
        Console.SetOut(stringWriter);

        try
        {
            action();
        }
        finally
        {
            Console.SetOut(originalOutput);
        }

        return stringWriter.ToString();
    }

    [Fact]
    public void OutputsCommandNotFoundErrorMessage_WhenPreHandleFails()
    {
        //Arrange
        var commandKey = new CommandKey("-w");
        var args = new String[] { "-c", "filename.txt" };
        var preHandleResult = Result<CommandArgument>.Fail(CommandNotFoundError.Create(commandKey));
        var commandArgs = CommandArgument.Create([commandKey], "filename.txt");
        var messageResult = Result<Message>.Ok(new Message("Success"));
        var message = messageResult.Value;
        var testHandler = new TestCommandHandler(
            args => preHandleResult,
            commandArgs => messageResult,
            message => Result.Ok());
        var expectedOutput = $"Command: \"{commandKey}\" not found.";

        //Act
        var actualOutput = CaptureConsoleOutput(() => testHandler.Main(args)).TrimEnd('\r', '\n'); ;

        //Assert
        actualOutput.Should()
            .NotBeNullOrEmpty().And
            .Be(expectedOutput);
    }

    [Fact]
    public void OutputsCommandExecutionErrorMessage_WhenHandleFails()
    {
        //Arrange
        var commandKey = new CommandKey("-c");
        var args = new String[] { "-c", "filename.txt" };
        var commandArgs = CommandArgument.Create([commandKey], "filename.txt");
        var preHandleResult = Result<CommandArgument>.Ok(commandArgs);
        var message = new Message("Success");
        var messageResult = Result<Message>.Fail(CommandExecutionError.Create(commandKey));
        var testHandler = new TestCommandHandler(
            args => preHandleResult,
            commandArgs => messageResult,
            message => Result.Ok());
        var expectedOutput = $"Error executing command: {commandKey}.";

        //Act
        var actualOutput = CaptureConsoleOutput(() => testHandler.Main(args)).TrimEnd('\r', '\n');

        //Assert
        actualOutput.Should()
            .NotBeNullOrEmpty().And
            .Be(expectedOutput);
    }

    [Fact]
    public void OutputsSuccessMessage_WhenCommandExecutesSuccessfully()
    {
        //Arrange
        var commandKey = new CommandKey("-c");
        var args = new String[] { "-c", "filename.txt" };
        var commandArgs = CommandArgument.Create([commandKey], "filename.txt");
        var preHandleResult = Result<CommandArgument>.Ok(commandArgs);
        var message = new Message("342190 filename.txt");
        var messageResult = Result<Message>.Ok(message);
        var testHandler = new TestCommandHandler(
            args => preHandleResult,
            commandArgs => messageResult,
            message =>
            {
                Console.WriteLine(message);
                return Result.Ok();
            });
        var expectedOutput = "342190 filename.txt";

        //Act
        var actualOutput = CaptureConsoleOutput(() => testHandler.Main(args)).TrimEnd('\r', '\n');

        //Assert
        actualOutput.Should()
            .NotBeNullOrEmpty().And
            .Be(expectedOutput);
    }
}
>>>>>>> master
