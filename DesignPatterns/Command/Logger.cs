using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Command
{
    interface ILogger
    {
        void AppendLine(string message);
        string Output();
    }

    class Logger : ILogger
    {
        StringBuilder Logs { get; } = new StringBuilder();

        public void AppendLine(string message) => Logs.AppendLine(message);

        public string Output() => Logs.ToString().Trim();
    }
}
