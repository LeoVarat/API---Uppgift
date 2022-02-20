using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.WebApi.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class CustomerEntity
    {
        public CustomerEntity(string firstName, string lastName, string email, int adressId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AdressId = adressId;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        public int AdressId { get; set; }

        public AdressEntity Adress { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
