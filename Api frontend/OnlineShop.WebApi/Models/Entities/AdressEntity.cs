using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.WebApi.Models.Entities
{
    public class AdressEntity
    {
        public AdressEntity(string adress, int postalNumber, string city)
        {
            Adress = adress;
            PostalNumber = postalNumber;
            City = city;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Adress { get; set; }
        [Required]
        public int PostalNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        public virtual ICollection<CustomerEntity> Customers { get; set; }
    }
}
