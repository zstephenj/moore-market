using System.Collections.Generic;

namespace MooreMarket.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ProductCategory()
        {

        }
        public ProductCategory(string name)
        {
            Name = name;
        }


    }
}