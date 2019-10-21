using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Command.Commands
{
    class NotFoundCommand : ICommand
    {
        public NotFoundCommand(ILogger logger, string requestedCommandName)
        {
            Logger = logger;
            RequestedCommandName = requestedCommandName;
        }

        ILogger Logger { get; }
        string RequestedCommandName { get; }

        public void Execute() => Logger.AppendLine($"{RequestedCommandName} command not found");
    }
}
