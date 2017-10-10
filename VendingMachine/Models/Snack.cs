using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum SnacksType
{
    Chips = 1,
    Snickers,
    Bounty,
    Kexchoklad,
    Bilar,
}

namespace VendingMachine.Models
{
    class Snack : MenuItem
    {

        public Snack(SnacksType snacksType)
        {
            switch (snacksType)
            {
                case SnacksType.Chips:
                    {
                        this.Name = "Chips     ";
                        this.Price = 2;
                    }
                    break;
                case SnacksType.Snickers:
                    {
                        this.Name = "Snickers  ";
                        this.Price = 1;
                    }
                    break;
                case SnacksType.Bounty:
                    {
                        this.Name = "Bounty    ";
                        this.Price = 3;
                    }
                    break;
                case SnacksType.Kexchoklad:
                    {
                        this.Name = "Kexchoklad";
                        this.Price = 5;
                    }
                    break;
                case SnacksType.Bilar:
                    {
                        this.Name = "Bilar     ";
                        this.Price = 2;
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
