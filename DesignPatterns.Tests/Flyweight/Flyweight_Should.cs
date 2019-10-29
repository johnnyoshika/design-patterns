using DesignPatterns.Flyweight;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Flyweight
{
    public class Flyweight_Should
    {
        [Fact]
        public void Use_Intrinsic_And_Extrinsic_States()
        {
            // The client code usually creates a bunch of pre-populated
            // flyweights in the initialization stage of the application
            var factory = new FlyweightFactory(
                new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
                new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
                new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
                new Car { Company = "BMW", Model = "M5", Color = "red" },
                new Car { Company = "BMW", Model = "X6", Color = "white" }
            );

            Assert.Equal("Camaro2018_Chevrolet_pink\nblack_C300_Mercedes Benz\nC500_Mercedes Benz_red\nBMW_M5_red\nBMW_white_X6", factory.ListFlyweights());

            Assert.Equal(
                "Flyweight: Displaying shared {\"Owner\":null,\"Number\":null,\"Company\":\"BMW\",\"Model\":\"M5\",\"Color\":\"red\"} and unique {\"Owner\":\"James Doe\",\"Number\":\"CL234IR\",\"Company\":\"BMW\",\"Model\":\"M5\",\"Color\":\"red\"} state.", 
                AddCarToPoliceDatabase(factory, new Car
                {
                    Number = "CL234IR",
                    Owner = "James Doe",
                    Company = "BMW",
                    Model = "M5",
                    Color = "red"
                }));

            Assert.Equal(
                "Flyweight: Displaying shared {\"Owner\":null,\"Number\":null,\"Company\":\"BMW\",\"Model\":\"X1\",\"Color\":\"red\"} and unique {\"Owner\":\"James Doe\",\"Number\":\"CL234IR\",\"Company\":\"BMW\",\"Model\":\"X1\",\"Color\":\"red\"} state.",
                AddCarToPoliceDatabase(factory, new Car
                {
                    Number = "CL234IR",
                    Owner = "James Doe",
                    Company = "BMW",
                    Model = "X1",
                    Color = "red"
                }));

            Assert.Equal("Camaro2018_Chevrolet_pink\nblack_C300_Mercedes Benz\nC500_Mercedes Benz_red\nBMW_M5_red\nBMW_white_X6\nBMW_red_X1", factory.ListFlyweights());
        }

        string AddCarToPoliceDatabase(FlyweightFactory factory, Car car)
        {
            var flyweight = factory.GetFlyweight(new Car
            {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            return flyweight.Operation(car);
        }
    }
}
