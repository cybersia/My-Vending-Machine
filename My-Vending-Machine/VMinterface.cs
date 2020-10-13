using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Assignment4_Vending_Machine.VendingMachine;

namespace Assignment4_Vending_Machine
{
    public class VMinterface
    {
        VM vendingMachine = new VM();


        public void RunVM()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            int userSelection;

            Console.Clear();
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
            Console.WriteLine("     My Vending Machine    ");
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
            Console.WriteLine($"Available credits: {vendingMachine.GetCredit()} Kr\n");
            Console.WriteLine("1. Add Credit ");
            Console.WriteLine("2. Purchase ");
            Console.WriteLine("3. Basket ");
            Console.WriteLine("4. Finish ");


            switch (userSelection = AskForSelection())
            {
                case 1:
                    MenuInsertMoney();
                    break;
                case 2:
                    BuyProduct();
                    break;
                case 3:
                    ViewMyProducts();
                    break;
                case 4:
                    FinishBuy();
                    break;
                default:
                    Console.WriteLine("Not a valid input. Please try again.");
                    Console.ReadKey(false);
                    MainMenu();
                    break;

            }

        }

        private int AskForSelection()
        {
            int selection;

            Console.Write("\nYour selection: ");
            int.TryParse(Console.ReadLine(), out selection);

            return selection;
        }

        private void Confirmed(int value)
        {
            Console.WriteLine($"\n{value}kr has been added to your credits. \nPress any key to continue.");
            Console.ReadKey(false);
        }

        private void MenuInsertMoney()
        {
            string i;
            bool keepAlive = true;

            while (keepAlive == true)
            {

                Console.Clear();
                Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
                Console.WriteLine("     My Vending Machine    ");
                Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
                Console.WriteLine($"Available credits: {vendingMachine.GetCredit()} Kr\n");
                Console.WriteLine("How much credit would you like to add?");
                Console.WriteLine("1. 1000kr\n2. 500kr\n3. 100kr\n4. 50kr\n5. 20kr\n6. 10kr\n7. 5kr\n8. 1kr\nEnter 9 to return to main menu.");

                int[] denom = vendingMachine.GetDenominators();
                int sel = AskForSelection();


                if (sel < 1 || sel > 9)
                {
                    Console.WriteLine("Invalid Input. Press any key to continue.");
                    Console.ReadKey(false);
                }
                else if (sel == 9)
                {
                    keepAlive = false;
                }
                else
                {
                    vendingMachine.InsertMoney(sel - 1);
                    Confirmed(denom[sel - 1]);
                }

            }

            MainMenu();
        }

        private void ViewMyProducts()
        {
            Product[] boughtProducts = vendingMachine.GetBoughtProducts();
            int i = 1;

            Console.Clear();
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
            Console.WriteLine("     My Vending Machine    ");
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
            Console.WriteLine($"Available credits: {vendingMachine.GetCredit()} Kr\n");
            Console.WriteLine("Your products:");

            foreach (var item in boughtProducts)
            {
                Console.WriteLine($"{i++}: {item.Name}.");
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey(false);

            MainMenu();
        }

        private void BuyProduct()
        {
            Product[] products = vendingMachine.GetProducts();
            int choice;
            bool keepAlive = true;

            while (keepAlive == true)
            {
                Product[] boughtProducts = vendingMachine.GetBoughtProducts();
                int i = 1;
                int bought = boughtProducts.Length;

                Console.Clear();
                Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
                Console.WriteLine("     My Vending Machine    ");
                Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
                Console.WriteLine($"Available credits: {vendingMachine.GetCredit()} Kr\n");

                foreach (var item in products)
                {
                    Console.WriteLine($"{i++}: {item.Name}. \n     Price: {item.Price}kr");
                }

                Console.WriteLine("9: Return to main menu.\n");
                Console.WriteLine("Please select the item number");


                choice = AskForSelection();


                if (choice < 1 || choice > 9)
                {
                    Console.WriteLine("Invalid Input. Press any key to continue.");
                    Console.ReadKey(false);
                }
                else if (choice == 9)
                {
                    keepAlive = false;
                }
                else
                {
                    vendingMachine.PickProduct(choice, vendingMachine);
                    CheckPurchase(choice, bought);
                }
            }

            MainMenu();
        }

        private void CheckPurchase(int choice, int bought)
        {
            Product[] boughtProducts = vendingMachine.GetBoughtProducts();
            Product[] products = vendingMachine.GetProducts();
            int boughtShould = boughtProducts.Length;

            if (boughtShould == bought + 1)
            {
                Console.WriteLine($"\n{products[choice - 1].Name} has been added to your basket. Press any key to continue.");
                Console.ReadKey(false);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ERROR: You do not have enough credits to purchase this product.");
                Console.ReadKey(false);
            }
        }

        private void FinishBuy()
        {
            Product[] boughtProducts = vendingMachine.GetBoughtProducts();
            int[] denominators = vendingMachine.GetDenominators();
            int change = vendingMachine.GetCredit();
            bool keepLooping = true;

            Console.Clear();
            Console.WriteLine("Thank you for shoping at My Vending Machine \n");
            Console.Write("Your change:");

            for (int i = 0; i < denominators.Length; i++)
            {
                keepLooping = true;

                while (keepLooping == true)
                {

                    if (change >= denominators[i])
                    {
                        Console.Write($"{denominators[i]}kr ");
                        change = change - denominators[i];
                    }
                    else
                    {
                        keepLooping = false;
                    }
                }
            }

            keepLooping = true;

            while (keepLooping == true)
            {

                int iCounter = 1;

                Console.WriteLine();
                Console.WriteLine("\nYour products:");

                foreach (var item in boughtProducts)
                {
                    Console.WriteLine($"{iCounter++}: {item.Name}.");
                }

               
                Console.WriteLine("\nPlease select the item number\nEnter -1 to Exit.");
                int pick = AskForSelection();

                if (pick >= 0)
                {
                    UseProduct(boughtProducts[pick - 1]);
                }
                else
                {
                    keepLooping = false;
                }
            }


        }

        private void UseProduct(Product product)
        {
            Console.Clear();
            Console.WriteLine($"What do you want to do with your" +
                $" product?\n1: Use\n2: Examine");
            int selection = AskForSelection();

            switch (selection)
            {
                case 1:
                    Console.WriteLine(product.Use());
                    Console.ReadKey(false);
                    break;
                case 2:
                    Console.WriteLine(product.Examine());
                    Console.ReadKey(false);
                    break;

                default:
                    Console.WriteLine("Invalid input , try again.");
                    Console.ReadKey(false);
                    break;
            }

        }

    }
}