using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.NullObject
{
    public class AutomobileRepository
    {
        public Automobile FindById(string id) => id == "mini" ? new MiniCooper() : Automobile.Null;
    }
}
