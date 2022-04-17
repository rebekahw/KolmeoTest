using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Product.Application.Interfaces
{
    public interface IProductContext
    {
        DbSet<Core.Models.Product> Products { get; set; }
        //Task<int> SaveChanges();
    }
}
