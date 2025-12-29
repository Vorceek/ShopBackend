using Microsoft.EntityFrameworkCore;
using ShopBackend.Models;

namespace ShopBackend.Data {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
