using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Interpreter
{
    public abstract class Expression
    {
        // source: https://www.dofactory.com/net/interpreter-design-pattern

        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.StartsWith(Nine()))
            {
                context.Output += (9 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Four()))
            {
                context.Output += (4 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Five()))
            {
                context.Output += (5 * Multiplier());
                context.Input = context.Input.Substring(1);
            }

            while(context.Input.StartsWith(One()))
            {
                context.Output += (1 * Multiplier());
                context.Input = context.Input.Substring(1);
            }
        }

        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }

    // A 'TerminalExpression' class
    public class ThousandExpression : Expression
    {
        public override string One() => "M";
        public override string Four() => " ";
        public override string Five() => " ";
        public override string Nine() => " ";
        public override int Multiplier() => 1000;
    }

    // A 'TerminalExpression' class
    public class HundredExpression : Expression
    {
        public override string One() => "C"; // 1 hundred
        public override string Four() => "CD"; // 4 hundred
        public override string Five() => "D"; // 5 hundred
        public override string Nine() => "CM"; // 9 hundred
        public override int Multiplier() => 100;
    }

    // A 'TerminalExpression' class
    public class TenExpression : Expression
    {
        public override string One() => "X"; // 10
        public override string Four() => "XL"; // 40
        public override string Five() => "L"; // 50
        public override string Nine() => "XC"; // 90
        public override int Multiplier() => 10;
    }

    // A 'TerminalExpression' class
    public class OneExpression : Expression
    {
        public override string One() => "I";
        public override string Four() => "IV";
        public override string Five() => "V";
        public override string Nine() => "IX";
        public override int Multiplier() => 1;
    }
}
