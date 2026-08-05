namespace DesignPatterns.ex10.Models
{
    public abstract class Utilizator
    {
        public string Prenume { get; }
        public string Nume { get; }

        protected Utilizator(string prenume, string nume)
        {
            if (string.IsNullOrWhiteSpace(prenume))
            {
                throw new ArgumentException("First name cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(nume))
            {
                throw new ArgumentException("Last name cannot be empty");
            }

            Prenume = prenume;
            Nume = nume;
        }

        public abstract string Descriere();
    }
}
