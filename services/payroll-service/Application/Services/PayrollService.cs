public class PayrollService : IPayrollService
{
          public async Task<Payroll> RunPayrollAsync(Guid employeeId, decimal baseSalary)
          {
                    // 👉 règle simple (Sénégal MVP)
                    var tax = baseSalary * 0.20m; // 20%
                    var net = baseSalary - tax;

                    var payroll = new Payroll
                    {
                              Id = Guid.NewGuid(),
                              EmployeeId = employeeId,
                              BaseSalary = baseSalary,
                              Tax = tax,
                              NetSalary = net,
                              Period = DateTime.UtcNow,
                              CreatedAt = DateTime.UtcNow
                    };

                    return await Task.FromResult(payroll);
          }
}