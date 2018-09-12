using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.ParkingStructure
{
    public class ParkingLevel
    {
        public string ParkingStructureLevel { get; set; }
        public List<Driver> GeneralParkingSpotOwners { get; set; }
        public List<Driver> ValetParkingSpotOwners { get; set; }
        public List<Driver> FrequentFlyerParkingSpotOwners { get; set; }
        public List<ParkingSpot> ParkingSpots { get; set; }
        public List<ParkingLevel> ParkingLevels { get; set; }
        public Guid Id { get; set; }
        List<Driver> GPSpotOwners = new List<Driver>();
        List<Driver> VPSpotOwners = new List<Driver>();
        List<Driver> FFSpotOwners = new List<Driver>();

        public ParkingSpot AddCar(ParkingType parkingType, Driver driver, ParkingSpot parkingSpot)
        //public List<ParkingSpot> AddCar(ParkingType parkingType, Driver driver, ParkingSpot parkingSpot)
        {
            List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
            //var Id = Guid.NewGuid;

            Driver driverInfo = new Driver
            {
                LicensePlate = driver.LicensePlate,
                Name = driver.Name
            };

            ParkingSpot parking = new ParkingSpot
            {
                Id = Guid.NewGuid(),
                GetParkingType = parkingSpot.GetParkingType,
                ParkingSpotNumber = parkingSpot.ParkingSpotNumber,
                ParkingStructureLevel = parkingSpot.ParkingStructureLevel,
                HoursParked = parkingSpot.HoursParked,
                StartTime = DateTime.Now,
                Unavailable = true
            };

            parkingSpots.Add(parking);


            switch (parkingType)
            {
                case ParkingType.General:
                    GPSpotOwners.Add(driverInfo);
                    break;
                case ParkingType.Valet:
                    VPSpotOwners.Add(driverInfo);
                    break;
                case ParkingType.FrequentFlyer:
                    FFSpotOwners.Add(driverInfo);
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
            return parking; //returning ticket with start time
        }


        public void RemoveCar(ParkingType parkingType, Driver parking, ParkingSpot parkingSpot)
        {
            switch (parkingType)
            {
                case ParkingType.General:
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
            var hoursParked = ((DateTime.Now - parkingSpot.StartTime).Minutes)/60;
            double totalPrice = 0;
            switch (parkingType)
            {
                case ParkingType.General:
                    totalPrice = (hoursParked) * generalParking.ParkingPrice;
                    break;
                case ParkingType.Valet:
                    totalPrice = (hoursParked) * valetParking.ParkingPrice;
                    break;
                case ParkingType.FrequentFlyer:
                    totalPrice = (hoursParked) * frequentFlyerParking.ParkingPrice;
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


    }
}
