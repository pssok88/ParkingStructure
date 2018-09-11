using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.ParkingStructure
{
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

        public List<ParkingSpot> AddCar(ParkingType parkingType, Driver driver, ParkingSpot parkingSpot)
        {
            List<Driver> GeneralParkingSpotOwners = new List<Driver>();
            List<Driver> ValetParkingSpotOwners = new List<Driver>();
            List<Driver> FrequentFlyerParkingSpotOwners = new List<Driver>();
            List<ParkingSpot> parkingSpots = new List<ParkingSpot>();

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

            parkingSpots.Add(parking);
              

            switch (parkingType)
            {
                case ParkingType.General:
                    GeneralParkingSpotOwners.Add(driverInfo);
                    break;
                case ParkingType.Valet:
                    ValetParkingSpotOwners.Add(driverInfo);
                    break;
                case ParkingType.FrequentFlyer:
                    FrequentFlyerParkingSpotOwners.Add(driverInfo);
                    break;
                default:
                    throw new Exception("incorrect parking spot type");
            }

            //store data somewhere
            //var parkingList = new List<ParkingSpot>();
            //foreach (ParkingSpot p in parkingSpots)
            //{
            //     var eachElement = p;
            //    parkingList.Add(eachElement);
            //}
            return parkingSpots; //returning ticket with start time
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
            GeneralParking generalParking = new GeneralParking();
            ValetParking valetParking = new ValetParking();
            FrequentFlyerParking frequentFlyerParking = new FrequentFlyerParking();
            var minutesParked = (DateTime.Now - parkingSpot.StartTime).Minutes;
            double totalPrice = 0;
            switch (parkingType)
            {
                case ParkingType.General:
                    totalPrice = (minutesParked/60) * generalParking.ParkingPrice; 
                    break;
                case ParkingType.Valet:
                    totalPrice = (minutesParked/60) * valetParking.ParkingPrice;
                    break;
                case ParkingType.FrequentFlyer:
                    totalPrice = (minutesParked / 60) * frequentFlyerParking.ParkingPrice;
                    break;
                default:
                    throw new Exception("Time error");
            };

            return totalPrice;
        }

        
        public double ParkingCost(string parkingSpace, string parkingLevel)
        {
            GeneralParking generalParking = new GeneralParking();
            ValetParking valetParking = new ValetParking();
            FrequentFlyerParking frequentFlyerParking = new FrequentFlyerParking();
            var parkingDetails = ParkingSpots.Find(x => x.ParkingSpotNumber == parkingSpace && x.ParkingStructureLevel == parkingLevel);
            var minutesParked = (DateTime.Now - parkingDetails.StartTime).TotalMinutes;
            double totalCost = 0;

            switch (parkingDetails.GetParkingType)
            {
                case ParkingType.General:
                    totalCost = (minutesParked / 60) * generalParking.ParkingPrice;
                    break;
                case ParkingType.Valet:
                    totalCost = (minutesParked / 60) * valetParking.ParkingPrice;
                    break;
                case ParkingType.FrequentFlyer:
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
