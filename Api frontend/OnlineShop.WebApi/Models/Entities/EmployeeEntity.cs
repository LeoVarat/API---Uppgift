using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.WebApi.Models.Entities
{
    [Index(nameof(EmploymentNumber), IsUnique = true)]
    public class EmployeeEntity
    {
        public EmployeeEntity(string firstName, string lastName, int employmentNumber, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            EmploymentNumber = employmentNumber;
            Email = email;
            Password = password;
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
        public int EmploymentNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
