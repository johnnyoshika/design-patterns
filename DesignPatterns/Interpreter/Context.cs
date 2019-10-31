using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Interpreter
{
    public class Context
    {
        public Context(string input)
        {
            Input = input;
        }

        public string Input { get; set; }
        public int Output { get; set; }
    }
}
