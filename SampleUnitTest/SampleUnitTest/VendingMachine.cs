using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleUnitTest
{
    public class VendingMachine
    {
        private readonly List<decimal> _acceptedBills = new List<decimal>() { 100, 50, 20 };
        private readonly List<decimal> _acceptedCoinss = new List<decimal>() { 10, 5, 1, 50, .25m };
        private readonly List<Product> _availavleProducts = new List<Product>()
        {
            new Product() { Code="A1", Name ="Coke",  Price=25},
            new Product() { Code="A2", Name ="Pepsi",  Price=35},
            new Product() { Code="A3", Name ="Soda",  Price=45},
            new Product() { Code="A4", Name ="Chocolate Bar",  Price=20.25m},
            new Product() { Code="A5", Name ="Chewing Gum",  Price=10.50m},
            new Product() { Code="A6", Name ="Bottled Water",  Price=15}
        };


        private List<Product> _SelectedProducts { get; set; }
        private decimal _TotalAmountInserted { get; set; }

        public VendingMachine()
        {
            this._SelectedProducts = new List<Product>();
            this._TotalAmountInserted = 0m;
        }

        public string InsertBill(decimal bill)
        {
            if (!IsBillValid(bill)) return ReturnMessage.InvalidBill;

            _TotalAmountInserted += bill;

            return ReturnMessage.ValidBill;
        }

        public string InsertCoin(decimal coin)
        {
            if (!IsCoinValid(coin)) return ReturnMessage.InvalidCoin;

            _TotalAmountInserted += coin;

            return ReturnMessage.ValidCoin;
        }

        public string SelectProduct(string productCode) 
        {
            Product product = _availavleProducts.Where(s => s.Code.Equals(productCode, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

            if (product == null) return ReturnMessage.InvalidProductCode;
            if (product.Price > _TotalAmountInserted) return ReturnMessage.InsufficientMoney;

            _TotalAmountInserted -= product.Price;

            return ReturnMessage.ProductSelected;
        }

        public decimal Cancel()
        {
            decimal amountInserted = this._TotalAmountInserted;

            this._TotalAmountInserted = 0;

            return amountInserted;
        }

        public decimal Refund()
        {
            decimal amountToRefund = this._TotalAmountInserted;

            this._TotalAmountInserted = 0;

            return amountToRefund;
        }


        private bool IsBillValid(decimal bill)
        {
            return _acceptedBills.Contains(bill);
        }

        private bool IsCoinValid(decimal bill)
        {
            return _acceptedCoinss.Contains(bill);
        }
    }
}
