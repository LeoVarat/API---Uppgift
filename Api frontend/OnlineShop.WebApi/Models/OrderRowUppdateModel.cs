namespace OnlineShop.WebApi.Models
{
    public class OrderRowUppdateModel
    {
        public OrderRowUppdateModel(int ammount, int price)
        {
            RowAdded = DateTime.Now;
            Ammount = ammount;
            Price = price;
        }
        public int Id { get; set; }
        public DateTime RowAdded { get; set; }
        public int Ammount { get; set; }
        public int Price { get; set; }
    }
}
