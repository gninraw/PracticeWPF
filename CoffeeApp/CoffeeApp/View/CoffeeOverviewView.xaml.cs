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
