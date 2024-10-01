using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Contexts
{
    public class StoreDbContext :DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
         : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()):
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Product { set; get; }
        public DbSet<ProductType> ProductTypes { set; get; }
        public DbSet<ProductBrand> ProductBrands { set; get; }
    }
}
