using CoffeeApp.Model;
using CoffeeApp.ViewModel;
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

namespace CoffeeApp.View
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CoffeeOverviewView : Window
    {


        public CoffeeOverviewView()
        {
            InitializeComponent();
            this.DataContext = new MyViewModel();
         }
        

        private int index=0;



        public void ViewCoffeeInfo(Coffee c)
        {
            MyViewModel vm = this.DataContext as MyViewModel;
            vm.CurrentCoffee = c;

            //this.lab_name.Content = c.CoffeeName;
            //this.lab_id.Content = c.CoffeeId;
            //this.lab_desc.Content = c.Description;
            //this.lab_amount.Content = c.StockAmout;
            //this.lab_time.Content = c.FirstAddedTime.ToString();

            //string filename = "coffee" + c.CoffeeId + ".jpg";
            //Uri uri = new Uri("/CoffeeApp;component/Images/" + filename, UriKind.Relative);
            //BitmapImage img_src = new BitmapImage(uri);
            //this.img_thumb.Source = img_src;
        }
    }
}
