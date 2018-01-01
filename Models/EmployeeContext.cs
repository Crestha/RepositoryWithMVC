using System.Data.Entity;

namespace RepositoryWithMVC.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=CompanyContext")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}