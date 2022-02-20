namespace OnlineShop.WebApi.Models
{
    public class OrderUpdateModel
    {
        public OrderUpdateModel(int statusTypeId, int customerId)
        {
            var currentDateTime = DateTime.Now;
            LastUpdate = currentDateTime;
            StatusTypeId = statusTypeId;
            CustomerId = customerId;
        }
        public int Id { get; set; }
        public DateTime LastUpdate { get; set; }

        public int StatusTypeId { get; set; }

        public int CustomerId { get; set; }
    }
}
