using My_Vending_Machine.VendingMachine;
using System;
using Xunit;

namespace My_Vending_Machine.TEST
{
    public class VMTest1
    {
        
           
        [Fact]
        public void InsertMoneyTest()
        {
            //ARRANGE
            VM vm = new VM();
            int insert = 1;
            int insert2 = 3;
            int expected = 500;
            int expected2 = 550;

            //ACT
            vm.InsertMoney(insert);
            int actual = vm.GetCredit();
            vm.InsertMoney(insert2);
            int actual2 = vm.GetCredit();

            //ASSERT
            Assert.Equal(expected, actual);
            Assert.Equal(expected2, actual2);

        }

        [Fact]
        public void CalculateChangeTest()
        {
            //ARRANGE

            VM vm = new VM();
            
            Edibles userProd = new Edibles("Snickers", 15, "Packed with peanuts, Snickers really satisfies", "Open the packaging and start eating", "energy bar");
            int insert = 2;
            int expected = 85;
            int expected2 = 70;


            //ACT

            vm.InsertMoney(insert);
            vm.CalculateChange(userProd);
            int actual = vm.GetCredit();
            vm.CalculateChange(userProd);
            int actual2 = vm.GetCredit();


            //ASSERT

            Assert.Equal(expected, actual);
            Assert.Equal(expected2, actual2);

        }

        [Fact]
        public void PickProductGOODTest()
        {
            //ARRANGE

            VM vm = new VM();
            int userChoice = 2;
            int userChoice2 = 1;
            int insert = 3;
            int expected = 15;
            int expected2 = 0;
            int expArrLenght = 2;

            //ACT

            vm.InsertMoney(insert);
            vm.PickProduct(userChoice, vm);
            int actual = vm.GetCredit();
            vm.PickProduct(userChoice2, vm);
            int actual2 = vm.GetCredit();
            Product[] pickedProducts = vm.GetBoughtProducts();
            int arrayLength = pickedProducts.Length;

            //ASSERT

            Assert.Equal(expected, actual);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expArrLenght, arrayLength);

        }

        [Fact]
        public void PickProductBADTest()
        {
            //ARRANGE

            VM vm = new VM();
            int insert = 3;
            int expected = 0;

            //ACT

            vm.PickProduct(insert, vm);
            Product[] pickedProducts = vm.GetBoughtProducts();
            int actual = pickedProducts.Length;

            //ASSERT

            Assert.Equal(expected, actual);

        }
    }
}
