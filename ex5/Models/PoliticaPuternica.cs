namespace DesignPatterns.ex5.Models
{
    public class PoliticaPuternica : IPoliticaParola
    {
        public string Nume { get; } = "Puternica";

        public bool EsteValida(string parola) 
        {
            if (parola.Length < 8)
            {
                return false;
            }

            bool digit = false;
            bool bigLetter = false;
            bool notLetterOrDigit = false;
           
            for (int i = 0; i < parola.Length; i++)
            {
                if (digit == false && Char.IsDigit(parola[i]))
                {
                    digit = true;
                }
                if (bigLetter == false && Char.IsUpper(parola[i]))
                {
                    bigLetter = true;
                }
                if(notLetterOrDigit == false && !Char.IsLetterOrDigit(parola[i]))
                {
                    notLetterOrDigit = true;
                }
            }

            return digit && bigLetter && notLetterOrDigit;
        }
    }
}
