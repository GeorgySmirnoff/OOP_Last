using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_second
{
   public class Product
    {       
        public string Name { get; set; }
        public int ID { get; set; }
        private static int globalProductCount = 0;
        public Product(string name)
        {
            ID = ++globalProductCount;
            Name = name;
        }

    }
}
