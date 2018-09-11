using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.ParkingStructure
{
    public enum ParkingType
    {
        General,
        Valet,
        FrequentFlyer
    }

    public class ParkingStructure1
    {
        //constructors
        public List<ParkingLevell> parkingLevells { get; set; }

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
