using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.ParkingStructure
{
    public class ParkingStructure
    {
        //constructors
        //public class Location
        //{
        //    public int Level { get; set; }
        //    public int ParkingSpaceNumber { get; set; }

        //}

        //public double GeneralParkingPrice { get; set; }
        //public double ValetPrice { get; set; }
        //public bool Available { get; set; }
        //public string LicensePlate { get; set; }
        //public double HoursParked { get; set; }
        //public Location ParkedLocation { get; set; }

        //public Location AddCar(string LicensePlate, Location location)
        //{
        //    Location parkingSpot = new Location
        //    {
        //        Level = location.Level,
        //        ParkingSpaceNumber = location.ParkingSpaceNumber
        //    };
        //    //var parkingSpotInfo = {}
        //    return parkingSpot;
        //}

    }

    public class GeneralParking
    {
        public double GeneralParkingPrice { get; set; }
    }

    public class ValetParking
    {
        public double ValetPrice { get; set; }
    }

    public class FrequentFlyerParking
    {
        public double FrequentFlyer { get; set; }
        public int FrequentFlyerNumber { get; set; }
    }

    public class ParkingSpot : ParkingLevel
    {
        public int ParkingSpaceNumber { get; set; }
       // public string LicensePlate { get; set; }
        public double HoursParked { get; set; }
        public DateTime StartTime { get; set; }
        public bool Available { get; set; }
    }

    public class ParkingSpotOwner : ParkingSpot
    {
        public string LicensePlate { get; set; }
        public string Name { get; set; }

    }

    public class ParkingLevel
    {
        public int ParkingStructureLevel { get; set; }

        public DateTime AddCar(ParkingSpot parking)
        {
            ParkingSpotOwner parking = new ParkingSpotOwner
            {
                ParkingSpaceNumber = parking.ParkingSpaceNumber,
                LicensePlate = parking.LicensePlate,
                StartTime = DateTime.Now,
                Available = false,
                ParkingStructureLevel = parking.ParkingStructureLevel
            };
            //store data

            return parking.StartTime;
        }

        public void RemoveCar()
        {

        }


    }
}
