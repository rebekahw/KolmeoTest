using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Application.Exceptions;
using Product.Core.Repositories;
using Product.Infrastructure.Data;
using Product.Infrastructure.Repositories.Base;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Core.Models.Product>, IProductRepository
    {
        public ProductRepository(ProductContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Core.Models.Product>> GetProductByName(string productName)
        {
            var products = await _dbContext.Products.Where(p => p.Name == productName).ToListAsync();

            if (products.Count > 1)
                return products;

            throw new NotFoundException();
        }
    }
}
