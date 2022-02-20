using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.WebApi.Models.Entities
{
    public class OrderEntity
    {
        public OrderEntity(DateTime created, DateTime lastUpdate, int statusTypeId, int customerId)
        {
            Created = created;
            LastUpdate = lastUpdate;
            StatusTypeId = statusTypeId;
            CustomerId = customerId;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="datetime2")]
        public DateTime Created { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdate { get; set; }

        public int StatusTypeId { get; set; }

        public int CustomerId { get; set; }

        public StatusTypeEntity StatusType { get; set; }

        public CustomerEntity Customer { get; set; }

        public virtual ICollection<OrderRowsEntity> OrderRows { get; set; }

    }
}
