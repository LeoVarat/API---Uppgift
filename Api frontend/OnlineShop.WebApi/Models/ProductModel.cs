namespace OnlineShop.WebApi.Models
{
    public class ProductModel
    {
        public ProductModel()
        {

        }

        public ProductModel(string productNumber, string name, string description, int price)
        {
            ProductNumber = productNumber;
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductModel(int id, string productNumber, string name, string description, int price)
        {
            Id = id;
            ProductNumber = productNumber;
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductModel(string productNumber, string name, string description, int price, int categoryId)
        {
            ProductNumber = productNumber;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        public ProductModel(int id, string productNumber, string name, string description, int price, int categoryId)
        {
            Id = id;
            ProductNumber = productNumber;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string ProductNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
