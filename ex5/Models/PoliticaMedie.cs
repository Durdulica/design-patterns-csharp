namespace DesignPatterns.ex5.Models
{
    public class PoliticaMedie : IPoliticaParola 
    {
        public string Nume { get; } = "Medie";

        public bool EsteValida(string parola)
        {
            if (parola.Length < 8)
            {
                return false;
            }

            for (int i = 0; i < parola.Length; i++)
            {
                if (Char.IsDigit(parola[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
