﻿namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal interface ICommandInvoker
{
    void SetCommand(IAsyncCommand command);
    void SetCommands(ICollection<IAsyncCommand> commands);
    Result<Count> InvokeCommand();
    Result<ICollection<Count>> InvokeCommands();
}
