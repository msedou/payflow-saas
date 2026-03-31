using System;
using employee_service.Application.DTOs;

namespace employee_service.Application.service;

public class EmployeeService : IEmployeeService
{
          public Task<Employee> GetMyProfileAsync()
          {
                    throw new NotImplementedException();
          }

          public Task<Employee> UpdateMyProfileAsync(UpdateEmployeeDto updateEmployeeDto)
          {
                    throw new NotImplementedException();
          }
}
