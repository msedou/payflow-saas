public record EmployeeContractDto(
    Guid Id,
    string FullName,
    string Email,
    string Iban,
    Money CurrentMonthlySalary);
