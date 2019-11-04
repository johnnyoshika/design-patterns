using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Mediator
{
    public interface IAirTrafficController
    {
        void ReceiveAircraftLocation(Aircraft reportingAircraft);
        void RegisterAircraftUnderGuidance(Aircraft aircraft);
    }

    // Mediator
    public class YvrCenter : IAirTrafficController
    {
        public List<Aircraft> UnderGuidance { get; } = new List<Aircraft>();
        public void ReceiveAircraftLocation(Aircraft reportingAircraft)
        {
            if (reportingAircraft.Altitude == 0) return;

            UnderGuidance
                .Where(a => a != reportingAircraft)
                .ToList()
                .ForEach(a =>
                {
                    if (Math.Abs(a.Altitude - reportingAircraft.Altitude) < a.Airspace)
                    {
                        // communicate to the class:
                        a.warnOfAirspaceIntrusionBy(reportingAircraft);
                    }
                });
        }

        public void RegisterAircraftUnderGuidance(Aircraft aircraft)
        {
            if (!UnderGuidance.Contains(aircraft))
                UnderGuidance.Add(aircraft);
        }
    }
}