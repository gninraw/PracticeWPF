using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Model
{
    public class Coffee
    {
        public int CoffeeId { get; set; }
        public string CoffeeName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int StockAmout { get; set; }
        public DateTime FirstAddedTime { get; set; }
        public int ImageId { get; set; }
    }
}
