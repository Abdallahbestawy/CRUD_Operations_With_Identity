using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace tran1.Models
{
    public class CRContext:IdentityDbContext
    {
        public CRContext(DbContextOptions<CRContext> options):base(options)
        {
                
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
