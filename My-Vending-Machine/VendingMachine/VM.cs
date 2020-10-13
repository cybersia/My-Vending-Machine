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

            productArr[0] = new Edibles("Shinji Ramen", 15, "Spicy flavored ramen noodles made in Japan.", "cook the noodles in boiling water then eat them.", "noodles");
            productArr[1] = new Edibles("Peppridge Power Boost", 35, "Nutritional snack with granola, müsli and chocolate. Perfect for when you need that extra boost", "unwrap the power bar then eat it.", "energy bar");
            productArr[2] = new Edibles("Granny Crisps: Chocolate flavor", 39, "Chocolate flavored crisps that combines the sensations of salt and sweet. Granny Bacons original recepie, try them today!", "open the bag and eat the crisps with your hand.", "potato crisps");
            productArr[3] = new Drinks("Super Sugar Ray", 22, "Fizzy drink with an awesome sugar flavor. New recepie with added sugar! From the good folks at Nestlé.", "unscrew the cork and drink straight from the bottle.");
            productArr[4] = new Drinks("Spring Water Naturals", 31, "Exclusive water flavored water with minerals from the springs of the Hudson river, NYC.", "open the cap with a capopener and pour into a glas, then drink from said glas.");
            productArr[5] = new Drinks("Nuka-Cola", 19, "Classic Nuka-Cola in a glass bottle. The perfect blend of ingridients that brings in the sweet in life.", "unscrew the cork and chug the whole bottle faster than you can say hiccups.");
            productArr[6] = new Reades("FizzFeed News Weekly #71", 68, "Your primary source of what is happening in the glamourous lives of celebrities all around the world. This week: Gwyneth Paltrow bought a pig as a finacial supervisor.", "open the magazine and feel your brain melt.");
            productArr[7] = new Reades("Bros 'n' Cars #44", 54, "The ONLY weekly dose of adrenaline and gasoline, with classy pictures of all the things you like: cars, gals, weapons and more..", "turn the pages, looking at the pictures occasionaly reading a word here and there.");

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