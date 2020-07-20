using Application.Common.Queries;
using CrossCuttingsConcerns.Exceptions;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Products.Queries
{
   public class GetProductQuery:IQuery<Product>
    {
        public Guid Id { get; set; }
        public bool ThrowNotFoundIfNull { get; set; }
    }

    internal class GetProductQueryHandler : IQueryHandler<GetProductQuery, Product>
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public GetProductQueryHandler(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Handle(GetProductQuery query)
        {
            var product = _productRepository.GetAll().FirstOrDefault(x => x.id == query.Id);

            if (query.ThrowNotFoundIfNull && product == null)
            {
                throw new NotFoundException($"Product {query.Id} not found.");
            }

            return product;
        }
    }
}
