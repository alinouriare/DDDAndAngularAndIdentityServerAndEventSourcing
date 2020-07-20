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
    public class FileEntryDeletedEventHandler : IDomainEventHandler<EntityDeletedEvent<FileEntry>>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageSender<FileDeletedEvent> _fileDeletedEventSender;

        public FileEntryDeletedEventHandler(IMessageSender<FileDeletedEvent> fileDeletedEventSender, IServiceProvider serviceProvider)
        {
            _fileDeletedEventSender = fileDeletedEventSender;
            _serviceProvider = serviceProvider;
        }

        public void Handle(EntityDeletedEvent<FileEntry> domainEvent)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditSerivce = scope.ServiceProvider.GetService<ICrudService<AuditLogEntry>>();
                var currentUser = scope.ServiceProvider.GetService<ICurrentUser>();

                auditSerivce.AddOrUpdate(new AuditLogEntry
                {
                    UserId = currentUser.IsAuthenticated ? currentUser.UserId : Guid.Empty,
                    CreatedDateTime = domainEvent.EventDateTime,
                    Action = "DELETE_FILEENTRY",
                    ObjectId = domainEvent.Entity.id.ToString(),
                    Log = domainEvent.Entity.AsJsonString(),
                });
            }

            // Forward to external systems
            _fileDeletedEventSender.Send(new FileDeletedEvent
            {
                FileEntry = domainEvent.Entity,
            });
        }
    }
}
