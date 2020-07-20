using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Persistence
{
    public class AdsDbContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _dbContextTransaction;
        public AdsDbContext(DbContextOptions<AdsDbContext> options):base(options)
        {

        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _dbContextTransaction = Database.BeginTransaction(isolationLevel);
        }

        public void CommitTransaction()
        {
            _dbContextTransaction.Commit();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
