using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleUnitTest
{
    [TestFixture]
    public class VendingMachineTest
    {
        [TestCase(100, ReturnMessage.ValidBill)]
        [TestCase(50, ReturnMessage.ValidBill)]
        [TestCase(20, ReturnMessage.ValidBill)]
        [TestCase(10, ReturnMessage.InvalidBill)]
        public void InsertBill(decimal bill, string returnMessage)
        {
            VendingMachine vm = new VendingMachine();
            Assert.AreEqual(returnMessage, vm.InsertBill(bill));
        }

        [TestCase(10, ReturnMessage.ValidCoin)]
        [TestCase(5, ReturnMessage.ValidCoin)]
        [TestCase(1, ReturnMessage.ValidCoin)]
        [TestCase(50, ReturnMessage.ValidCoin)]
        [TestCase(.25, ReturnMessage.ValidCoin)]
        [TestCase(7, ReturnMessage.InvalidCoin)]
        public void InsertCoin(decimal bill, string returnMessage)
        {
            VendingMachine vm = new VendingMachine();
            Assert.AreEqual(returnMessage, vm.InsertCoin(bill));
        }

        [TestCase("A1", ReturnMessage.ProductSelected)]
        [TestCase("B1", ReturnMessage.InvalidProductCode)]
        public void SelectProduct_ProductCode(string productCode, string returnMessage)
        {
            VendingMachine vm = new VendingMachine();
            vm.InsertBill(20);
            vm.InsertCoin(5);

            Assert.AreEqual(returnMessage, vm.SelectProduct(productCode));
        }

        [TestCase("A1", ReturnMessage.ProductSelected)]
        [TestCase("A2", ReturnMessage.InsufficientMoney)]
        public void SelectProduct_InsufficientMoney(string productCode, string returnMessage)
        {
            VendingMachine vm = new VendingMachine();
            vm.InsertBill(20);
            vm.InsertCoin(5);

            Assert.AreEqual(returnMessage, vm.SelectProduct(productCode));
        }

        [TestCase(50, 50)]
        public void Cancel(decimal expected, decimal bill)
        {
            VendingMachine vm = new VendingMachine();
            vm.InsertBill(bill);

            Assert.AreEqual(expected, vm.Cancel());
        }

        [TestCase(20, 20)]
        public void Refund(decimal expected, decimal bill)
        {
            VendingMachine vm = new VendingMachine();
            vm.InsertBill(bill);

            Assert.AreEqual(expected, vm.Refund());
        }

    }
}
