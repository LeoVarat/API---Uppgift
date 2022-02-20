namespace OnlineShop.WebApi.Models
{
    public class OrderRowCreateModel
    {
        public OrderRowCreateModel(int orderId, string productId, int ammount, int price)
        {

            RowAdded = DateTime.Now;
            OrderId = orderId;
            ProductId = productId;
            Ammount = ammount;
            Price = price;
        }

        public DateTime RowAdded { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public int Ammount { get; set; }
        public int Price { get; set; }
    }
}
