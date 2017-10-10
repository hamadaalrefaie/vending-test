using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum BeverageType
{
    Imsdal = 1,
    Pepsi,
    Water,
    Juice,
    Julmust,
}

enum Size
{
    Small = 1,
    Medium,
    Large,
}

namespace VendingMachine.Models
{
    class Beverage : MenuItem
    {
        public Beverage(BeverageType beverageType, Size size)
        {
            switch (beverageType)
            {
                case BeverageType.Imsdal:
                    {
                        this.Name = "Imsdal ";
                        switch (size)
                        {
                            case Size.Small:
                                this.Price = 3;
                                break;
                            case Size.Medium:
                                this.Price = 4;
                                break;
                            case Size.Large:
                                this.Price = 5;
                                break;
                        }
                    }
                    break;

                case BeverageType.Pepsi:
                    {
                        this.Name = "Pepsi  ";
                        switch (size)
                        {
                            case Size.Small:
                                this.Price = 3;
                                break;
                            case Size.Medium:
                                this.Price = 4;
                                break;
                            case Size.Large:
                                this.Price = 5;
                                break;
                        }
                    }
                    break;

                case BeverageType.Water:
                    {
                        this.Name = "Water  ";
                        switch (size)
                        {
                            case Size.Small:
                                this.Price = 2;
                                break;
                            case Size.Medium:
                                this.Price = 3;
                                break;
                            case Size.Large:
                                this.Price = 4;
                                break;
                        }
                    }
                    break;

                case BeverageType.Juice:
                    {
                        this.Name = "Juice  ";
                        switch (size)
                        {
                            case Size.Small:
                                this.Price = 1;
                                break;
                            case Size.Medium:
                                this.Price = 2;
                                break;
                            case Size.Large:
                                this.Price = 3;
                                break;
                        }
                    }
                    break;

                case BeverageType.Julmust:
                    {

                        this.Name = "Julmust";
                        switch (size)
                        {
                            case Size.Small:
                                this.Price = 4;
                                break;
                            case Size.Medium:
                                this.Price = 5;
                                break;
                            case Size.Large:
                                this.Price = 6;
                                break;
                        }
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"| ${Price}";
        }
    }
}
