using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.TemplateMethod
{
    public interface ILogger
    {
        void Log(string? message);
    }
}
