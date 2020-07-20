using Application.Common.Queries;
using Application.Decorators.AuditLog;
using Application.Decorators.DatabaseRetry;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Products.Queries
{
    public class GetProductsQuery : IQuery<List<Product>>
    {
    }

    [AuditLog]
    [DatabaseRetry]
    internal class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, List<Product>>
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public GetProductsQueryHandler(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> Handle(GetProductsQuery query)
        {
            return _productRepository.GetAll().ToList();
        }
    }
}
