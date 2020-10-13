using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_Vending_Machine.VendingMachine
{
    class Drinks : Product
    {
        string Info { get; set; }
        string Usage { get; set; }

        //constructor for variables

        public Drinks(string name, int price, string info, string use) : base(name, price)
        {
            Info = info;
            Usage = use;
        }

        //override string methods 

        public override string Use()
        {
            return $"After recieving the {Name} from the vending machine you {Usage}";
        }

        public override string Examine()
        {
            return $"While you examine your {Name} you decide to take a moment to read the description. It reads: {Info}";
        }
    }
}
