using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    class Menu
    {
        Inventory inv = new Inventory();
        User user = new User(20);
        int tempMoney = 20;

        int userAction = 0;
        
        public void StartProgram()
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"You have ${tempMoney} more to spend\n");
                Console.WriteLine("1. Buy Drinks");
                Console.WriteLine("2. Buy Snacks");
                Console.WriteLine("3. List items");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Quit");
                if(int.TryParse(Console.ReadLine(), out userAction))
                {
                    switch (userAction)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Console.WriteLine($"Enter which item you would like to purchase, prices vary depending on size\n\nDrinks: You currently have ${tempMoney}\n" +
                                                  "\n1. Imsdal,  S:$3 M:$4 L:$5\n2. Pepsi,   S:$3 M:$4 L:$5\n3. Water,   S:$2 M:$3 L:$4\n4. Juice,   S:$1 M:$2 L:$3\n5. Julmust, S:$4 M:$5 L:$6\n\n6: Exit to menu");
                                int userInput = int.Parse(Console.ReadLine());
                                if(userInput > 6 || userInput == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You can only choose from the available options");
                                    Console.ReadKey();
                                    break;
                                }
                                else if(userInput == 6)
                                {
                                    break;
                                }
                                BeverageType beverageType;
                                beverageType = (BeverageType)userInput;

                                Console.Clear();
                                Console.WriteLine($"Enter size of the {beverageType}\n1. Small\n2. Medium\n3. Large\n\n4: Exit to menu");
                                int size = int.Parse(Console.ReadLine());
                                if(size > 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You can only choose from the available sizes");
                                    Console.ReadKey();
                                    break;
                                }
                                else if(size == 4)
                                {
                                    break;
                                }
                                Size beverageSize;
                                beverageSize = (Size)size;

                                inv.AddBeveragesToTempCart(beverageType, beverageSize);

                                foreach (MenuItem item in inv.TemporaryCart)
                                {
                                    if (item is Beverage)
                                    {
                                        if (item.Price > tempMoney)
                                        {
                                            Console.WriteLine("Sorry that item is too expensive\nPress any key to continue");
                                            Console.ReadKey();
                                            break;
                                        }
                                        if (item.Price <= tempMoney)
                                        {
                                            inv.BuyDrinks(beverageType, beverageSize);
                                            tempMoney -= item.Price;
                                        }
                                        
                                    }
                                }
                                inv.TemporaryCart.Clear();
                            }
                            break;
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine($"Enter which item you would like to purchase\nSnacks: You currently have ${tempMoney}\n" +
                                                  "\n1. Chips      $2\n2. Snickers   $1\n3. Bounty     $3\n4. Kexchoklad $5\n5. Bilar      $2\n\n6: Exit to menu");
                                int userInput = int.Parse(Console.ReadLine());
                                if(userInput > 6 || userInput == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You can only choose from the available options");
                                    Console.ReadKey();
                                    break;
                                }
                                else if (userInput == 6)
                                {
                                    break;
                                }
                                SnacksType snacksType;
                                snacksType = (SnacksType)userInput;

                                inv.AddSnackToTempCart(snacksType);

                                foreach (MenuItem item in inv.TemporaryCart)
                                {
                                    if (item is Snack)
                                    {
                                        if (item.Price > tempMoney)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Sorry that item is too expensive\nPress any key to continue");
                                            Console.ReadKey();
                                            break;
                                        }
                                        if (item.Price <= tempMoney)
                                        {
                                            inv.BuySnacks(snacksType);
                                            tempMoney -= item.Price;
                                        }

                                    }
                                }
                                inv.TemporaryCart.Clear();
                            }
                            break;
                        case 3:
                            {
                                Console.Clear();
                                inv.ShowPersonalInventory();
                                Console.ReadKey();
                            }
                            break;
                        case 4:
                            {
                                Console.Clear();
                                inv.Checkout();
                                Console.WriteLine($"Wallet: ${user.Wallet}\n\n1: Checkout\n2: Cancel checkout\n3: Clear shopping cart");
                                string userAction = Console.ReadLine();

                                switch (userAction)
                                {
                                    case "1":
                                        {
                                            user.Wallet -= inv.Total;
                                            foreach (MenuItem i in inv.ShoppingCart)
                                            {
                                                inv.PersonalInventory.Add(i);
                                            }
                                            inv.ShoppingCart.Clear();
                                            inv.Total = 0;
                                            Console.Clear();
                                            Console.WriteLine("Thank you for your purchase!");
                                            Thread.Sleep(2000);
                                        }
                                        break;
                                    case "2":
                                        break;
                                    case "3":
                                        {
                                            inv.ShoppingCart.Clear();
                                            inv.TemporaryCart.Clear();
                                            inv.Total = 0;
                                            //tempMoney = 20;
                                            //user.Wallet = 20;
                                        }
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("There is no other option than those displayed\nPress any key to retry");
                                        Console.Read();
                                        break;
                                }

                            }
                            break;
                    }
                }

            } while (userAction != 5);
        }

    }
}
