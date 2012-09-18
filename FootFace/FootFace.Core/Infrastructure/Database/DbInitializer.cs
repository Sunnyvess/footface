using System.Data.Entity;
using FootFace.Core.Repositories.Implementation;
using FootFace.Core.Repositories;

namespace FootFace.Core.Infrastructure.Database
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<FootFaceDbContext>
    {
        protected override void Seed(FootFaceDbContext context)
        {
            IUserRepository r = new UserRepository();
            r.Find(1);
        }
    }
}
