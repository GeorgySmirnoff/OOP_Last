using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;

namespace lab_work_second
{
    public class Shop
    {
        public string Name { get; set; }
        public string Address { get; set; }

        private List<ProductInShop> products  = new List<ProductInShop>();
        //ID
        public int ID { get; set; }
        private static int globalShopCount = 0;
        //для теста/показывает коллекцию продуктов в магазине
        public IReadOnlyCollection<ProductInShop> Products 
        {
            get
            {
                return new ReadOnlyCollection<ProductInShop>(products);
            }
        }

        public Shop(string name,string address)
        {
            ID = ++globalShopCount;
            Name = name;
            Address = address;
        }
        public void AddProduct(ProductInShop productInShop)
        {
            bool find = false;
            foreach (var item in products)
            {
                if(item.Product.ID == productInShop.Product.ID && item.Cost == productInShop.Cost)
                {
                    item.Amount += productInShop.Amount;
                    find = true;
                    break;
                }
            }
            if(find == false)          
                products.Add(productInShop);
        }
        //AddProduct for test
        public void AddProduct(Product product , int amount , decimal cost)
        {
            ProductInShop productInShop = new ProductInShop(product, amount, cost);
            AddProduct(productInShop);
        }

        //Поиск самого дешего товара с одним ID в одном магазине
        public ProductInShop FindCheapProduct(Product product)
        {
            decimal minCost = decimal.MaxValue;
            ProductInShop productResult = null;
            foreach (var item in products)
            {
                if(item.Product.ID == product.ID && item.Cost < minCost) 
                {
                    minCost = item.Cost;
                    productResult = item;
                }
            }
            return productResult;
        }
        //Список вариантов что мы можем купить на опр сумму
        public List<Tuple<ProductInShop,int>> FindOptionsToBuy(decimal money)
        {
            var list = new List<Tuple<ProductInShop, int>>();
            foreach (var item in products)
            {
                int count = (int)(money / item.Cost);
                if(count > 0)
                {
                    var pair = Tuple.Create(item, count);
                    list.Add(pair);
                }
            }return list;
        }
        //6
        public ProductInShop FindProduct(Product product)
        {
            foreach (var item in products)
            {
                if(item.Product.ID == product.ID)
                {
                    return item;
                }
            }return null;
        }


        public decimal ResultOfBuy(List<Tuple<Product, int>> list)
        {
            decimal result = 0;
            foreach (var item in list)
            {
                ProductInShop foundProduct = FindCheapProduct(item.Item1);
                if (foundProduct == null) throw new Exception("Данного товара нет");
                if (foundProduct.Amount < item.Item2)
                {
                    foundProduct = FindProduct(item.Item1);
                    if (foundProduct == null) throw new Exception("Данного товара нет");
                    if (foundProduct.Amount < item.Item2) throw new Exception("Не хватает количества товаров для покупки");
                }
                result += item.Item2 * foundProduct.Cost;
            }
            return result;
        }

        //7
        static public Shop FindCheapestShop(List<Tuple<Product,int>> list,List<Shop> shops)
        {
            Shop foundShop = null;
            decimal minCost = decimal.MaxValue;
            foreach (var item in shops)
            {
                decimal money = item.ResultOfBuy(list);
                if (money != 0 && money < minCost) { minCost = money; foundShop = item; }
            }return foundShop;
        }
        //4
        //Поиск магазина с самым дешевым товаром
        public static Shop FindShopCheapProduct(List<Shop> shops, Product product)
        {
            Shop resultShop = null;
            decimal minCost = decimal.MaxValue;
            foreach (var item in shops)
            {
                ProductInShop res = item.FindCheapProduct(product);
                if (res != null && res.Cost < minCost)
                {
                    minCost = res.Cost;
                    resultShop = item;
                }
            }
            return resultShop;
        }
    }
}
