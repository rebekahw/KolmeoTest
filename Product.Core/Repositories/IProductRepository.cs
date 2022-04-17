using Product.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Core.Repositories
{
    public interface IProductRepository : IRepository<Models.Product>
    {
        Task<IEnumerable<Models.Product>> GetProductByName(string productName);
    }
}
