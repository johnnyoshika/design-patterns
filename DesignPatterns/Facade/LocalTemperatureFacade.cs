using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Facade
{
    public class LocalTemperatureFacade
    {
        GeoLookupService GeoLookupService { get; } = new GeoLookupService();
        WeatherService WeatherService { get; } = new WeatherService();

        public LocalTemperature GetTemperature(string zipCode) =>
            new LocalTemperature
            {
                City = GeoLookupService.GetCityByZipCode(zipCode),
                State = GeoLookupService.GetStateByZipCode(zipCode),
                Temperature = WeatherService.GetTemperature(GeoLookupService.GetCoordinatesByZipCode(zipCode))
            };
    }

    public class LocalTemperature
    {
        public string? City { get; set; }
        public string? State { get; set; }
        public decimal Temperature { get; set; }
    }
}
