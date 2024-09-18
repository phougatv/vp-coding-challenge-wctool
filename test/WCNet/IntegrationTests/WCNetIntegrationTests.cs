<<<<<<< HEAD
﻿//namespace VP.CodingChallenge.WCNet.Test.IntegrationTests;
//public class WCNetIntegrationTests : IClassFixture<FilesDirectoryFixture>
//{
//    private const String Files = "Files";
//    private static readonly String BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

//    private readonly IServiceProvider _serviceProvider;
//    private readonly FilesDirectoryFixture _fixture;

//    public WCNetIntegrationTests(FilesDirectoryFixture fixture)
//    {
//        _fixture = fixture;

//        var configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//            .Build();
//        var services = new ServiceCollection();

//        //add commands
//        services
//            .AddKeyedScoped<ICommand, ByteCountCommand>("c")
//            .AddKeyedScoped<ICommand, LineCountCommand>("l");

//        //add command resolvers
//        services
//            .AddScoped<ICommandResolver, DefaultCommandResolver>(provider =>
//            {
//                var commandMap = new Dictionary<CommandKey, ICommand>
//                {
//                    { "c", provider.GetRequiredKeyedService<ICommand>("c") },
//                    { "l", provider.GetRequiredKeyedService<ICommand>("l" ) }
//                };

//                return new DefaultCommandResolver(commandMap);
//            });

//        //add command parsers
//        //services.AddScoped<ICommandParser, DefaultCommandParser>();

//        //add parser options
//        var section = configuration.GetSection(nameof(ParserOptions));
//        if (section is not null)
//            services.Configure<ParserOptions>(section);

//        //add command handlers
//        services.AddScoped<CommandHandlerBase, DefaultCommandHandler>();

//        //build service provider
//        _serviceProvider = services.BuildServiceProvider();
//        _fixture = fixture;
//    }

//    [Fact]
//    public void ByteCountCommand_ReturnsCorrectByteCount()
//    {
//        //Arrange
//        var commandHandler = _serviceProvider.GetRequiredService<CommandHandlerBase>();
//        var filename = "byte_count_testfile.txt";
//        var commandKey = (CommandKey)"c";
//        var filepath = CreateTestFile(filename, "Hello World!\r\nThis is byte count integration test.");
//        var args = new String[] { "-c", filename };
//        var expected = "50 byte_count_testfile.txt";

//        //Act
//        var actual = CaptureConsoleOutput(() => commandHandler.Main(args)).TrimEnd('\r', '\n');

//        //Assert
//        actual.Should()
//            .NotBeNullOrEmpty().And
//            .Be(expected);
//    }

//    [Fact]
//    public void LineCountCommand_ReturnsCorrectLineCount()
//    {
//        //Arrange
//        var commandHandler = _serviceProvider.GetRequiredService<CommandHandlerBase>();
//        var filename = "line_count_testfile.txt";
//        var commandKey = (CommandKey)"l";
//        var filepath = CreateTestFile(filename, "Line1\r\nLine2\r\nLine3\r\nLine4.");
//        var args = new String[] { "-l", filename };
//        var expected = "4 line_count_testfile.txt";

//        //Act
//        var actual = CaptureConsoleOutput(() => commandHandler.Main(args)).TrimEnd('\r', '\n');

//        //Assert
//        actual.Should()
//            .NotBeNullOrEmpty().And
//            .Be(expected);
//    }

//    #region Private Methods
//    private String CreateTestFile(String filename, String content)
//    {
//        var filepath = Path.Combine(_fixture.FilesDirectory, filename);
//        File.WriteAllText(filepath, content);

//        return filepath;
//    }

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
//    #endregion Private Methods
//}
=======
﻿namespace VP.CodingChallenge.WCNet.Test.IntegrationTests;
public class WCNetIntegrationTests : IClassFixture<FilesDirectoryFixture>
{
    private const String Files = "Files";
    private static readonly String BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

    private readonly IServiceProvider _serviceProvider;
    private readonly FilesDirectoryFixture _fixture;

    public WCNetIntegrationTests(FilesDirectoryFixture fixture)
    {
        _fixture = fixture;

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        var services = new ServiceCollection();

        //add commands
        services
            .AddKeyedScoped<ICommand, ByteCountCommand>("c")
            .AddKeyedScoped<ICommand, LineCountCommand>("l");

        //add command resolvers
        services
            .AddScoped<ICommandResolver, DefaultCommandResolver>(provider =>
            {
                var commandMap = new Dictionary<CommandKey, ICommand>
                {
                    { "c", provider.GetRequiredKeyedService<ICommand>("c") },
                    { "l", provider.GetRequiredKeyedService<ICommand>("l" ) }
                };

                return new DefaultCommandResolver(commandMap);
            });

        //add command parsers
        services.AddScoped<ICommandParser, DefaultCommandParser>();

        //add parser options
        var section = configuration.GetSection(nameof(ParserOptions));
        if (section is not null)
            services.Configure<ParserOptions>(section);

        //add command handlers
        services.AddScoped<CommandHandlerBase, DefaultCommandHandler>();

        //build service provider
        _serviceProvider = services.BuildServiceProvider();
        _fixture = fixture;
    }

    [Fact]
    public void ByteCountCommand_ReturnsCorrectByteCount()
    {
        //Arrange
        var commandHandler = _serviceProvider.GetRequiredService<CommandHandlerBase>();
        var filename = "byte_count_testfile.txt";
        var commandKey = (CommandKey)"c";
        var filepath = CreateTestFile(filename, "Hello World!\r\nThis is byte count integration test.");
        var args = new String[] { "-c", filename };
        var expected = "50 byte_count_testfile.txt";

        //Act
        var actual = CaptureConsoleOutput(() => commandHandler.Main(args)).TrimEnd('\r', '\n');

        //Assert
        actual.Should()
            .NotBeNullOrEmpty().And
            .Be(expected);
    }

    [Fact]
    public void LineCountCommand_ReturnsCorrectLineCount()
    {
        //Arrange
        var commandHandler = _serviceProvider.GetRequiredService<CommandHandlerBase>();
        var filename = "line_count_testfile.txt";
        var commandKey = (CommandKey)"l";
        var filepath = CreateTestFile(filename, "Line1\r\nLine2\r\nLine3\r\nLine4.");
        var args = new String[] { "-l", filename };
        var expected = "4 line_count_testfile.txt";

        //Act
        var actual = CaptureConsoleOutput(() => commandHandler.Main(args)).TrimEnd('\r', '\n');

        //Assert
        actual.Should()
            .NotBeNullOrEmpty().And
            .Be(expected);
    }

    #region Private Methods
    private String CreateTestFile(String filename, String content)
    {
        var filepath = Path.Combine(_fixture.FilesDirectory, filename);
        File.WriteAllText(filepath, content);

        return filepath;
    }

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
    #endregion Private Methods
}
>>>>>>> master
