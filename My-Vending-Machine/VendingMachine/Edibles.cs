using System;
using System.Collections.Generic;
using System.Text;

namespace My_Vending_Machine.VendingMachine
{
    public class Edibles : Product
    {
        string Info { get; set; }
        string Usage { get; set; }
        string Type { get; set; }

        //derived class constructor with added variables
        public Edibles(string name, int price, string info, string use, string type) : base(name, price)
        {
            Info = info;
            Usage = use;
            Type = type;
        }

        //override string methods 

        public override string Use()
        {
            return $"After purchasing {Name} {Type} from My Vending Machine {Usage}";
        }

        public override string Examine()
        {
            return $"Product Describtion of {Name} {Type} Reads: {Info}";
        }
    }
}
