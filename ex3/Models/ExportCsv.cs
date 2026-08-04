namespace DesignPatterns.ex3.Models
{
    public class ExportCsv : IExportStrategie
    {
        public string Nume { get; } = "CSV";

        public string Formateaza(string[] randuri)
        {
            string rez = string.Empty;

            rez += randuri[0];

            for (int i = 0; i < randuri.Length; i++) 
            {
                rez += ',' + randuri[i];
            }

            return rez;
        }
    }
}
