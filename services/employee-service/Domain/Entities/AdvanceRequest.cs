using System;
using employee_service.Domain.Enum;

namespace employee_service.Domain.Entities;

public class AdvanceRequest
{
          public Guid Id { get; set; }
          public Guid EmployeeId { get; set; }
          public decimal Amount { get; set; }
          public RequestStatus Status { get; set; }
          public DateTime RequestDate { get; set; } = DateTime.UtcNow;
          public DateTime? PaymentDate { get; set; }
          public string TransactionReference { get; set; }
}
