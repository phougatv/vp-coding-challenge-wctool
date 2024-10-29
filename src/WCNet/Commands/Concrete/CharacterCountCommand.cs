namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("m")]
internal class CharacterCountCommand(IAsyncCharacterCountable characterCountable) : IAsyncCommand
{
    public async Task<Result<Count>> ExecuteAsync()
    {
        var characterCount = await characterCountable.GetCountAsync();

        return Result<Count>.Ok(characterCount);
    }
}
