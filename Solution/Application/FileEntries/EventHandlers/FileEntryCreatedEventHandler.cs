using Application.Common.Services;
using Application.FileEntries.DTOs;
using CrossCuttingsConcerns.ExtensionMethods;
using Domain.Entities;
using Domain.Event;
using Domain.Identity;
using Domain.Infrastructure.MessageBrokers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FileEntries.EventHandlers
{
    public class FileEntryCreatedEventHandler : IDomainEventHandler<EntityCreatedEvent<FileEntry>>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageSender<FileUploadedEvent> _fileUploadedEventSender;

        public FileEntryCreatedEventHandler(IMessageSender<FileUploadedEvent> fileUploadedEventSender, IServiceProvider serviceProvider)
        {
            _fileUploadedEventSender = fileUploadedEventSender;
            _serviceProvider = serviceProvider;
        }

        public void Handle(EntityCreatedEvent<FileEntry> domainEvent)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditSerivce = scope.ServiceProvider.GetService<ICrudService<AuditLogEntry>>();
                var currentUser = scope.ServiceProvider.GetService<ICurrentUser>();

                auditSerivce.AddOrUpdate(new AuditLogEntry
                {
                    UserId = currentUser.IsAuthenticated ? currentUser.UserId : Guid.Empty,
                    CreatedDateTime = domainEvent.EventDateTime,
                    Action = "CREATED_FILEENTRY",
                    ObjectId = domainEvent.Entity.id.ToString(),
                    Log = domainEvent.Entity.AsJsonString(),
                });
            }

            // Forward to external systems
            _fileUploadedEventSender.Send(new FileUploadedEvent
            {
                FileEntry = domainEvent.Entity,
            });
        }
    }
}
