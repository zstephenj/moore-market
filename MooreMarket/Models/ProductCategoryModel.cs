namespace MooreMarket.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        IList<Product> Products { get; set; }

    }
}