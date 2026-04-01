// PayFlow.Contrat/Interfaces/IPayrollService.cs
public interface IPayrollService
{
          Task<BulletinResponse> CalculerMensuelAsync(CalculRequest request);
}
