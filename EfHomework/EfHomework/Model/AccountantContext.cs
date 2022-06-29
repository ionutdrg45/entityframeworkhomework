using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfHomework.Model
{
    public class AccountantContext : DbContext
    {
        public AccountantContext(DbContextOptions<AccountantContext> options) :
            base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<EmployeeTasks> EmpoyeeTasks { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Accountant;User Id=sa;Password=test");
            }
        }
    }
}
