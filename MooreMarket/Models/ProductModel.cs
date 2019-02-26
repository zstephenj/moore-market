namespace MooreMarket.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
        
        public int Quantity {get; set;}
        public float Price {get;set;}
        public bool IsPerishable {get; set;}
        public bool KeepRoom {get; set;}
        public string ShelfLifeRoom {get; set;}
        public bool KeepFridge {get; set;}
        public string ShelfLifeFridge {get; set;}
        public bool KeepFreezer {get; set;}
        public string ShelfLifeFreezer {get; set;}
        public string Image {get;set;}

        public int UserId { get; set; }
        public UserModel User { get; set; }

        public Product()
        {

        }
        public Product(string name, string description, int categoryId, int quantity, float price, bool isPerishable, bool keepRoom, string shelfLifeRoom, bool keepFridge, string shelfLifeFridge, bool keepFreezer, string shelfLifeFreezer, string image)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Quantity = quantity;
            Price = price;
            IsPerishable = isPerishable;
            KeepRoom = keepRoom;
            ShelfLifeRoom = shelfLifeRoom;
            KeepFridge = keepFridge;
            ShelfLifeFridge = shelfLifeFridge;
            KeepFreezer = keepFreezer;
            ShelfLifeFreezer = shelfLifeFreezer;
            Image = image;
        }

        

    }
}