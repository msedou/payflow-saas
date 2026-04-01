public static class PayrollDateUtils
{
          public static int GetElapsedDaysInMonth() => DateTime.UtcNow.Day;

          public static int GetTotalDaysInCurrentMonth()
                    => DateTime.DaysInMonth(DateTime.UtcNow.Year, DateTime.UtcNow.Month);

          public static decimal GetProrataProgress()
                    => (decimal)GetElapsedDaysInMonth() / GetTotalDaysInCurrentMonth();
}
