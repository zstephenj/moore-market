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
                AccountType = AccountType.Vendor
            };

            UserModel farmer2 = new UserModel
            {
                Username = "farmer2",
                Password = "password",
                AccountType = AccountType.Vendor
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

            
            ProductCategory TestCat1 = new ProductCategory("TestCategory1");
            TestCat1.Id = 1;
            ProductCategory TestCat2 = new ProductCategory("TestCategory2");
            TestCat2.Id = 2;
            context.Categories.Add(TestCat1);
            context.Categories.Add(TestCat2);

            Product farmer1Product1 = new Product
            {
                Name = "farmer1's Product1",
                Description = "farmer1 product1 description",
                CategoryId = 1,
                Category = TestCat1,
                Quantity = 1,
                Price = 5.50f,
                IsPerishable = 0,
                UserId = 1
            };

            Product newProduct1 = new Product 
            {
              Name = "Bananas From Far Away",
              Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas lobortis malesuada lacus vitae ultricies. Suspendisse rutrum nulla sit amet mi ullamcorper tempor. Nunc fringilla diam luctus nunc tincidunt, id accumsan elit sollicitudin. Morbi nisi nulla, condimentum quis ultricies sed, congue at nibh. Phasellus massa tellus, dictum in imperdiet sit amet, pellentesque vel nibh. Pellentesque aliquet, justo ac mollis faucibus, ex justo congue ipsum, non blandit ligula arcu at nisl.",
              CategoryId = 1,
              Quantity = 11,
              Price = 1.11f,
              IsPerishable = 1,
              KeepRoom = 1,
              ShelfLifeRoom = "some time",
              KeepFridge = 1,
              ShelfLifeFridge = "something",
              KeepFreezer = 1,
              ShelfLifeFreezer = "something",
              UserId = 1
            };
            context.Add(newProduct1);

            Product newProduct2 = new Product
            {
              Name = "Apples",
              Description = "some apples",
              CategoryId = 1,
              Quantity = 6,
              Price = 12.22f,
              IsPerishable = 1,
              KeepRoom = 1,
              ShelfLifeRoom = "shelf life",
              UserId = 1
            };
            context.Add(newProduct2);

            Product newProduct3 = new Product
            {
              Name = "I'm Always Out of Stock",
              Description = "Does it really matter? I'm always going to be out of stock. No bueno.",
              CategoryId = 2,
              Quantity = 0,
              Price = 3.33f,
              UserId = 2
            };
            context.Add(newProduct3);

            Product newProduct4 = new Product
            {
              Name = "Super Expensive",
              Description = "Is This Love",
              CategoryId = 1,
              Quantity = 420,
              Price = 710,
              UserId = 2
            };
            context.Add(newProduct4);

            Product newProduct5 = new Product
            {
              Name = "Thing",
              Description = "description of thing",
              CategoryId = 2,
              Quantity = 3,
              Price = 7.10f,
              UserId = 1
            };
            context.Add(newProduct5);

            Product newProduct6 = new Product
            {
              Name = "Other thing",
              Description = "Is This Love",
              CategoryId = 2,
              Quantity = 420,
              Price = 74.12f,
              UserId = 2
            };
            context.Add(newProduct6);

            Product newProduct7 = new Product
            {
              Name = "Other thing",
              Description = "Is This Love",
              CategoryId = 1,
              Quantity = 420,
              Price = 74.12f,
              UserId = 2
            };
            context.Add(newProduct7);

            Market newMarket1 = new Market
            {
              Name = "The Tower Grove Farmers' Market",
              Address = "Center Cross Dr, St. Louis, MO 63116, USA",
              Lat = 38.6067598,
              Lng = -90.26026680000001,
              Url = "https://maps.google.com/?cid=9216417861388382972"
            };
            Market newMarket2 = new Market
            {
              Name = "Summit Produce at Kirkwood Farmers Market",
              Address = "150 E Argonne Dr, Kirkwood, MO 63122, USA",
              Lat = 38.58082,
              Lng = 90.404518,
              Url = "https://maps.google.com/?cid=2173026026069796459"
            };
            Market newMarket3 = new Market
            {
              Name = "Midtown Farmers Market",
              Address = "6655 Delmar Blvd, St. Louis, MO 63130, USA",
              Lat = 38.6563628,
              Lng = 90.3071822,
              Url = "https://maps.google.com/?cid=10918335213966964871"
            };
            Market newMarket4 = new Market
            {
              Name = "Park Avenue Coffee - Soulard Farmers Market",
              Address = "720 Carroll St, St. Louis, MO 63104, USA",
              Lat = 38.61039509999999,
              Lng = 90.2000544,
              Url = "https://maps.google.com/?cid=6908738308197433128"
            };
            Market newMarket5 = new Market
            {
              Name = "Schlafly Farmers Market",
              Address = "7260 Southwest Ave, Maplewood, MO 63143, USA",
              Lat = 38.61282949999999,
              Lng = 90.31501220000001,
              Url = "https://maps.google.com/?cid=788000265220792073"
            };
            Market newMarket6 = new Market
            {
              Name = "Union Station Farmers Market",
              Address = "1701 Wynkoop St, Denver, CO 80202, USA",
              Lat = 39.7529662,
              Lng = 105.0002556,
              Url = "https://maps.google.com/?q=1701+Wynkoop+St,+Denver,+CO+80202,+USA&ftid=0x876c78c308d895a7:0xc3c54d6855585937"
            };
            Market newMarket7 = new Market
            {
              Name = "Colorado Fresh Markets Inc",
              Address = "3000 E 1st Ave, Denver, CO 80209, USA",
              Lat = 39.7168239,
              Lng = 104.9526295,
              Url = "https://maps.google.com/?q=3000+E+1st+Ave,+Denver,+CO+80209,+USA&ftid=0x876c7e913a89fcd1:0x854d98cbd1f0f519"
            };
            Market newMarket8 = new Market
            {
              Name = "Stapleton Farmers Market",
              Address = "7351 E 29th Ave, Denver, CO 80238, USA",
              Lat = 39.75817F,
              Lng = 104.90216900000001,
              Url = "https://maps.google.com/?q=7351+E+29th+Ave,+Denver,+CO+80238,+USA&ftid=0x876c7b9b1035f7fb:0x99ebf43a08dc9165"
            };
            context.Add(newMarket1);
            context.Add(newMarket2);
            context.Add(newMarket3);
            context.Add(newMarket4);
            context.Add(newMarket5);
            context.Add(newMarket6);
            context.Add(newMarket7);
            context.Add(newMarket8);
            
            context.SaveChanges();
        }
    }
}
