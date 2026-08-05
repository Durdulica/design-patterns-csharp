namespace DesignPatterns.ex5.Models
{
    public class PoliticaSimpla : IPoliticaParola
    {
        public string Nume { get; } = "Simpla";

        public bool EsteValida(string parola)
        {
            if(parola.Length < 6)
            {
                return false;
            }

            return true;
        }
    }
}
