using System;
using employee_service.Application.DTOs;
using EmployeeService.Application.DTOs;

namespace employee_service.Application;

public interface IEmployeeService
{
          public Task<Employee> GetMyProfileAsync();
          public Task<Employee> UpdateMyProfileAsync(UpdateEmployeeDto updateEmployeeDto);
}
