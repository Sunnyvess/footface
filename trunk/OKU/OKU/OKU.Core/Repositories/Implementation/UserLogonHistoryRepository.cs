using System;
using System.Linq;
using System.Transactions;
using OKU.Core.Entities;
using OKU.Core.Infrastructure.Extensions;

namespace OKU.Core.Repositories.Implementation
{
    public class UserLogonHistoryRepository : RepositoryBase<OkuDbContext, UserLogonHistory>, IUserLogonHistoryRepository
    {
        public UserLogonHistoryRepository()
        {
            this.Initialize(x => x.UserLogonHistories);
        }
    }
}
