using DesignPatterns.ex3.Models;

namespace DesignPatterns.ex3
{
    public class Testare3
    {
        public Testare3()
        {
            string[] date =
            {
                "bia",
                "este",
                "o prietena",
                "foarte buna"
            };

            ExportCsv strategie = new();
            Raport raport = new Raport(date, strategie);

            Console.WriteLine(strategie.Nume + ":\n" + raport.Exporta());

            ExportText text = new();
            raport.SchimbaStrategie(text);

            Console.WriteLine(text.Nume + ":\n" + raport.Exporta());

            ExportMarkdown markdown = new();
            raport.SchimbaStrategie(markdown);

            Console.WriteLine(markdown.Nume + ":\n" + raport.Exporta());
        }
    }
}
