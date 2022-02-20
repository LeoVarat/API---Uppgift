using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.WebApi.Models.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class StatusTypeEntity
    {
        public StatusTypeEntity(string name)
        {
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string Name { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }

    }
}
