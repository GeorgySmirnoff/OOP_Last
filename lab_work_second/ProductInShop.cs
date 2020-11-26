using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_second
{
    public class ProductInShop
    {
        public Product Product { get; set; }
        private decimal cost;
        private int amount;

        public decimal Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                    throw new Exception("Стоимость не может быть отрицательной");
                cost = value;
            }
        }
        public int Amount
        {
            get { return amount; }
            set
            {
                if (value < 0)
                    throw new Exception("Количество не может быть отрицательным");
                amount = value;
            }
        }
        public ProductInShop(Product product, int amount, decimal cost)
        {
            Amount = amount;
            Product = product;
            Cost = cost;
        }
    }
}