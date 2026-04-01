[ApiController]
[Route("api/v1/payrolls")]
public class PayrollController : ControllerBase
{
          private readonly IPayrollService _service;

          public PayrollController(IPayrollService service)
          {
                    _service = service;
          }

          [HttpPost("run")]
          public async Task<IActionResult> Run(RunPayrollDto dto)
          {
                    var payroll = await _service.RunPayrollAsync(
                        dto.EmployeeId,
                        dto.BaseSalary
                    );

                    return Ok(payroll);
          }
}