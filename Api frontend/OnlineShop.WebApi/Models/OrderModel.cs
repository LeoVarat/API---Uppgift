namespace OnlineShop.WebApi.Models
{
    public class OrderModel
    {
        public OrderModel()
        {

        }
        public OrderModel(int id, DateTime created, DateTime lastUpdate, int statusTypeId, int customerId)
        {
            Id = id;
            Created = created;
            LastUpdate = lastUpdate;
            StatusTypeId = statusTypeId;
            CustomerId = customerId;
        }

        public OrderModel(int id, DateTime created, DateTime lastUpdate, int statusTypeId, int customerId, IList<OrderRowModel> rows)
        {
            Id = id;
            Created = created;
            LastUpdate = lastUpdate;
            StatusTypeId = statusTypeId;
            CustomerId = customerId;
            Rows = rows;
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }
        public int StatusTypeId { get; set; }
        public int CustomerId { get; set; }
        public IList<OrderRowModel> Rows { get; set; }

    }
}
