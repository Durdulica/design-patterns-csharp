namespace DesignPatterns.ex3.Models
{
    public class ExportMarkdown : IExportStrategie
    {
        public string Nume { get; } = "Markdown";

        public string Formateaza(string[] randuri)
        {
            string rez = string.Empty;

            rez += "- " + randuri[0];

            for(int i = 1; i < randuri.Length; i++)
            {
                rez += "\n- " + randuri[i];
            }

            return rez;
        }
    }
}