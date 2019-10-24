using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Facade
{
    class GeoLookupService
    {
        public string GetCityByZipCode(string zipCode) =>
            (zipCode == "83714")
                ? "Boise"
                : throw new NotSupportedException();

        public string GetStateByZipCode(string zipCode) =>
            (zipCode == "83714")
                ? "ID"
                : throw new NotSupportedException();

        public Coordinates GetCoordinatesByZipCode(string zipCode) =>
            (zipCode == "83714")
                ? new Coordinates { Latitude = 100, Longitude = 100 }
                : throw new NotSupportedException();
    }

    class WeatherService
    {
        public decimal GetTemperature(Coordinates coordinates) =>
            (coordinates.Latitude == 100 && coordinates.Longitude == 100)
                ? 72.4m
                : throw new NotSupportedException();
    }

    class Coordinates
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
