using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Application.Interfaces;

namespace Product.Infrastructure.Data
{
    public class ProductContext : DbContext, IProductContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Core.Models.Product> Products
        {
            get; 
            set;
        }
    }
}
