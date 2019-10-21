using DesignPatterns.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Command
{
    class CommandParser
    {

        public CommandParser(IEnumerable<ICommandFactory> commands) => Commands = commands;

        IEnumerable<ICommandFactory> Commands { get; }

        public ICommand ParseCommand(ILogger logger, string[] args)
        {
            var commandName = args[0];
            var factory = FindCommand(commandName);
            if (factory == null)
                return new NotFoundCommand(logger, commandName);

            return factory.MakeCommand(logger, args);
        }

        ICommandFactory FindCommand(string commandName) => Commands.FirstOrDefault(cmd => cmd.CommandName == commandName);
    }
}