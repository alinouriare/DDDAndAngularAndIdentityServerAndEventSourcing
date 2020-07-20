using Application.Common.Services;
using Domain.Entities;
using Domain.Event;
using Domain.Identity;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.Services
{
   public class ProductService:CrudService<Product> ,IProductService
    {
        public ProductService(IRepository<Product, Guid> productRepository, IDomainEvents domainEvents, ICurrentUser currentUser)
            : base(productRepository, domainEvents)
        {
        }
    }
}
