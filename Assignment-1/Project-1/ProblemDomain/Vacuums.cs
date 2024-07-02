using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.ProblemDomain
{
    internal class Vacuums : Appliance
    {
        private string _grade;
        private string _BatteryVoltage;

        public Vacuums(long itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, string batteryVoltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _grade = grade;
            _BatteryVoltage = batteryVoltage;
        }

        public string Grade
        {
            get { return _grade; } 
            set { _grade = value; }
        }

        public string BatteryVoltage
        {
            get { return _BatteryVoltage; }
            set { _BatteryVoltage = value; }
        }

        public override string ToString()
        {
            return $"ItemNumber: {ItemNum}\n" +
                $"Brand: {Brand}\n" +
                $"Quantity: {Quantity}\n" +
                $"Wattage: {Wattage}\n" +
                $"Color: {Color}\n" +
                $"Price: {Price}\n" +
                $"Grade: {Grade}\n" +
                $"Battery Voltage: {BatteryVoltage}\n";
        }

        public override string formatForFile()
        {
            return $"{ItemNum};{Brand};{Quantity};{Wattage};{Color};{Price};{Grade};{BatteryVoltage};";

        }
    }
}