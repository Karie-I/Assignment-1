using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.ProblemDomain
{
    internal class Refrigerator : Appliance
    {
        private string _NumberOfDoors;
        private string _Height;
        private string _Width;

        public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, double price, string numberOfDoors, string height, string width) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _NumberOfDoors = numberOfDoors;
            _Height = height;
            _Width = width;
        }

        public string DoorNum
        {
            get { return _NumberOfDoors; }
            set { _NumberOfDoors = value; }
        }

        public string Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public string Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        public override string ToString()
        {
            return $"ItemNumber: {ItemNum}\n" +
                $"Brand: {Brand}\n" +
                $"Quantity: {Quantity}\n" +
                $"Wattage: {Wattage}\n" +
                $"Color: {Color}\n" +
                $"Price: {Price}\n" +
                $"DoorNumber: {DoorNum}\n" +
                $"Height: {Height}\n" +
                $"Width: {Width}\n";
        }

        public override string formatForFile()
        {
            return $"{ItemNum};{Brand};{Quantity};{Wattage};{Color};{Price};{DoorNum};{Height};{Width};";

        }
    }
}
