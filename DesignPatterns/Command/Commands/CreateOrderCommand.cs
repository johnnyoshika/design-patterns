using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Command.Commands
{
    class CreateOrderCommand : ICommand
    {
        public CreateOrderCommand(ILogger logger) => Logger = logger;

        ILogger Logger { get; }

        public void Execute() => Logger.AppendLine("Order created");
    }

    class CreateOrderCommandFactory : ICommandFactory
    {
        public string CommandName => "CreateOrder";
        public string CommandDescription => "CreateOrder";

        public ICommand MakeCommand(ILogger logger, string[] args) =>
            new CreateOrderCommand(logger);
    }
}
