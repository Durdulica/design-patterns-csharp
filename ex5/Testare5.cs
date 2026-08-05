using DesignPatterns.ex5.Models;

namespace DesignPatterns.ex5
{
    public class Testare5
    {
        public Testare5()
        {
            string parola = "abc123";
            string parolaPuternica = "Abc123!x";
            PoliticaSimpla politica = new();
            CampParola campParola = new CampParola(politica);

            Console.Write(politica.Nume + ": ");
            campParola.Verifica(parola);

            PoliticaMedie medie = new();
            campParola.SchimbaPolitica(medie);
            Console.Write(medie.Nume + ": ");
            campParola.Verifica(parola);

            PoliticaPuternica puternica = new();
            campParola.SchimbaPolitica(puternica);
            Console.Write(puternica.Nume + ": ");
            campParola.Verifica(parola);

            Console.Write(puternica.Nume + ": ");
            campParola.Verifica(parolaPuternica);
        }
    }
}
