using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDemo1
{
    public class House
    {
        public string Color { get; set; }

        public int Area { get; set; }

        public int NumberOfFloor { get; set; }

        public int NumberOfBeds { get; set; }
    }

    class HouseWithGarage : House
    {
        public int GarageArea { get; set; }

        public string Location { get; set; }
    }

    class HouseWithGarden : House
    {
        public int GargenArea { get; set; }
        public int NumberOfTree { get; set; }
    }

    class HouseWithSwimmingPool : House
    {
        public string Location { get; set; }

        public int PoolArea { get; set; }
    }

    // What about House with both SwimmingPool and Garage??
    class HouseWithSwimmingPoolAndGarage : House
    {
        public string GargareLocation { get; set; }
        public string SwimmingPoolLocation { get; set; }
        public int SwimmingPoolArea { get; set; }
        public int GarageArea { get; set; }
    }
}
