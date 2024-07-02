using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    internal abstract class Appliance
    {
        private long _itemNumber;
        private string _brand;
        private int _quantity;
        private double _wattage;
        private string _color;
        private double _price;

        public Appliance(long itemNumber, string brand, int quantity, double wattage, string color, double price)
        {
            _itemNumber = itemNumber;
            _brand = brand;
            _quantity = quantity;
            _wattage = wattage;
            _color = color;
            _price = price;
        }

        public long ItemNum
        {
            get { return _itemNumber; }
            set { _itemNumber = value; }
        }

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }

        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public double Wattage
        {
            get { return _wattage; }
            set { _wattage = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public abstract string formatForFile();
    }
}
