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

    public class ParkingSpot : ParkingLevell
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

    public enum ParkingType
    {
        General,
        Valet,
        FrequentFlyer

    }
    //public enum PARKING_SPOT_TYPES
    //{
    //    GENERAL,
    //    VALET,
    //    FREQUENT_FLYER
    //}

    public class ParkingLevell
    {
        public int ParkingStructureLevel { get; set; }
        public List<ParkingSpotOwner> GeneralParkingSpotOwners { get; set; }
        public List<ParkingSpotOwner> ValetParkingSpotOwners { get; set; }
        public List<ParkingSpotOwner> FrequentFlyerParkingSpotOwners { get; set; }

        public DateTime AddCar(ParkingType parkingType, ParkingSpotOwner parking)
        {
            ParkingSpotOwner parkingSpot = new ParkingSpotOwner
            {
                ParkingSpaceNumber = parking.ParkingSpaceNumber,
                LicensePlate = parking.LicensePlate,
                StartTime = DateTime.Now,
                Available = false,
                ParkingStructureLevel = parking.ParkingStructureLevel,
                Name = parking.Name
                //ParkingSpot.ParkingType = parking.Type
            };

            switch (parkingType)
            {
                case ParkingType.General:
                    GeneralParkingSpotOwners.Add(parkingSpot);
                    break;
                case ParkingType.Valet:
                    ValetParkingSpotOwners.Add(parkingSpot);
                    break;
                case ParkingType.FrequentFlyer:
                    FrequentFlyerParkingSpotOwners.Add(parkingSpot);
                    break;
                default:
                    throw new Exception("incorrect parking spot type");
            }

            //store data somewhere

            return parking.StartTime; //returning ticket with start time
        }

        public void RemoveCar(ParkingSpotOwner parking)
        {

        }


        //Parking structure has composition of levels
        //Each level has a composition of parking spots
        //A parking spot can be of three types
        //Each parking spot should have a price
        //Each parking spot should track if a car is parked or is available
        //Some spots may require a membership
        //Each parking spot should store the driver detail and car detail
        //Create an interface with functions AddCar, RemoveCar…

        //Class ParkingStructure has list of floors


        // non-optimized way
        //public class GeneralParkingSpot
        //{
        //    public double Price { get; set; }
        //    public string ParkingSpotNumber { get; set; }
        //    public Driver Driver { get; set; }


        //}
        //public class ValetParkingSpot
        //{
        //    public double Price { get; set; }
        //    public string ParkingSpotNumber { get; set; }
        //    public Driver Driver { get; set; }


        //}
        //public class FrequentFlyerParkingSpot
        //{
        //    public double Price { get; set; }
        //    public string ParkingSpotNumber { get; set; }
        //    public Driver Driver { get; set; }


        //}

        //public class ParkingLevel
        //{
        //    public List<GeneralParkingSpot> GeneralParkingSpots { get; set; }
        //    public List<ValetParkingSpot> ValetParkingSpots { get; set; }
        //    public List<FrequentFlyerParkingSpot> FrequentFlyerParkingSpots { get; set; }

        //    public DateTime AddCar()
        //    {
        //        return DateTime.Now;
        //    }
        //}

        //public class ParkingStructure
        //{
        //    public List<ParkingLevel> ParkingLevels { get; set; }
        //}

        //public class Driver
        //{
        //    public string License { get; set; }
        //    public string Name { get; set; }
        //}

    }
}
