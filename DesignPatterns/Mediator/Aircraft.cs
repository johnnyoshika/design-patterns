using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator
{
    // These aircrafts are all "colleagues" that are aware of the "mediator", IAirTrafficController
    public abstract class Aircraft
    {
        protected Aircraft(string callSign, IAirTrafficController atc, ILogger logger)
        {
            CallSign = callSign;
            Atc = atc;
            Logger = logger;
            Atc.RegisterAircraftUnderGuidance(this);
        }

        public string CallSign { get; }
        IAirTrafficController Atc { get; }
        ILogger Logger { get; }

        public abstract int Airspace { get; }

        int _currentAltitude;
        public int Altitude
        {
            get
            {
                return _currentAltitude;
            }
            set
            {
                _currentAltitude = value;
                Atc.ReceiveAircraftLocation(this);
            }
        }

        public void warnOfAirspaceIntrusionBy(Aircraft reportingAircraft) => Logger.Log($"{reportingAircraft.CallSign} intruding into {CallSign}'s airspace");
    }

    public class Airbus321 : Aircraft
    {
        public Airbus321(string callSign, IAirTrafficController atc, ILogger logger) : base(callSign, atc, logger)
        {
        }

        public override int Airspace => 1000;
    }

    public class Boeing737 : Aircraft
    {
        public Boeing737(string callSign, IAirTrafficController atc, ILogger logger) : base(callSign, atc, logger)
        {
        }

        public override int Airspace => 1500;
    }

    public class Embraer190 : Aircraft
    {
        public Embraer190(string callSign, IAirTrafficController atc, ILogger logger) : base(callSign, atc, logger)
        {
        }

        public override int Airspace => 700;
    }
}
