# wc.NET: A Unix-like word count tool for Windows

This project aims to recreate the Unix `wc` utility for Windows as part of the [Coding Challenges series](https://codingchallenges.fyi/) by John Crickett.</br>
The key objectives of this project are (for more details visit [here](https://codingchallenges.fyi/challenges/challenge-wc/#the-challenge---building-wc)):
- Achieve support for the following commands: `-c`, `-l`, `-w`, `-m`.
- Develop a robust and efficient `wc` implementation.
- Ensure the application is modular and can accommodate future enhancements with minimal code changes.
- Adhere to best practices and coding standards, including SOLID principles, design patterns, and TDD to maintain code quality.

## Technical Stack
- C# with [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [LightResults](https://jscarle.github.io/LightResults/)
- [Xunit](https://xunit.net/)
- [NSubstitute](https://nsubstitute.github.io/)
- [FluentAssertions](https://fluentassertions.com/)

## Features
### Source Code
  - [x] **Byte count (`-c`)**: Counts the number of bytes in a file.
  - [x] **Line count (`-l`)**: Counts the number of lines in a file.
  - [x] **Word count (`-w`)**: Counts the number of words in a file.
  - [x] **Character count (`-m`)**: Counts the number of characters in a file. If the current locale does not support multibyte characters this will match the `-c` option.
  - [ ] **No command/Default option**: It is an equivalent to `-c`, `-l`, and `-w` options.
  - [x] **.editorconfig**: Enforces consistent coding styles and formatting across the project, ensuring adherence to best practices and reducing code review overhead.
  - [x] **Flexible dependency injection**: Utilizes .NET 8 Dependency Injection with Keyed Services for scalable and maintainable command resolution.
  - [x] **Command pattern**: Implements the Command Pattern for handling different command-line arguments, ensuring flexibility and adherence to SOLID principles.
  - [x] **Command-line arguments parser**: Includes a built-in parser for handling command-line inputs.
  - [x] **Template method pattern**: Incorporates the Template Method Pattern to share common execution logic across commands.
### Tests
  - [ ] **End-to-End tests**: Test the application as a whole, ensuring that it behaves as expected in real-world scenarios.
  - [x] **Integration tests**: Test how different parts of the application work together.
  - [x] **Unit tests**: Comprehensive unit tests for each component, ensuring code reliability.
  - [ ] **Benchmarks**: Performance testing to ensure the tool operates efficiently even with large files.

## Build the solution
## Run the application
## Project structure
```
vp-coding-challenge-wcnet/
├── src/
│   └── WCNet/
|       ├── VP.CodingChallenges.WCNet.csproj    #.csproj file
│       ├── Attributes/                         # Custom attributes like CommandKeyAttribute
│       ├── CommandResolvers/                   # Command resolver classes
│       ├── CommandHandlers/                    # CommandHandler and base classes
│       ├── Commands/                           # Command implementations (e.g., ByteCountCommand)
│       ├── Models/                             # Core models like Command
│       ├── appsettings.json                    # Configuration for the application
|       └── Program.cs                          # Entry point of the application
└── test/
|   └── WCNet/
|       └── Tests
|           └── VP.CodingChallenges.WCNet.Tests.csproj    #.csproj file
|               ├── E2ETests
|               ├── IntegrationTests
|               └── UnitTests
|       └── Benchmarks
|           └── VP.CodingChallenges.WCNet.Benchmarks.csproj    #.csproj file
```

## How to?
### Add a new command
- Create a class in **Commands > Concrete** directory/folder, with prefix `Command` and add `CommandKeyAttribute` to it.
  ```
  [CommandKey("x")]
  internal sealed class TestCommand : ICommand
  {
  	public String Execute (String filepath) => throw new NotImplementedException();
  }
  ```
- Add the same command-key (`x` in this case) in `ParserOptions` of `appsettings.json` as follows:
  ```
  //before
  {
  	"ParserOptions": {
    	"CommandExpression": "^(-[clwm])"
  	}
	}

  //after
  {
  	"ParserOptions": {
  		"CommandExpression": "^(-[clwmx])"
  	}
  }
  ```
### Run your newly added command
- Modify `launchSettings.json` as follows:
  ```
  "commandLineArgs": "-<your_command-key> <filename>.txt"
  ```
- Build and run the application.