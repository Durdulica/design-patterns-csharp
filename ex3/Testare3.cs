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

            Raport raport = new Raport(date, new ExportCsv());

            Console.WriteLine(raport.NumeFormat + ":\n" + raport.Genereaza());

            raport.SchimbaFormat(new ExportText());

            Console.WriteLine(raport.NumeFormat + ":\n" + raport.Genereaza());

            raport.SchimbaFormat(new ExportMarkdown());

            Console.WriteLine(raport.NumeFormat + ":\n" + raport.Genereaza());
        }
    }
}
