public class Employee
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public decimal BaseSalary { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; } = true;
}
