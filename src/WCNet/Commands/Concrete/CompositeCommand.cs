//namespace VP.CodingChallenge.WCNet.Commands.Concrete;

//internal class CompositeCommand : ICommand
//{
//    private readonly ICollection<ICommand> _commands;
//    private ICollection<Count> _counts;

//    public CompositeCommand(ICollection<ICommand> commands)
//    {
//        _commands = commands;
//        _counts = new List<Count>(commands.Count);
//    }

//    public Result<ICollection<Count>> Execute()
//    {
//        foreach (var command in _commands)
//        {
//            var countResult = command.Execute();
//            _counts.Add(countResult.Value);
//        }

//        return Result<ICollection<Count>>.Ok(_counts);
//    }
//}
