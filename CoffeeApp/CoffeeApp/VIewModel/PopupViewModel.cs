using CoffeeApp.Model;
using CoffeeApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CoffeeApp.ViewModel
{
    public class PopupViewModel : INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Repo Repository { get; private set; }
        #endregion

        //public Coffee CurrentCoffee { get; set; }
        public Coffee OriginalCoffee { get; set; }

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
        //CurrentCoffee = new Coffee();

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }



        public PopupViewModel()
        {
            SaveCommand = new CustomCommand(Save, CanSave);
            DeleteCommand = new CustomCommand(Delete, CanDelete);

        }

        private bool CanDelete(object obj)
        {
            return true;
        }

        private void Delete(object obj)
        {
            var coffee = Repository.CurrentCoffee;
            Repository.Items.Remove(coffee);
            Repository.CurrentCoffee = null;
            Window w = obj as Window;
            w.Close();
        }

        private bool CanSave(object obj)
        {
            return true;
        }

        private void Save(object obj)
        {
            Repository.CurrentCoffee = CurrentCoffee;

            Window w = obj as Window;
            w.Close();
        }

        public void SetCoffee(Repo r)
        {
            Repository = r;

            OriginalCoffee = r.CurrentCoffee;
            CurrentCoffee = r.CurrentCoffee.Clone() as Coffee;
        }
    }
}
