using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CoffeeApp.Model
{
    public class Coffee : ICloneable
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
        public int StockAmount { get; set; }
        public DateTime FirstAddedTime { get; set; }
        public int ImageId { get; set; }
        public BitmapImage Image { get; set; }

        public object Clone()
        {
            Coffee c = new Coffee();

            c.CoffeeId = this.CoffeeId;

            c.CoffeeName = this.CoffeeName;
            c.Price = this.Price;
            c.Description = this.Description;
            c.StockAmount = this.StockAmount;
            c.FirstAddedTime = this.FirstAddedTime;
            c.ImageId = this.ImageId;

            //c.Image = this.Image;

            string filename = "coffee" + this.CoffeeId + ".jpg";
            Uri uri = new Uri("/CoffeeApp;component/Images/" + filename, UriKind.Relative);
            c.Image = new BitmapImage(uri);

            return c;
        }
    }
}
