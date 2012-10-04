using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SimpleCMS.Core.Entities;
using System.Configuration;

namespace SimpleCMS.Core.Repositories.Implementation
{
    public class SimpleCMSDbContext : DbContext
    {
     
       
        public DbSet<User> Users { get; set; }
       

        public SimpleCMSDbContext()
            : base(ConfigurationSettings.AppSettings["DatabaseName"].ToString()) 
        
        { }
    
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
