namespace DesignPatterns.ex3.Models
{
    public class ExportText : IExportStrategie
    {
        public string Nume { get; } = "Text";

        public string Formateaza(string[] randuri)
        {
            if (randuri.Length == 0) return string.Empty;

            string rez = string.Empty;

            rez += 1 + ". " + randuri[0];

            for (int i = 1; i < randuri.Length; i++)
            {
                rez += "\n" + (i + 1) + ". " + randuri[i];
            }

            return rez;
        }
    }
}
