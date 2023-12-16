using Microsoft.EntityFrameworkCore;
using MoorCodeSofia.Domain;

namespace MoorCodeSofia.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        //    : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //    // in memory database used for simplicity, change to a real db for production applications
            //   // options.UseInMemoryDatabase("testdb");
            // options.UseSqlite("Data Source=AuthorsData.db");
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);


        }
        public DbSet<UserTask> UserTasks { get; set; }
    }
}