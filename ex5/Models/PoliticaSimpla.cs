namespace DesignPatterns.ex5.Models
{
    public class PoliticaSimpla : IPoliticaParola
    {
        public string Nume { get; } = "Simpla";

        public bool EsteValida(string parola)
        {
            if(parola.Length < 6)
            {
                Console.WriteLine("The password must have at least 6 characters");
                return false;
            }

            return true;
        }
    }
}
