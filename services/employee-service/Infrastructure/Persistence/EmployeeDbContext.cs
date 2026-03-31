using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Infrastructure.Persistence;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options) { }

    public DbSet<Employee> Employees => Set<Employee>();
}