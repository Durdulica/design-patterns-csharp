namespace DesignPatterns.ex10.Models
{
    public class Admin : Utilizator
    {
        public int Salariu { get; private set; }

        public Admin(string prenume, string nume, int salariu) : base(prenume, nume) 
        {
            if(salariu < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }

            Salariu = salariu;
        }

        public override string Descriere()
        {
            return $"Admin: {Nume}, {Prenume}, salariu: {Salariu}";
        }
    }
}