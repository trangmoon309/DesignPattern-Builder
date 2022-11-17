using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDemo2
{
    public class House
    {
        public string Color { get; set; }

        public int Area { get; set; }

        public int NumberOfFloor { get; set; }

        public int NumberOfBeds { get; set; }

        public Garage Garage { get; set; }

        public Garden Garden { get; set; }

        public SwimmingPool SwimmingPool { get; set; }

        public House(string color, int area, int numberOfFloor, int numberOfBeds, Garage garage, Garden garden, SwimmingPool pool)
        {
            Color = color;
            Area = area;
            NumberOfFloor = numberOfFloor;
            NumberOfBeds = numberOfBeds;
            Garage = garage;
            Garden = garden;
        }

        public House(string color, int area, int numberOfFloor, int numberOfBeds, Garage garage)
        {

        }

        public House(string color, int area, int numberOfFloor, int numberOfBeds, Garden garden)
        {

        }

        public House(string color, int area, int numberOfFloor, int numberOfBeds, SwimmingPool pool)
        {

        }
    }

    public class Garage
    {
        public int GarageArea { get; set; }

        public string Location { get; set; }

        public Garage(int garageArea, string location)
        {
            GarageArea = garageArea;
            Location = location;
        }
    }

    public class Garden
    {
        public int GargenArea { get; set; }

        public int NumberOfTree { get; set; }

        public Garden(int gargenArea, int numberOfTree)
        {
            GargenArea = gargenArea;
            NumberOfTree = numberOfTree;
        }
    }

    public class SwimmingPool
    {
        public string Location { get; set; }

        public int PoolArea { get; set; }

        public SwimmingPool(string location, int poolArea)
        {
            Location = location;
            PoolArea = poolArea;
        }
    }
}
