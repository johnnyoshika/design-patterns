using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter
{
    public interface IPaymentAdapter
    {
        void Charge(string card, decimal amount);
    }
}
