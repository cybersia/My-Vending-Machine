using System;
using System.Collections.Generic;
using System.Text;
using My_Vending_Machine.VendingMachine;

namespace My_Vending_Machine.VendingMachine
{
    public class VM : IVM
    {
        //fields

        int[] moneyDenominator = new int[] { 1000, 500, 100, 50, 20, 10, 5, 1 };
        Product[] boughtProducts = new Product[0];
        Product[] productArr = new Product[8];
        int moneyPool = 0;
        Product userPick;

        int MoneyPool { get { return moneyPool; } set { } }

        //Constructor
        public VM()
        {
            MoneyPool = moneyPool;

            productArr[0] = new Edibles("Snickers", 17, "Packed with peanuts, Snickers really satisfies", "Open the packaging and start eating", "energy bar");
            productArr[1] = new Edibles("MARS", 33, "A Mars a day helps you work , rest and play", "Open the packaging and start eating", "energy bar");
            productArr[2] = new Edibles("LAYS ", 41, "Wherever celebrations and good times happen, the LAY'S® brand will be there", "Open the packaging and start eating", "potato chips");
            productArr[3] = new Drinks("Red Bull", 19, "Red Bull is an energy drink sold by Red Bull GmbH, an Austrian company created in 1987", "Open the Can and start drinking");
            productArr[4] = new Drinks("Spring Water", 33, "Just plain and simple water from fresh springs of Sweden", "Open the bottle and start drinking");
            productArr[5] = new Drinks("Coka-Cola", 17, "sweetened carbonated beverage that is a cultural institution in the United States and a global symbol of American tastes", "Open the can and start drinking");
            productArr[6] = new Reades("Four Four Two", 70, "Magazine that delves deep into everything you need to know about the world of football.", " Reading everything from the latest transfer news to the breakthrough future stars you need to know about");
            productArr[7] = new Reades("Match Of The Day", 52, " Match of The Day always comes to play. Whether you’re in need of all the inside scoop or looking to improve your own game", "getting access to exciting posters, quizzes and competitions, as well as footballer features, important results, great events");

        }

        //Method that takes in a product and removes its value from the money pool

        public void CalculateChange(Product userProd)
        {
            moneyPool = moneyPool - userProd.Price;

        }

        //Method that returns available credits in money pool

        public int GetCredit()
        {
            return moneyPool;
        }

        //Method to loads the money pool from money denominations array
        public void InsertMoney(int userChoice)
        {
            moneyPool = moneyPool + moneyDenominator[userChoice];

        }

        // Method that takes in a value to pick a product,
        // checks if there is enough money in moneypool 
      
        public void PickProduct(int userChoice, VM vm)
        {
            bool canAfford;

            userPick = productArr[userChoice - 1];
            canAfford = userPick.Purchase(userPick, vm);

            if (canAfford == true)
            {
                Array.Resize(ref boughtProducts, boughtProducts.Length + 1);
                boughtProducts[boughtProducts.Length - 1] = userPick;
                CalculateChange(userPick);
            }

        }

        //Method that returns the array of bought products

        public Product[] GetBoughtProducts()
        {
            return boughtProducts;
        }

        public Product[] GetProducts()
        {
            return productArr;
        }

        public int[] GetDenominators()
        {
            return moneyDenominator;
        }

    }
}