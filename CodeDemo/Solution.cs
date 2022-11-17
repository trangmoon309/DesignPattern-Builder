using CodeDemo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDemo3
{
    #region Product
    public class House
    {
        public string Color { get; set; }

        public int Area { get; set; }

        public int NumberOfFloor { get; set; }

        public int NumberOfBeds { get; set; }

        public Garage Garage { get; set; }

        public Garden Garden { get; set; }

        public SwimmingPool SwimmingPool { get; set; }
    }

    public class Garage
    {
        public int GarageArea { get; set; }

        public string Location { get; set; }

        public Garage()
        {

        }

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

        public Garden()
        {
            GargenArea = 0;
            NumberOfTree = 0;
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
        public SwimmingPool()
        {

        }

    }

    #endregion Product

    public class HouseBuilder
    {
        private House House { get; set; }

        public HouseBuilder()
        {
            House = new House();
        }

        public HouseBuilder WithColor(string color)
        {
            House.Color = color;
            return this;
        }

        public HouseBuilder WithArea(int area)
        {
            House.Area = area;
            return this;
        }

        public HouseBuilder WithNumberOfFloor(int numberOfFloor)
        {
            House.NumberOfFloor = numberOfFloor;
            return this;
        }

        public HouseBuilder WithNumberOfBeds(int numberOfBeds)
        {
            House.NumberOfBeds = numberOfBeds;
            return this;
        }

        public HouseGarageBuilder AddGarage()
        {
            return new HouseGarageBuilder(this, House); 
        }

        public HouseGardenBuilder AddGarden()
        {
            return new HouseGardenBuilder(this, House);
        }

        public HouseSwimmingPoolBuilder AddSwimmingPool()
        {
            return new HouseSwimmingPoolBuilder(this, House);
        }

        public House Build()
        {
            return House;
        }
    }

    public class HouseGarageBuilder
    {
        private Garage Garage { get; set; } = new Garage();
        private House House { get; set; } = new House();
        private HouseBuilder HouseBuilder { get; set; } = new HouseBuilder();

        public HouseGarageBuilder()
        {
            Garage = new Garage();
        }

        public HouseGarageBuilder(HouseBuilder parentBuilder, House house)
        {
            House = house;
            HouseBuilder = parentBuilder;
        }

        public HouseGarageBuilder WithLocation(string location)
        {
            Garage.Location = location;
            return this;
        }

        public HouseGarageBuilder WithArea(int area)
        {
            Garage.GarageArea = area;
            return this;
        }

        public HouseBuilder Build()
        {
            House.Garage = new Garage();
            House.Garage = Garage;
            return HouseBuilder;
        }
    }

    public class HouseGardenBuilder
    {
        private Garden Garden { get; set; }
        private House House { get; set; } = new House();
        private HouseBuilder HouseBuilder { get; set; } = new HouseBuilder();

        public HouseGardenBuilder()
        {
            Garden = new Garden();
        }

        public HouseGardenBuilder(HouseBuilder parentBuilder, House house)
        {
            Garden = new Garden();
            House = house;
            HouseBuilder = parentBuilder;
        }

        public HouseGardenBuilder WithArea(int area)
        {
            Garden.GargenArea = area;
            return this;
        }

        public HouseGardenBuilder WithNumberOfTree(int numberOfTree)
        {
            Garden.NumberOfTree = numberOfTree;
            return this;
        }

        public HouseBuilder Build()
        {
            House.Garden = new Garden();
            House.Garden = Garden;
            return HouseBuilder;
        }
    }

    public class HouseSwimmingPoolBuilder
    {
        private SwimmingPool SwimmingPool { get; set; }
        private House House { get; set; } = new House();
        private HouseBuilder HouseBuilder { get; set; } = new HouseBuilder();

        public HouseSwimmingPoolBuilder()
        {
            SwimmingPool = new SwimmingPool();
        }

        public HouseSwimmingPoolBuilder(HouseBuilder parentBuilder, House house)
        {
            SwimmingPool = new SwimmingPool();
            House = house;
            HouseBuilder = parentBuilder;
        }

        public HouseSwimmingPoolBuilder WithLocation(string location)
        {
            SwimmingPool.Location = location;
            return this;
        }

        public HouseSwimmingPoolBuilder WithArea(int area)
        {
            SwimmingPool.PoolArea = area;
            return this;
        }

        public HouseBuilder Build()
        {
            House.SwimmingPool = SwimmingPool;
            return HouseBuilder;
        }
    }
}
