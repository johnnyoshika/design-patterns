using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Command.Commands
{
    class UpdateQuantityCommand : ICommand
    {
        public UpdateQuantityCommand(ILogger logger, int newQuantity)
        {
            Logger = logger;
            NewQuantity = newQuantity;
        }

        ILogger Logger { get; }
        int NewQuantity { get; }

        public void Execute()
        {
            // simulate fetching old quantity from database
            int oldQuantity = 5;

            // simulate updating quantity in database
            Logger.AppendLine($"Quantity updated from {oldQuantity} to {NewQuantity}");
        }
    }

    class UpdateQuantityCommandFactory : ICommandFactory
    {
        public int NewQuantity { get; set; }

        public string CommandName => "UpdateQuantity";
        public string CommandDescription => "UpdateQuantity {number}";

        public ICommand MakeCommand(ILogger logger, string[] args) =>
            new UpdateQuantityCommand(logger, int.Parse(args[1]));
    }
}
