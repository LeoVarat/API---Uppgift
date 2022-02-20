using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.WebApi.Models.Entities
{
    [Index(nameof(ProductNumber), IsUnique = true)]
    public class ProductEntity
    {
        public ProductEntity(string productNumber, string name, string description, int price)
        {
            ProductNumber = productNumber;
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductEntity(string productNumber, string name, string description, int price, int categoryId)
        {
            ProductNumber = productNumber;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        public ProductEntity(int id, string productNumber, string name, string description, int price, int categoryId)
        {
            Id = id;
            ProductNumber = productNumber;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProductNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public virtual ICollection<OrderRowsEntity> OrderRows { get; set; }

    }
}
