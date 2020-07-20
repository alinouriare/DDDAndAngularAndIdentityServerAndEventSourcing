using Application.Common.Services;
using CrossCuttingsConcerns.ExtensionMethods;
using Domain.Entities;
using Domain.Event;
using Domain.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.EventHandlers
{
    public class ProductDeletedEventHandler : IDomainEventHandler<EntityDeletedEvent<Product>>
    {
        private readonly IServiceProvider _serviceProvider;

        public ProductDeletedEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Handle(EntityDeletedEvent<Product> domainEvent)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditSerivce = scope.ServiceProvider.GetService<ICrudService<AuditLogEntry>>();
                var currentUser = scope.ServiceProvider.GetService<ICurrentUser>();

                auditSerivce.AddOrUpdate(new AuditLogEntry
                {
                    UserId = currentUser.UserId,
                    CreatedDateTime = domainEvent.EventDateTime,
                    Action = "DELETED_PRODUCT",
                    ObjectId = domainEvent.Entity.id.ToString(),
                    Log = domainEvent.Entity.AsJsonString(),
                });
            }
        }
    }
}
