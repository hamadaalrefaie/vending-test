 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    class MenuItem
    {

        public string Name { get; set; }
        public int Price { get; set; }

        public virtual string ToString()
        {
            return $"{Name}".ToString();
        }
    }
}
