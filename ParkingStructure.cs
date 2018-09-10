using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.ParkingStructure
{
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
    //    use composition
    //      public class ParkingLevel
    //    {
    //        list<ParkingSpot> ParkingSpots { gets; set; }
    //    }


    public class Driver
    {
        public string LicensePlate { get; set; }
        public string Name { get; set; }
    }

    public class GeneralParking
    {
        public double ParkingPrice { get; set; }
        public string ParkingSpotNumber { get; set; }
        public Driver Driver { get; set; }
    }

    public class ValetParking
    {
        public double ParkingPrice { get; set; }
        public string ParkingSpotNumber { get; set; }
        public Driver Driver { get; set; }
    }

    public class FrequentFlyerParking
    {
        public double ParkingPrice { get; set; }
        public string ParkingSpotNumber { get; set; }
        public string FrequentFlyerAccount { get; set; }
        public Driver Driver { get; set; }
    }

    public enum ParkingType
    {
        General,
        Valet,
        FrequentFlyer

    }

    public class ParkingSpot 
    {
        public ParkingType GetParkingType { get; set; } 
        public string ParkingSpotNumber { get; set; }
        public string ParkingStructureLevel { get; set; }
        public double HoursParked { get; set; }
        public DateTime StartTime { get; set; }
        public bool Available { get; set; }
    }

    public class ParkingStructure1
    {
        //constructors
        public List<ParkingLevell> parkingLevells { get; set; }

    }

    public class ParkingLevell
    {
        public string ParkingStructureLevel { get; set; }
        public List<Driver> GeneralParkingSpotOwners { get; set; }
        public List<Driver> ValetParkingSpotOwners { get; set; }
        public List<Driver> FrequentFlyerParkingSpotOwners { get; set; }
        public List<ParkingSpot> ParkingSpots { get; set; }
        public List<ParkingLevell> ParkingLevells { get; set; }

        public DateTime AddCar(ParkingType parkingType, Driver driver, ParkingSpot parkingSpot)
        {
            //Driver parkingSpot = new Driver
            //{
            //    ParkingSpaceNumber = parking.ParkingSpaceNumber,
            //    LicensePlate = parking.LicensePlate,
            //    StartTime = DateTime.Now,
            //    Available = false,
            //    ParkingStructureLevel = parking.ParkingStructureLevel,
            //    Name = parking.Name
            //    //ParkingSpot.ParkingType = parking.Type
            //};

            Driver driverInfo = new Driver
            {
                LicensePlate = driver.LicensePlate,
                Name = driver.Name
            };

            ParkingSpot parking = new ParkingSpot
            {
                GetParkingType = parkingSpot.GetParkingType,
                ParkingSpotNumber = parkingSpot.ParkingSpotNumber,
                ParkingStructureLevel = parkingSpot.ParkingStructureLevel,
                HoursParked = parkingSpot.HoursParked,
                StartTime = DateTime.Now,
                Available = false
            };


            List<ParkingSpot> parkingSpots = new List<ParkingSpot>();


           parkingSpots.Add(parking);

            switch (parkingType)
            {
                case ParkingType.General:
                    List<Driver> GeneralParkingSpotOwners = new List<Driver>();
                    GeneralParkingSpotOwners.Add(driverInfo);
                    break;
                case ParkingType.Valet:
                    List<Driver> ValetParkingSpotOwners = new List<Driver>();
                    ValetParkingSpotOwners.Add(driverInfo);
                    break;
                case ParkingType.FrequentFlyer:
                    List<Driver> FrequentFlyerParkingSpotOwners = new List<Driver>();
                    FrequentFlyerParkingSpotOwners.Add(driverInfo);
                    break;
                default:
                    throw new Exception("incorrect parking spot type");
            }

            //store data somewhere

            return DateTime.Now; //returning ticket with start time
        }

        public void RemoveCar(ParkingType parkingType, Driver parking, ParkingSpot parkingSpot)
        {
            switch (parkingType)
            {
                case ParkingType.General:
                    // GeneralParkingSpotOwners.Find(x => x.LicensePlate == parking.LicensePlate);
                    GeneralParkingSpotOwners.Remove(parking);
                    break;
                case ParkingType.Valet:
                    ValetParkingSpotOwners.Remove(parking);
                    break;
                case ParkingType.FrequentFlyer:
                    FrequentFlyerParkingSpotOwners.Remove(parking);
                    break;
                default:
                    throw new Exception("Car not found");
            }

            ParkingSpots.Remove(parkingSpot);

        }

        public double ParkingCost(ParkingType parkingType, ParkingSpot parkingSpot)
        {
            var minutesParked = (DateTime.Now - parkingSpot.StartTime).Minutes;
            double totalPrice = 0;
            switch (parkingType)
            {
                case ParkingType.General:
                    GeneralParking generalParking = new GeneralParking();
                    totalPrice = (minutesParked/60) * generalParking.ParkingPrice; 
                    break;
                case ParkingType.Valet:
                    ValetParking valetParking = new ValetParking();
                    totalPrice = (minutesParked/60) * valetParking.ParkingPrice;
                    break;
                case ParkingType.FrequentFlyer:
                    FrequentFlyerParking frequentFlyerParking = new FrequentFlyerParking();
                    totalPrice = (minutesParked / 60) * frequentFlyerParking.ParkingPrice;
                    break;
                default:
                    throw new Exception("Time error");
            };

            return totalPrice;
        }

        
        public double ParkingCost(string parkingSpace, string parkingLevel)
        {
            var parkingDetails = ParkingSpots.Find(x => x.ParkingSpotNumber == parkingSpace && x.ParkingStructureLevel == parkingLevel);
            var minutesParked = (DateTime.Now - parkingDetails.StartTime).TotalMinutes;
            double totalCost = 0;

            switch (parkingDetails.GetParkingType)
            {
                case ParkingType.General:
                    GeneralParking generalParking = new GeneralParking();
                    totalCost = (minutesParked / 60) * generalParking.ParkingPrice;
                    break;
                case ParkingType.Valet:
                    ValetParking valetParking = new ValetParking();
                    totalCost = (minutesParked / 60) * valetParking.ParkingPrice;
                    break;
                case ParkingType.FrequentFlyer:
                    FrequentFlyerParking frequentFlyerParking = new FrequentFlyerParking();
                    totalCost = (minutesParked / 60) * frequentFlyerParking.ParkingPrice;
                    break;
                default:
                    throw new Exception("Time error");
            }

            return totalCost;
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
