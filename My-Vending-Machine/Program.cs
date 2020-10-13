using My_Vending_Machine.VendingMachine;
using System;

namespace My_Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            VMinterface vmi = new VMinterface();

            vmi.RunVM();


        }
    }
}
