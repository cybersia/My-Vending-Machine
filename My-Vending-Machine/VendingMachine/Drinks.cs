﻿using System;
using System.Collections.Generic;
using System.Text;

namespace My_Vending_Machine.VendingMachine
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

        // override string methods 

        public override string Use()
        {
            return $"After purchasing {Name} from My Vending Machine {Usage}";
        }

        public override string Examine()
        {
            return $"Product Describtion of{Name} Reads: {Info}";
        }
    }
}
