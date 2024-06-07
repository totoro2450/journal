using Journal.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Journal.Database.Context
{
    public class JournalContext: DbContext
    {
        public JournalContext(DbContextOptions<JournalContext> options) : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }

        public DbSet<ApplicationVersion> ApplicationVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Complicated Indexes
            //modelBuilder.Entity<TableName>().HasIndex(e => new { e.Column1, e.Column2 });
            //modelBuilder.Entity<TableName>().HasIndex(e => new { e.Column1, e.Column2 }).IsUnique();

            // Delete Behavior
            //modelBuilder.HasDefaultSchema("dbo");
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;

            // Set up Cascade Deletes
            //modelBuilder
            //    .Entity<TableName>()
            //    .HasOne(e => e.Column)
            //    .WithMany(e => e.Column2)
            //    .OnDelete(DeleteBehavior.Cascade);
        }

        // TrustServerCertificate=True;
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer(@$"Server=(local);Database={DatabaseConstants.DatabaseName};Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
