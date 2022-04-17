using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Product.Core.Repositories;

namespace Product.Application.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Core.Models.Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Core.Models.Product>>
        {
            private readonly IProductRepository _productRepo;
            public GetAllProductsQueryHandler(IProductRepository repo)
            {
                _productRepo = repo;
            }
            public async Task<IEnumerable<Core.Models.Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                return await _productRepo.GetAllAsync();
            }
        }
    }
}
