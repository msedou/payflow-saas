using System;
using employee_service.Domain.Entities;

namespace employee_service.Infrastructure.Repository;

public interface IAdvanceRequestRepository
{
          Task<AdvanceRequest?> GetByIdAsync(Guid id);
          Task<IEnumerable<AdvanceRequest>> GetByEmployeeIdAsync(Guid employeeId);
          Task AddAsync(AdvanceRequest request);
          Task UpdateAsync(AdvanceRequest request);
          // On travaille avec des objets métier, pas des tables
}
