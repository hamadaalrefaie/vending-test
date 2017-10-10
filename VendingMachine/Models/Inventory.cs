using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    class Inventory
    {

        public List<MenuItem> ShoppingCart { get; set; }
        public List<MenuItem> PersonalInventory { get; set; }
        public List<MenuItem> TemporaryCart { get; set; }
        public int Total { get; set; }

        public Inventory()
        {
            this.PersonalInventory = new List<MenuItem>();
            this.ShoppingCart = new List<MenuItem>();
            this.TemporaryCart = new List<MenuItem>();
        }

        public void ShowPersonalInventory()
        {
            string beverageString = "";
            string snackString = "";

            foreach (MenuItem i in PersonalInventory)
            {
                if (i is Beverage)
                {
                    beverageString += i.ToString() + Environment.NewLine;
                }
                else if (i is Snack)
                {
                    snackString += i.ToString() + Environment.NewLine;
                }
            }
            Console.WriteLine("Personal storage");
            Console.WriteLine($"Beverages: \n{beverageString}");
            Console.WriteLine($"Snacks: \n{snackString}");
        }

        public void Checkout()
        {
            string beverageString = "";
            string snackString = "";

            foreach (MenuItem item in ShoppingCart)
            {
                if (item is Beverage)
                {
                    beverageString += item.ToString() + Environment.NewLine;
                    Total += item.Price;
                }
                else if (item is Snack)
                {
                    snackString += item.ToString() + Environment.NewLine;
                    Total += item.Price;
                }

            }

            Console.WriteLine($"Beverages: \n{beverageString}");
            Console.WriteLine($"Snacks: \n{snackString}");
            Console.WriteLine($"Total: ${Total}");
        }

        public void BuyDrinks(BeverageType beverage, Size beverageSize)
        {
            ShoppingCart.Add(new Beverage(beverage, beverageSize));
        }

        public void BuySnacks(SnacksType snacks)
        {
            ShoppingCart.Add(new Snack(snacks));
        }

        public void AddBeveragesToTempCart(BeverageType beverage, Size beverageSize)
        {
            TemporaryCart.Add(new Beverage(beverage, beverageSize));
        }

        public void AddSnackToTempCart(SnacksType snacks)
        {
            TemporaryCart.Add(new Snack(snacks));
        }
    }
}
