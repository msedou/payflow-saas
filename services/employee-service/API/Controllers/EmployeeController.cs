using Microsoft.AspNetCore.Mvc;
using EmployeeService.Application.DTOs;
using EmployeeService.Infrastructure.Persistence;
using EmployeeService.Domain.Entities;

namespace EmployeeService.API.Controllers;

[ApiController]
[Route("api/v1/employees")]
public class EmployeeController : ControllerBase
{
          private readonly EmployeeDbContext _db;

          public EmployeeController(EmployeeDbContext db)
          {
                    _db = db;
          }

          [HttpPost]
          public async Task<IActionResult> Create(CreateEmployeeDto dto)
          {
                    var employee = new Employee
                    {
                              Id = Guid.NewGuid(),
                              FirstName = dto.FirstName,
                              LastName = dto.LastName,
                              Email = dto.Email,
                              BaseSalary = dto.BaseSalary,
                              HireDate = DateTime.UtcNow
                    };

                    await _db.Employees.AddAsync(employee);
                    await _db.SaveChangesAsync();

                    return Ok(employee);
          }

          [HttpGet]
          public IActionResult GetAll()
          {
                    var employees = _db.Employees.ToList();
                    return Ok(employees);
          }
}