using Application.Common.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.Services
{
    public interface IProductService : ICrudService<Product>
    {
    }
}
