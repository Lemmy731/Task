using Microsoft.EntityFrameworkCore;
using MiskStartupSchool.Entities;

namespace MiskStartupSchool.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

       public DbSet<MyApplicationForm> application { get; set; }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var accountEndpoint = "https://localhost:8081";
            var accountKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
            var dbName = "My-Cosmos";
            optionsBuilder.UseCosmos(accountEndpoint, accountKey, dbName);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MyApplicationForm>()
                .ToContainer("application")
                .HasPartitionKey(x => x.ApplicationId);

            builder.Entity<MyApplicationForm>().OwnsMany(x => x.Educations);
            builder.Entity<MyApplicationForm>().OwnsMany(x => x.Experiences);
            builder.Entity<MyApplicationForm>().OwnsMany(x => x.stages).OwnsMany(x => x.InterviewQuestion);
        }
    }
}
