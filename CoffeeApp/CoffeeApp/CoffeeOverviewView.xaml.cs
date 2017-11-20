using CoffeeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoffeeApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CoffeeOverviewView : Window
    {
        public List<Coffee> Items { get; set; }

        public CoffeeOverviewView()
        {
            InitializeComponent();
            Items = MakeCoffeeLIst();
            this.MyListView.ItemsSource = Items;
        }

        public List<Coffee> MakeCoffeeLIst()
        {
            String[] names = { "라떼", "아메리카노", "모카", "에스프레소", "카푸치노" }; 

            List<Coffee> items = new List<Coffee>();
            

            for (int i = 0; i < 5; i++)
            {
                Coffee c = new Coffee();
                c.CoffeeId = i;
                c.CoffeeName = names[i];
                c.Description = i + " Coffee DesCription";
                c.StockAmout = i * 10;
                c.FirstAddedTime = DateTime.Now;
                c.ImageId = i;
                items.Add(c);
            }

            return items;
        }

        private int index=0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //index %= 5;
            if (index >= 5) index = 0;
            Coffee c = Items[index];
            ViewCoffeeInfo(c);
            index++;
        }

        public void ViewCoffeeInfo(Coffee c)
        {
            this.lab_name.Content = c.CoffeeName;
            this.lab_id.Content = c.CoffeeId;
            this.lab_desc.Content = c.Description;
            this.lab_amount.Content = c.StockAmout;
            this.lab_time.Content = c.FirstAddedTime.ToString();

            
            string filename = "coffee" + c.CoffeeId + ".jpg";
            Uri uri = new Uri("/CoffeeApp;component/Images/" + filename, UriKind.Relative);
            BitmapImage img_src = new BitmapImage(uri);
            this.img_thumb.Source = img_src;
        }

        private void MyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selected_target = e.AddedItems[0];

            if (selected_target is Coffee)
            {
                Coffee c = selected_target as Coffee;
                ViewCoffeeInfo(c);
            }

        }
    }
}
