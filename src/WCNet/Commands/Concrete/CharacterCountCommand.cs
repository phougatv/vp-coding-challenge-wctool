namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("m")]
internal class CharacterCountCommand(ICharacterCountable characterCountable) : ICommand
{
    public Result<Count> Execute()
    {
        var characterCount = characterCountable.GetCount();

        return Result<Count>.Ok(characterCount);
    }
}
