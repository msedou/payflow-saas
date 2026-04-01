using Microsoft.EntityFrameworkCore;

public class PayrollDbContext : DbContext
{
          public PayrollDbContext(DbContextOptions<PayrollDbContext> options)
              : base(options) { }

          public DbSet<Payroll> Payrolls => Set<Payroll>();
}