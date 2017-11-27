﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CoffeeApp.Model
{
    public class Coffee
    {
        public int CoffeeId { get; set; }

        private int _coffeevalue;
        public int CoffeeValue
        {
            get
            {
                return _coffeevalue;
            }
            set
            {
                _coffeevalue = value;
            }
        }
        // CoffeeValue = 3;
        // int val = CoffeeValue;
        public string CoffeeName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int StockAmout { get; set; }
        public DateTime FirstAddedTime { get; set; }
        public int ImageId { get; set; }
        public BitmapImage Image { get; set; }
    }
}
