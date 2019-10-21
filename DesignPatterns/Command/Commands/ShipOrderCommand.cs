using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Command.Commands
{
    class ShipOrderCommand : ICommand
    {
        public ShipOrderCommand(ILogger logger) => Logger = logger;

        ILogger Logger { get; }

        public void Execute() => Logger.AppendLine("Order shipped");
    }

    class ShipOrderCommandFactory : ICommandFactory
    {
        public string CommandName => "ShipOrder";
        public string CommandDescription => "ShipOrder";

        public ICommand MakeCommand(ILogger logger, string[] args) =>
            new ShipOrderCommand(logger);
    }
}
