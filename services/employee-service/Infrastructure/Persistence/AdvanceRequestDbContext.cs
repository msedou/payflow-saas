using System;
using employee_service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace employee_service.Infrastructure.Persistence;

public class AdvanceRequestDbContext : DbContext
{
          public AdvanceRequestDbContext(DbContextOptions<AdvanceRequestDbContext> options)
                    : base(options) { }
          public DbSet<AdvanceRequest> AdvanceRequests => Set<AdvanceRequest>();
}
