using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesignPatterns.TemplateMethod
{
    // Templete Method uses inheritance to define an algorithm in a superclass while delegating responsibility for detailed implementations to child classes.
    // It provides greater reuse but it's less flexible than the Strategy pattern.

    // Template Method embodies the Hollywood Principle: Don't call us, we'll call you

    public abstract class OrderShipment
    {
        public string? Address { get; set; }
        public string? Label { get; set; }

        // This is the template method.
        public void Ship(ILogger logger)
        {
            VerifyShippingData();
            GetShippingLabelFromCarrier();
            PrintLabel(logger);
        }

        public virtual void VerifyShippingData()
        {
            if (string.IsNullOrWhiteSpace(Address))
                throw new ApplicationException("Invalid address.");
        }

        public abstract void GetShippingLabelFromCarrier();

        public virtual void PrintLabel(ILogger logger) =>
            logger.Log(Label);
    }

    public class UpsOrderShipment : OrderShipment
    {
        public override void GetShippingLabelFromCarrier() =>
            // Call UPS web service
            Label = $"UPS:[{Address}]";
    }

    public class FedExOrderShipment : OrderShipment
    {
        public override void GetShippingLabelFromCarrier() =>
            // Call FedEx web service
            Label = $"FedEx:[{Address}]";
    }
}
