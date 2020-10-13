using System;
using System.Collections.Generic;
using System.Text;

namespace My_Vending_Machine.VendingMachine
{
    interface IVM
    {
        void InsertMoney(int userChoice); //Added Credit
        void PickProduct(int userChoice, VM vm); //Chosen Product
        int GetCredit(); //Total Credit
        Product[] GetProducts(); //List Of Products
        Product[] GetBoughtProducts(); // Items in Basket
        void CalculateChange(Product userProd); // Credit left
        int[] GetDenominators();

    }
}
