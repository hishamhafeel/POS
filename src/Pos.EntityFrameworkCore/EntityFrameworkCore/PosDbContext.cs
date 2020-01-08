using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Pos.Authorization.Roles;
using Pos.Authorization.Users;
using Pos.MultiTenancy;
using Pos.Order;
using Pos.Products;
using Pos.Customers;

namespace Pos.EntityFrameworkCore
{
    public class PosDbContext : AbpZeroDbContext<Tenant, Role, User, PosDbContext>
    {
        public DbSet<Orders.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public PosDbContext(DbContextOptions<PosDbContext> options)
            : base(options)
        {
        }
    }
}
