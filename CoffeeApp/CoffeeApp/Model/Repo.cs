using CoffeeApp.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CoffeeApp.Model
{
    public class Repo : BindingBase
    {
        private Coffee _currentcoffee;
        public Coffee CurrentCoffee
        {
            get
            {
                return _currentcoffee;
            }
            set
            {
                _currentcoffee = value;
                RaisePropertyChanged("CurrentCoffee");
            }
        }
        public ObservableCollection<Coffee> Items { get; set; }

        public Repo()
        {
            this.Items = MakeCoffeeLIst();
        }

        public ObservableCollection<Coffee> MakeCoffeeLIst()
        {
            String[] names = { "라떼", "아메리카노", "모카", "에스프레소", "카푸치노" };

            ObservableCollection<Coffee> items = new ObservableCollection<Coffee>();
            for (int i = 0; i < 5; i++)
            {
                Coffee c = new Coffee();
                c.CoffeeId = i;
                c.CoffeeName = names[i];
                c.Description = i + " Coffee DesCription";
                c.StockAmount = i * 10;
                c.FirstAddedTime = DateTime.Now;
                c.ImageId = i;

                string filename = "coffee" + i + ".jpg";
                Uri uri = new Uri("/CoffeeApp;component/Images/" + filename, UriKind.Relative);
                c.Image = new BitmapImage(uri);

                items.Add(c);
            }

            return items;
        }
    }
}
