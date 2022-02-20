namespace OnlineShop.WebApi.Models
{
    public class ProductUpdateModel
    {
        public ProductUpdateModel(string name, string description, int price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductUpdateModel(string name, string description, int price, int categoryId)
        {
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
