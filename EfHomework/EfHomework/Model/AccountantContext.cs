using Microsoft.EntityFrameworkCore;

namespace EfHomework.Model
{
    public class AccountantContext : DbContext
    {
        public AccountantContext(DbContextOptions<AccountantContext> options) :
            base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Accountant;User Id=sa;Password=test;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
             .HasMany(s => s.Tasks)
             .WithMany(b => b.Employees)
             .UsingEntity<EmployeeTask>
              (bs => bs.HasOne<Task>().WithMany(),
               bs => bs.HasOne<Employee>().WithMany());

        }
    }
}
