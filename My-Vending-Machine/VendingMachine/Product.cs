using System;
using System.Collections.Generic;
using System.Text;
using My_Vending_Machine.VendingMachine;

namespace My_Vending_Machine.VendingMachine
{
    public abstract class Product
    {
        int id = 0;

        public string Name { get; set; }
        public int Price { get; set; }
        public int Id { get { return id; } set { } }

        //constructor
        public Product(string name, int price)
        {
            Id = Id++;
            Name = name;
            Price = price;
        }

        //returns bool dependent on if the money pool contains sufficient funds.

        public bool Purchase(Product product, VM vm)
        {
            bool canAfford;
            int moneyPool = vm.GetCredit();

            if (moneyPool >= product.Price)
            {
                canAfford = true;
            }
            else
            {
                canAfford = false;
            }

            return canAfford;
        }

        //abstract methods used in derived classes

        public abstract string Use();

        public abstract string Examine();

    }
}
