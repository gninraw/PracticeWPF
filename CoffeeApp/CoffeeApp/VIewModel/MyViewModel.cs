using CoffeeApp.Model;
using CoffeeApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CoffeeApp.ViewModel
{
    public class MyViewModel : INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        
        public List<Coffee> Items { get; set; }

        private Coffee _currentcoffee;
        public Coffee CurrentCoffee {
            get { return _currentcoffee; }
            set {
                _currentcoffee = value;
                RaisePropertyChanged("CurrentCoffee");
            }
        }

        public ICommand BtnClickCommand { get; set; }
        public ICommand SelectionChangeCommand { get; set; }

        public MyViewModel()
        {
            Items = MakeCoffeeLIst();
            BtnClickCommand = new CustomCommand(WhenClick, CanClick);

            SelectionChangeCommand = 
                new CustomCommand(SelectionChange, 
                                                        CanSelectionChange);
        }

        private bool CanSelectionChange(object obj)
        {
            return true;
        }

        private void SelectionChange(object obj)
        {
            ListView view = obj as ListView;

            object target = view.SelectedItem;
            if(target is Coffee)
            {
                CurrentCoffee = target as Coffee;
            }

            

            MessageBox.Show("SelectionChange @ ViewModel");
            // 선택된 녀석을 얻는방법?
            //object selected_target = e.AddedItems[0];

            //if (selected_target is Coffee)
            //{
            //    Coffee c = selected_target as Coffee;
            //    ViewCoffeeInfo(c);
            //}
        }

        private bool CanClick(object obj)
        {
            return true;
        }

        private void WhenClick(object obj)
        {
            MessageBox.Show("Button Click @ ViewModel");
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

                string filename = "coffee" + i + ".jpg";
                Uri uri = new Uri("/CoffeeApp;component/Images/" + filename, UriKind.Relative);
                c.Image = new BitmapImage(uri);

                items.Add(c);
            }

            return items;
        }
    }
}
