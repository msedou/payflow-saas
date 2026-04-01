namespace PayrollService.Application.DTOs;

public record RunPayrollDto(
    Guid EmployeeId,
    decimal BaseSalary
);