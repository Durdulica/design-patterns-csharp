namespace DesignPatterns.ex5.Models
{
    public class PoliticaPuternica : IPoliticaParola
    {
        public string Nume { get; } = "Puternica";

        public bool EsteValida(string parola) 
        {
            if (parola.Length < 8)
            {
                Console.WriteLine("The password must contain at least 8 characters");
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
                else if (bigLetter == false && Char.IsUpper(parola[i]))
                {
                    bigLetter = true;
                }
                else if(notLetterOrDigit == false && !Char.IsLetterOrDigit(parola[i]))
                {
                    notLetterOrDigit = true;
                }
            }

            if(!digit)
            {
                Console.WriteLine("The password must contain at least one digit");
                return false;
            }
            if (!bigLetter)
            {
                Console.WriteLine("The password must contain at least one uppercase letter");
                return false;
            }
            if (!notLetterOrDigit)
            {
                Console.WriteLine("The password must contain at least one special character");
                return false;
            }

            return true;
        }
    }
}
