using System.Data.Entity;
using SimpleCMS.Core.Repositories.Implementation;

namespace SimpleCMS.Core.Infrastructure.Database
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<SimpleCMSDbContext>
    {
        protected override void Seed(SimpleCMSDbContext context)
        {
                     
        }
    }
}
