namespace VP.CodingChallenge.WCNet.CommandFactories;

internal class CountCommandFactory : ICommandFactory
{
    private readonly IDictionary<CommandKey, Type> _commandTypeMap;
    private readonly IOutput _output;

    public CountCommandFactory(
        IDictionary<CommandKey, Type> commandTypeMap,
        IOutput output)
    {
        _commandTypeMap = commandTypeMap;
        _output = output;
    }

    public ICommand CreateCommand(CommandArgument request)
    {
        if (_commandTypeMap.TryGetValue(request.CommandKey, out var commandType))
        {
            return (ICommand?)Activator.CreateInstance(commandType, request.Filepath, _output) ?? new CommandNotFound(_output);
        }

        return new CommandNotFound(_output);
    }
}
