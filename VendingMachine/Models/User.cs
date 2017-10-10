using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    class User
    {
        public int Wallet { get; set; }

        public User(int wallet)
        {
            this.Wallet = wallet;
        }

    }
}
