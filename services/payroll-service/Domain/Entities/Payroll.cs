namespace PayrollService.Domain.Entities;

public class Payroll
{
          public Guid Id { get; set; }

          public Guid EmployeeId { get; set; }

          public decimal BaseSalary { get; set; }

          public decimal Tax { get; set; }

          public decimal NetSalary { get; set; }

          public DateTime Period { get; set; }

          public DateTime CreatedAt { get; set; }
}