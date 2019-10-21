using DesignPatterns.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Command
{
    public class Program_Should
    {
        /*
        Example below: use command pattern instead of a bunch of switch statements
        */

        [Fact]
        public void Print_Usage_If_No_Args_Sent()
        {
            var result = Program.Run();
            Assert.Equal("Commands:\r\nCreateOrder\r\nUpdateQuantity {number}\r\nShipOrder", result);
        }

        [Fact]
        public void Create_Order()
        {
            var result = Program.Run("CreateOrder");
            Assert.Equal("Order created", result);
        }

        [Fact]
        public void Updated_Quantity()
        {
            var result = Program.Run("UpdateQuantity 20");
            Assert.Equal("Quantity updated from 5 to 20", result);
        }

        [Fact]
        public void Not_Run_Command_If_Command_Name_Not_Found()
        {
            var result = Program.Run("foo bar");
            Assert.Equal("foo command not found", result);
        }
    }
}
