using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.ProblemDomain
{
    internal class Dishwashers : Appliance
    {
        private string _SoundRating;
        private string _feature;

        public Dishwashers(long itemNumber, string brand, int quantity, double wattage, string color, double price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _SoundRating = soundRating;
            _feature = feature;
        }

        public string SoundRating
        {

            get { return _SoundRating; }
            set { _SoundRating = value; }
        }

        public string Feature
        {
            get { return _feature; }
            set { _feature = value; }
        }

        public override string ToString()
        {
            return $"ItemNumber: {ItemNum}\n" +
                $"Brand: {Brand}\n" +
                $"Quantity: {Quantity}\n" +
                $"Wattage: {Wattage}\n" +
                $"Color: {Color}\n" +
                $"Price: {Price}\n" +
                $"Feature: {Feature}\n" +
                $"Sound Rating: {SoundRating}\n";
        }

        public override string formatForFile()
        {
            return $"{ItemNum};{Brand};{Quantity};{Wattage};{Color};{Price};{Feature};{SoundRating};";

        }
    }
}