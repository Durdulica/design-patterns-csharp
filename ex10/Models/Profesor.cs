namespace DesignPatterns.ex10.Models
{
    public class Profesor : Utilizator
    {
        public string Catedra { get; }

        public Profesor(string prenume, string nume, string catedra) : base(prenume, nume)
        {
            if (string.IsNullOrWhiteSpace(catedra))
            {
                throw new ArgumentException("Department cannot be empty");
            }

            Catedra = catedra;
        }

        public override string Descriere()
        {
            throw new NotImplementedException();
        }
    }
}
