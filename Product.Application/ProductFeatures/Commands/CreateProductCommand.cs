using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Product.Core.Repositories;

namespace Product.Application.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<Core.Models.Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Core.Models.Product>
        {
            private readonly IProductRepository _productRepo;
            public CreateProductCommandHandler(IProductRepository productRepo)
            {
                _productRepo = productRepo;
            }
            public async Task<Core.Models.Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Core.Models.Product();
                product.Name = command.Name;
                product.Price = command.Price;
                product.Description = command.Description;
                await _productRepo.AddAsync(product);
                return product;
            }
        }
    }
}
