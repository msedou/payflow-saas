public interface IEmployeeContract
{
          Task<Result<EmployeeContractDto>> GetEmployeeDetailsAsync(Guid employeeId);
          Task<bool> ExistsAsync(Guid employeeId);
}
