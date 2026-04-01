// PayFlow.Util/Helpers/PdfInterop.cs
public static class PdfInterop
{
          [DllImport("cpp-generator.dll")]
          public static extern void ExportBulletin(string jsonPath, string outputPath);
}
