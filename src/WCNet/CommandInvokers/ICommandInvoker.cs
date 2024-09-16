﻿namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal interface ICommandInvoker
{
    void SetCommand(ICommand command);
    Result<UInt64> InvokeCommand();
}