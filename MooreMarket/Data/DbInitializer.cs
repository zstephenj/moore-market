using MooreMarket.Models;

namespace MooreMarket.Data 
{
    public class DbInitializer
    {
        public static void Initialize(MooreMarketContext context)
        {
            context.Database.EnsureCreated();
            
            ProductCategory TestCat1 = new ProductCategory("TestCategory1");
            TestCat1.ID = 1;
            ProductCategory TestCat2 = new ProductCategory("TestCategory2");
            TestCat2.ID = 2;
            context.Categories.Add(TestCat1);
            context.Categories.Add(TestCat2);
            context.SaveChanges();
            Product TestProduct1 = new Product("TestProduct1N", "TestProduct1D", 1, 8, 88, 0, 0, "", 0, "", 0, "", "img1data");
            TestProduct1.CategoryID = 1;
            TestProduct1.Category = TestCat1;
            Product TestProduct2 = new Product("TestProduct2N", "TestProduct2D", 2, 6, 66, 1, 1, "11", 1, "11", 1, "11", "img2data");
            TestProduct2.CategoryID = 2;
            TestProduct2.Category = TestCat2;
            context.Products.Add(TestProduct1);
            context.Products.Add(TestProduct2);
            context.SaveChanges();           
        }
    }
}