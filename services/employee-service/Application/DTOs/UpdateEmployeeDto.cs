using System;

namespace employee_service.Application.DTOs;

public record UpdateEmployeeDto(
          string FirstName,
          string LastName,
          string Email,
          string PhoneNumber,
          string Address
);
