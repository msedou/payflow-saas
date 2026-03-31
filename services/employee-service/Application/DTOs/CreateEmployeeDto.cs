namespace EmployeeService.Application.DTOs;

public record CreateEmployeeDto(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Address,
    decimal BaseSalary
);
