namespace DesignPatterns.ex3.Models
{
    public class ExportCsv : IExportStrategie
    {
        public string Nume { get; } = "CSV";

        public string Formateaza(string[] randuri)
        {
            if (randuri.Length == 0) return string.Empty;

            string rez = string.Empty;

            rez += randuri[0];

            for (int i = 1; i < randuri.Length; i++) 
            {
                rez += "," + randuri[i];
            }

            return rez;
        }
    }
}
