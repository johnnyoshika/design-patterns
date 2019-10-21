using DesignPatterns.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Command
{
    public static class Program
    {
        public static string Run(string arguments = "")
        {
            var args = arguments.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var commands = Factories();
            if (args.Length == 0)
                return Usage(commands).Output();

            var parser = new CommandParser(commands);

            var logger = new Logger();
            var command = parser.ParseCommand(logger, args);
            command.Execute();
            return logger.Output();
        }

        static IEnumerable<ICommandFactory> Factories() =>
            new ICommandFactory[]
            {
                new CreateOrderCommandFactory(),
                new UpdateQuantityCommandFactory(),
                new ShipOrderCommandFactory()
            };

        static ILogger Usage(IEnumerable<ICommandFactory> commands)
        {
            var logger = new Logger();
            logger.AppendLine("Commands:");
            commands.ToList().ForEach(c =>  logger.AppendLine(c.CommandDescription));

            return logger;
        }
    }
}
