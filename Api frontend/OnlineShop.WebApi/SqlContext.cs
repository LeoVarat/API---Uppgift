using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.Models.Entities;

namespace OnlineShop.WebApi
{
    public class SqlContext : DbContext
    {
        protected SqlContext()
        {
        }

        public SqlContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<AdressEntity> Adresses { get; set; }

        public virtual DbSet<CustomerEntity> Customers { get; set; }

        public virtual DbSet<OrderEntity> Orders { get; set; }

        public virtual DbSet<StatusTypeEntity> StatusTypes { get; set; }

        public virtual DbSet<CategoryEntity> Categories { get; set; }

        public virtual DbSet<ProductEntity> Product { get; set; }

        public virtual DbSet<OrderRowsEntity> OrderRows { get; set; }

        public virtual DbSet<EmployeeEntity> Employees { get; set; }
    }
}
