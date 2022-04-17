using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Application.Exceptions;
using Product.Core.Repositories.Base;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ProductContext _dbContext;
        public Repository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var products = await _dbContext.Set<T>().ToListAsync();
            if (products != null)
                return products;
            throw new NotFoundException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var product = await _dbContext.Set<T>().FindAsync(id);
            if (product != null)
                return product;
            throw new NotFoundException();
        }
    }
}
