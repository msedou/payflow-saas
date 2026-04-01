public static class IBANMasker
{
          public static string Mask(string iban)
          {
                    if (string.IsNullOrEmpty(iban) || iban.Length < 8) return iban;
                    return string.Concat(iban.AsSpan(0, 4), "****", iban.AsSpan(iban.Length - 4));
          }
}
