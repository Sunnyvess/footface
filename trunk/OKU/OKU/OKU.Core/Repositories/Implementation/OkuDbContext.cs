using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Entities.PageStructure;
using OKU.Core.Entities.MaterialStructure;
using OKU.Core.Entities.CodeBookStructure;
using OKU.Core.Entities;

namespace OKU.Core.Repositories.Implementation
{
    public class OkuDbContext : DbContext
    {
        public DbSet<CodePlan> CodePlans { get; set; }
        public DbSet<CodePlanEntry> CodePlanEntries { get; set; }

        public DbSet<AttendeeMaterialVersion> AttendeeMaterialStructures { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<MaterialVersionCluster> ClusterVersions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<DigitalMaterial> Materials { get; set; }
        public DbSet<DigitalMaterialType> MaterialTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<MaterialVersion> Versions { get; set; }

        public DbSet<PageSet> PageSets { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<ViewItem> ViewItems { get; set; }
        public DbSet<ViewItemSet> ViewItemSets { get; set; }
        public DbSet<ViewItemPageFilter> ViewItemPageFilters { get; set; }
       
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Iteration> Iterations { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<AttendeeGroup> AttendeeGroups { get; set; }      
        public DbSet<ExecutionDefinition> ExecutionDefinitions { get; set; }
        public DbSet<ExecutionDefinitionGroup> ExecutionDefinitionGroups { get; set; }
        public DbSet<ParameterValue> ParameterValues { get; set; }
        public DbSet<ParameterDefinition> ParameterDefinitions { get; set; }      
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UserLogonHistory> UserLogonHistories { get; set; }

        public OkuDbContext()
            : base("OKU_3_2") { }
    
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
