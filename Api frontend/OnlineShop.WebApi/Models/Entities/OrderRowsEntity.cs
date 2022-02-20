using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.WebApi.Models.Entities
{
    public class OrderRowsEntity
    {
        public OrderRowsEntity(int orderId, string productId, int ammount, int price)
        {
            OrderId = orderId;
            ProductId = productId;
            Ammount = ammount;
            Price = price;
        }

        public OrderRowsEntity(DateTime rowAdded, int orderId, string productId, int ammount, int price)
        {
            RowAdded = rowAdded;
            OrderId = orderId;
            ProductId = productId;
            Ammount = ammount;
            Price = price;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime RowAdded { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ProductId { get; set; }

        public int Ammount { get; set; }
        public int Price { get; set; }

        public OrderEntity Order { get; set; }
        public ProductEntity Product { get; set; }
    }
}
