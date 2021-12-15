using MKT.Entities.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MKT.Data
{
    public class MKTDbContext : DbContext
    {
        public MKTDbContext() : base(nameOrConnectionString: "DefaultConnection") { }
        public DbSet<Cart> Carritos { get; set; }
        public DbSet<Category> CategoriasProductos { get; set; }
        public DbSet<OrderDetail> DetallesOrders { get; set; }
        public DbSet<Address> Direcciones { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> ItemsCarrito { get; set; }
        public DbSet<Product> Productos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Usuarios { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
