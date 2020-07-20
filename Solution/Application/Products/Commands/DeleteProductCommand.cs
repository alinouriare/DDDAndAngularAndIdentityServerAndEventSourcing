using Application.Common.Commands;
using Application.Common.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public Product Product { get; set; }
    }

    internal class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly ICrudService<Product> _productService;

        public DeleteProductCommandHandler(ICrudService<Product> productService)
        {
            _productService = productService;
        }

        public void Handle(DeleteProductCommand command)
        {
            _productService.Delete(command.Product);
        }
    }
}
