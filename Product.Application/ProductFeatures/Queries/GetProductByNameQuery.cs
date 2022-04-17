using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Product.Core.Repositories;

namespace Product.Application.ProductFeatures.Queries
{
    public class GetProductByNameQuery : IRequest<IEnumerable<Core.Models.Product>>
    {
        public string ProductName { get; set; }
        public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, IEnumerable<Core.Models.Product>>
        {
            private readonly IProductRepository _repo;
            public GetProductByNameQueryHandler(IProductRepository repo)
            {
                _repo = repo;
            }

            public async Task<IEnumerable<Core.Models.Product>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
            {
                return await _repo.GetProductByName(request.ProductName);
            }
        }
    }
}
