public record SalaryAdvanceRequestedIntegrationEvent(
          Guid RequestId,
          Guid EmployeeId,
          decimal RequestedAmount,
          DateTime OccurredOn
);
