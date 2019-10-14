using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Adapter
{
    public interface IStripe
    {
        void ChargeCreditCard(string cardId, decimal amount);
    }
}
