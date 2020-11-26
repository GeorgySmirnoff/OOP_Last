using System;
using System.Collections.Generic;

namespace lab_work_second
{
    class Program
    {
        //Создать магазин;
        public static Shop CreateShop()
        {
            Console.WriteLine("Введите название магазина");
            string name = Console.ReadLine();
            Console.WriteLine("Введите адрес магазина");
            string address = Console.ReadLine();
            Shop shop = new Shop(name, address);
            return shop;
        }
        //Создать товар;
        public static Product CreateProduct()
        {
            Console.WriteLine("Введите название товара");
            string name = Console.ReadLine();
            Product product = new Product(name);
            return product;
        }

        //Поиск магазина по ID
        public static Shop FindShop(int ID,List<Shop> shops) 
        {
            foreach (var shop in shops)
            {
                if (shop.ID == ID) return shop;
            }
            return null;
        }
        //Поиск продукта по ID
        public static Product FindProduct(int ID, List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.ID == ID) return product;
            }
            return null;
        }
        //Показать магазины
        public static void ShowShops(List<Shop> shops)
        {
            foreach (var item in shops)
            {
                Console.WriteLine(item.ID + " " + item.Name);
            }
        } 
        //Показать продукты
        public static void ShowProducts(List<Product> products) 
        {
            foreach (var item in products)
            {
                Console.WriteLine(item.ID + " " + item.Name);
            }
        }
        //Поиск магазина с самым дешевым товаром
        //public static Shop FindShopCheapProduct(List<Shop>shops,Product product)
        //{
        //    Shop resultShop = null;
        //    decimal minCost = decimal.MaxValue;
        //    foreach (var item in shops)
        //    {
        //        ProductInShop res = item.FindCheapProduct(product);
        //        if(res != null && res.Cost < minCost)
        //        {
        //            minCost = res.Cost;
        //            resultShop = item;
        //        }
        //    }return resultShop;
        //}
        static void Main(string[] args)
        {
            List<Shop> shops = new List<Shop>();
            List<Product> products = new List<Product>();

            while (true)
            {
                Console.WriteLine("1.Создать магазин;");
                Console.WriteLine("2.Создать товар");
                Console.WriteLine("3.Завезти партию товаров в магазин");
                Console.WriteLine("4.Найти магазин, в котором определенный товар самый дешевый");
                Console.WriteLine("5.Понять, какие товары можно купить в магазине на некоторую сумму");
                Console.WriteLine("6.Купить партию товаров в магазине");
                Console.WriteLine("7.Найти, в каком магазине партия товаров имеет наименьшую сумму");
                Console.WriteLine("8.Вывести магазины");
                Console.WriteLine("9.Вывести товары");

                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Shop shop = CreateShop();
                    shops.Add(shop);
                }
                else if (choice == 2)
                {
                    Product product = CreateProduct();
                    products.Add(product);
                }
                else if(choice == 3) 
                {
                    Console.WriteLine("Введите ID магазина");
                    int shopID = int.Parse(Console.ReadLine());
                    Shop shop = FindShop(shopID, shops);
                    if(shop != null)
                    {
                        Console.WriteLine("Введите ID товара");
                        int productID = int.Parse(Console.ReadLine());
                        Product product = FindProduct(productID, products);
                        if (product != null)
                        {
                            Console.WriteLine("Введите количество товара");
                            int amount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите стоимость товара");
                            decimal cost = decimal.Parse(Console.ReadLine());
                            ProductInShop productInShop = new ProductInShop(product, amount, cost);
                            shop.AddProduct(productInShop);
                        }
                        else Console.WriteLine("Продукт не найден");
                    }else Console.WriteLine("Магазин не найден");
                }
                else if(choice == 4)
                {
                    Console.WriteLine("Введите ID товара");
                    int productID = int.Parse(Console.ReadLine());
                    Product product = FindProduct(productID, products);
                    if (product != null) 
                    {
                        Shop resultShop = Shop.FindShopCheapProduct(shops, product);
                        if (resultShop != null)
                        {
                            Console.WriteLine(resultShop.ID + " " + resultShop.Name);
                        }
                        else Console.WriteLine("Данного товара нет в магазине вообще");                    
                    }
                }
                else if(choice == 5)
                {
                    Console.WriteLine("Введите ID магазина");
                    int shopID = int.Parse(Console.ReadLine());
                    Shop shop = FindShop(shopID, shops);
                    if (shop != null)
                    {
                        Console.WriteLine("Введите сумму денег");
                        decimal money = decimal.Parse(Console.ReadLine());
                        var result = shop.FindOptionsToBuy(money);
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.Item1.Product.Name + " " + item.Item2);
                        }
                    }
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Введите ID магазина");
                    int shopID = int.Parse(Console.ReadLine());
                    Shop shop = FindShop(shopID, shops);
                    if (shop != null)
                    {
                        Console.WriteLine("Сколько товаров вы хотите купить?");
                        int amount = int.Parse(Console.ReadLine());
                        
                        
                    }
                    else Console.WriteLine("Магазин не найден");
                }
                else if (choice == 7)
                {

                }
                else if(choice == 8)
                {
                    ShowShops(shops);
                }
                else if (choice == 9)
                {
                    ShowProducts(products);
                }
            }
        }
    }
}
