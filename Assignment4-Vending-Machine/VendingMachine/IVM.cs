using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_Vending_Machine.VendingMachine
{
    interface IVM
    {
        void InsertMoney(int userChoice);//user puts the money in the machine
        void PickProduct(int userChoice, VM vm);//user picks the product(s) they want to buy
        int GetCredit();//show how much money/credits the user has put in
        Product[] GetProducts();//returns array with available products
        Product[] GetBoughtProducts();//returns array with bought products
        void CalculateChange(Product userProd);//removes a products value from the money pool
        int[] GetDenominators();

    }
}
