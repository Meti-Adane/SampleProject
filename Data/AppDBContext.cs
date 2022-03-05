
using Microsoft.EntityFrameworkCore;
using sitesampleproject.Models;
namespace sitesampleproject.Data{
    public class AppDBContext : DbContext{
        

        public AppDBContext (DbContextOptions<AppDBContext> options) :base(options){ }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<SaleRecord> SaleRecords => Set<SaleRecord>();
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<User> Users => Set<User>();
        public DbSet<SalesPerson> SalesPerson => Set<SalesPerson>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Unit> Units => Set<Unit>();
        public DbSet<Branch> Branches => Set<Branch>();
    }
}