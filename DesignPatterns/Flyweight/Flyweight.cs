using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace DesignPatterns.Flyweight
{
    // source: https://refactoring.guru/design-patterns/flyweight/csharp/example

    // The Flyweight stores a common portion of the state (also called intrinsic
    // state) that belongs to multiple real business entities. The Flyweight
    // accepts the rest of the state (extrinsic state, unique for each entity)
    // via its method parameters.
    public class Flyweight
    {
        Car SharedState { get; set; }

        public Flyweight(Car car /* intrinsic state */)
        {
            SharedState = car;
        }

        public string Operation(Car uniqueState /* extrinsic state */)
        {
            string s = JsonSerializer.Serialize(SharedState);
            string u = JsonSerializer.Serialize(uniqueState);
            return $"Flyweight: Displaying shared {s} and unique {u} state.";
        }
    }

    // The Flyweight Factory creates and manages the Flyweight objects. It
    // ensures that flyweights are shared correctly. When the client requests a
    // flyweight, the factory either returns an existing instance or creates a
    // new one, if it doesn't exist yet.
    public class FlyweightFactory
    {
        List<Tuple<Flyweight, string>> Flyweights { get; } = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params Car[] args)
        {
            args.ToList().ForEach(elem => Flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), GetKey(elem))));
        }

        string GetKey(Car car)
        {
            var elements = new List<string?> { car.Model, car.Color, car.Company, car.Owner, car.Number }
                                .Where(k => k != null)
                                .ToList();

            elements.Sort();

            return string.Join("_", elements);
        }

        public Flyweight GetFlyweight(Car sharedState)
        {
            string key = GetKey(sharedState);

            if (!Flyweights.Where(t => t.Item2 == key).Any())
                Flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));

            return Flyweights.Where(t => t.Item2 == key).First().Item1;
        }

        public string ListFlyweights() => string.Join('\n', Flyweights.Select(f => f.Item2));
    }

    public class Car
    {
        public string? Owner { get; set; }
        public string? Number { get; set; }
        public string? Company { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
    }
}
