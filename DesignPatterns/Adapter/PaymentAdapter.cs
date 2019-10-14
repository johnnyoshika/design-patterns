using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Adapter
{
    class PaymentAdapter : IPaymentAdapter
    {
        public PaymentAdapter(IStripe stripe) => Stripe = stripe;

        IStripe Stripe { get; }

        public void Charge(string card, decimal amount) => Stripe.ChargeCreditCard($"id:{card}", amount);
    }
}
