using System.Collections.Generic;
using System.Linq;
using MooreMarket.Models;

namespace MooreMarket.Data 
{
    public class DbInitializer
    {
        public static void Initialize(MooreMarketContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            UserModel farmer1 = new UserModel
            {
                Username = "farmer1",
                Password = "password",
                AccountType = AccountType.Farmer
            };

            UserModel farmer2 = new UserModel
            {
                Username = "farmer2",
                Password = "password",
                AccountType = AccountType.Farmer
            };

            UserModel user1 = new UserModel
            {
                Username = "user1",
                Password = "password",
                AccountType = AccountType.User
            };

            UserModel user2 = new UserModel
            {
                Username = "user2",
                Password = "password",
                AccountType = AccountType.User
            };

            context.Users.Add(farmer1);
            context.Users.Add(farmer2);
            context.Users.Add(user1);
            context.Users.Add(user2);

            context.SaveChanges();
            
            ProductCategory TestCat1 = new ProductCategory("TestCategory1");
            TestCat1.Id = 1;
            ProductCategory TestCat2 = new ProductCategory("TestCategory2");
            TestCat2.Id = 2;
            context.Categories.Add(TestCat1);
            context.Categories.Add(TestCat2);
            context.SaveChanges();

            Product farmer1Product1 = new Product
            {
                Name = "farmer1's Product1",
                Description = "farmer1 product1 description",
                CategoryId = 1,
                Category = TestCat1,
                Quantity = 1,
                Price = 5.50f,
                IsPerishable = false,
                UserId = 1
            };

            Product farmer1Product2 = new Product
            {
                Name = "farmer1's Product2",
                Description = "farmer1's product2 description",
                CategoryId = 2,
                Category = TestCat2,
                Quantity = 1,
                Price = 5.50f,
                IsPerishable = false,
                UserId = 1
            };

            Product farmer2Product1 = new Product
            {
                Name = "farmer2's product1",
                Description = "farmer2's product1 description",
                CategoryId = 1,
                Quantity = 40,
                Price = 10,
                IsPerishable = false,
                UserId = 2
            };

            Product farmer2Product2 = new Product
            {
                Name = "farmer2's product2",
                Description = "farmer2 product2 description",
                CategoryId = 1,
                Quantity = 40,
                Price = 10,
                IsPerishable = false,
                UserId = 2
            };

            context.Products.Add(farmer1Product1);
            context.Products.Add(farmer1Product2);
            context.Products.Add(farmer2Product1);
            context.Products.Add(farmer2Product2);

            context.SaveChanges();

            IList<Product> farmer1Products = new List<Product>
            { farmer1Product1, farmer1Product2};
            farmer1.Products = farmer1Products;

            IList<Product> farmer2Products = new List<Product>
            { farmer2Product1, farmer2Product2};
            farmer2.Products = farmer2Products;

            context.Users.Update(farmer1);
            context.Users.Update(farmer2);
            context.SaveChanges();
            
        

                
        }
    }
}