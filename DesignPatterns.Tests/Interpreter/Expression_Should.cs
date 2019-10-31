using DesignPatterns.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Interpreter
{
    public class Expression_Should
    {
        [Fact]
        public void Interpret_Roman_Numerals()
        {
            string roman = "MCMXXVIII";
            var context = new Context(roman);

            var tree = new List<Expression>
            {
                new ThousandExpression(),
                new HundredExpression(),
                new TenExpression(),
                new OneExpression()
            };

            foreach (var exp in tree)
                exp.Interpret(context);

            Assert.Equal(1928, context.Output);
        }
    }
}
