using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.ProblemDomain
{
    internal class Microwaves : Appliance
    {
        private string _capacity;
        private string _roomType;

        public Microwaves(long itemNumber, string brand, int quantity, double wattage, string color, double price, string capacity, string roomType) : base(itemNumber, brand, quantity, wattage, color, price) 
        {
            _capacity = capacity;
            _roomType = roomType;
        }

        public string Capacity
        {
            get { return  _capacity; }
            set { _capacity = value; }
        }

        public string RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }

        public override string ToString()
        {
            return $"ItemNumber: {ItemNum}\n" +
                $"Brand: {Brand}\n" +
                $"Quantity: {Quantity}\n" +
                $"Wattage: {Wattage}\n" +
                $"Color: {Color}\n" +
                $"Price: {Price}\n" +
                $"Capacity: {Capacity}\n" +
                $"Room Type: {RoomType}\n";
        }

        public override string formatForFile()
        {
            return $"{ItemNum};{Brand};{Quantity};{Wattage};{Color};{Price};{Capacity};{RoomType};";

        }
    }
}
