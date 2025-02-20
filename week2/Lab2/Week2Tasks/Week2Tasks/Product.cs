using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Tasks
{
    public class Product
    {
        public int Id;
        public string Name;
        public float Price;
        public string Category;
        public string BrandName;
        public string Country;

        public Product(int id,string name,float price,string category,string brand,string country) 
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            BrandName = brand;
            Country = country;
        }



    }
}
