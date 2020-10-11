using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_Vending_Machine.VendingMachine
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

        //overridden methods from base class. specialized to fit this class.
        public override string Use()
        {
            return $"After recieving the {Name} {Type} from the vending machine you {Usage}";
        }

        public override string Examine()
        {
            return $"While you examine your {Name} {Type} you decide to take a moment to read the description. It reads: {Info}";
        }
    }
}
