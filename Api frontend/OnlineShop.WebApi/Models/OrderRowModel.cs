namespace OnlineShop.WebApi.Models
{
    public class OrderRowModel
    {
        public OrderRowModel(DateTime rowAdded, int orderId, string productId, int ammount, int price)
        {
            RowAdded = rowAdded;
            OrderId = orderId;
            ProductId = productId;
            Ammount = ammount;
            Price = price;
        }

        public OrderRowModel(int id, DateTime rowAdded, int orderId, string productId, int ammount, int price)
        {
            Id = id;
            RowAdded = rowAdded;
            OrderId = orderId;
            ProductId = productId;
            Ammount = ammount;
            Price = price;
        }

        public int Id { get; set; }
        public DateTime RowAdded { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public int Ammount { get; set; }
        public int Price { get; set; }
    }
}
