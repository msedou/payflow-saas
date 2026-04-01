public interface IPayrollService
{
          Task<Payroll> RunPayrollAsync(Guid employeeId, decimal baseSalary);
}