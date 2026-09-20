using DesignPatterns.ex3.Models;

namespace DesignPatterns.ex3
{
    public class Testare3
    {
        public Testare3()
        {
            string[] date =
            [
                "rand1",
                "rand2",
                "rand3",
                "rand4"
            ];

            Raport raport = new(date, new ExportCsv());

            Console.WriteLine(raport.NumeFormat + ":\n" + raport.Genereaza());

            raport.SchimbaFormat(new ExportText());

            Console.WriteLine(raport.NumeFormat + ":\n" + raport.Genereaza());

            raport.SchimbaFormat(new ExportMarkdown());

            Console.WriteLine(raport.NumeFormat + ":\n" + raport.Genereaza());
        }
    }
}
