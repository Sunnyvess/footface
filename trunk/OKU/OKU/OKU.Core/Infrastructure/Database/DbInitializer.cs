using System.Data.Entity;
using OKU.Core.Repositories.Implementation;

namespace OKU.Core.Infrastructure.Database
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<OkuDbContext>
    {
        protected override void Seed(OkuDbContext context)
        {
                     
        }
    }
}
