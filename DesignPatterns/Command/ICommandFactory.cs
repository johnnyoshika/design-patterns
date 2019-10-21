using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Command
{
    interface ICommandFactory
    {
        string CommandName { get; }
        string CommandDescription { get; }

        ICommand MakeCommand(ILogger logger, string[] args);
    }
}
