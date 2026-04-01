// PayFlow.SharedKernel/ValueObjects/Montant.cs
public record Montant(decimal Amount, string Currency = "EUR")
{
          public Montant Ajouter(Montant autre) => this with { Amount = this.Amount + autre.Amount };
          // Logique d'arrondi bancaire (MidpointRounding.ToEven)
}
