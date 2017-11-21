using CoffeeApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeApp.ViewModel
{
    public class MyViewModel
    {
        public MyViewModel()
        {
            Items = MakeCoffeeLIst();
        }

        public List<Coffee> Items { get; set; }
        public Coffee CurrentCoffee { get; set; }

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
    }
}
