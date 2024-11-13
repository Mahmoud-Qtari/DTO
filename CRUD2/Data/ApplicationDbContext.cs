using CRUD2.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD2.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):
            base(options){ }

        public DbSet<Employeee> employeees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
