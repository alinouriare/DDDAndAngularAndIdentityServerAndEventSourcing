using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Repositories
{
   public interface IUnitOfWork
    {
        int SaveChanges();

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void CommitTransaction();
    }
}
