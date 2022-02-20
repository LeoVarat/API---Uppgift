namespace OnlineShop.WebApi.Models
{
    public class OrderCreateModel
    {
        public OrderCreateModel(int customerId, int statusTypeId = 1)
        {
            var currentDateTime = DateTime.Now;

            Created = currentDateTime;
            LastUpdate = currentDateTime;
            StatusTypeId = statusTypeId;
            CustomerId = customerId;
        }

        public DateTime Created { get; set; }

        public DateTime LastUpdate { get; set; }

        public int StatusTypeId { get; set; }

        public int CustomerId { get; set; }
    }
}
