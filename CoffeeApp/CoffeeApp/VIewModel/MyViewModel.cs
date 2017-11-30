using CoffeeApp.Model;
using CoffeeApp.Utility;
using CoffeeApp.View;
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
    public class MyViewModel : BindingBase
    {
        public Repo Repository { get; set; }

        public ICommand BtnClickCommand { get; set; }
        public ICommand SelectionChangeCommand { get; set; }

        public Grid ContentGrid { get; private set; }

        public MyViewModel()
        {
            Repository = new Repo();

           
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
                Repository.CurrentCoffee = target as Coffee;
            }

            

            //MessageBox.Show("SelectionChange @ ViewModel");
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
            //return false;
        }

        private void WhenClick(object obj)
        {
            if(Repository.CurrentCoffee != null)
            {
                CoffeeDetailView v = new CoffeeDetailView();
                PopupViewModel vm = v.DataContext as PopupViewModel;
                vm.SetCoffee(Repository);
                v.Show();
                //MessageBox.Show("Button Click @ ViewModel");
            }
        }

        
    }
}
