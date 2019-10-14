using DesignPatterns.Adapter;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Adapter
{
    public class PaymentAdapter_Should
    {
        [Fact]
        public void Wrap_Stripe_To_Support_Interface_That_Program_Expects()
        {
            // Client code (e.g. Program) needs to work with IPaymentAdapter, which exposes Charge(string, decimal).
            // IStripe exposes ChargeCreditCard(string, decimal), therefore client code can't work directly with IStripe.
            // IPaymentAdapter acts as the "middle man" between Program and IStripe.
            // From this point foward, all client code (e.g. Program) is only dependent on IPaymentAdapter, so Stripe can be replaced with something else without modifying client code.

            // Analogy for Adapter Pattern is a travel power adapter that's used between a power outlet and a device power input.

            var stripe = new Mock<IStripe>();
            var paymentAdapter = new PaymentAdapter(stripe.Object);
            var program = new Program(paymentAdapter);
            program.Run("12345", 100);

            stripe.Verify(s => s.ChargeCreditCard("id:12345", 100), Times.Once());
        }
    }
    class Program
    {
        public Program(IPaymentAdapter paymentAdapter)
        {
            PaymentAdapter = paymentAdapter;
        }

        IPaymentAdapter PaymentAdapter { get; }

        public void Run(string card, decimal amount) => PaymentAdapter.Charge(card, amount);
    }
}
