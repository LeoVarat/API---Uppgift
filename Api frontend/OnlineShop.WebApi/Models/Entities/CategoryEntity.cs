using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.WebApi.Models.Entities
{
    [Index(nameof(CategoryName), IsUnique = true)]
    public class CategoryEntity
    {
        public CategoryEntity(string categoryName)
        {
            CategoryName = categoryName;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
