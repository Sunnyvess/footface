using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FootFace.Core.Entities;

namespace FootFace.Core.Repositories.Implementation
{
    public class FootFaceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public FootFaceDbContext()
            : base("FootFace_1_1") { }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Vise o tome na: http://msdn.microsoft.com/en-us/library/hh770082(v=vs.103).aspx

            // Configure Code First to ignore PluralizingTableName convention
            // If you keep this convention then the generated tables will have pluralized names.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}
