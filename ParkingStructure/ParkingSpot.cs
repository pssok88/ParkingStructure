using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.ParkingStructure
{

    public class ParkingSpot
    {
        public ParkingType GetParkingType { get; set; }
        public string ParkingSpotNumber { get; set; }
        public string ParkingStructureLevel { get; set; }
        public double HoursParked { get; set; }
        public DateTime StartTime { get; set; }
        public bool Available { get; set; }
    }
}
