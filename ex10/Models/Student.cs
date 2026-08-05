namespace DesignPatterns.ex10.Models
{
    public class Student : Utilizator
    {
        public string An { get; }

        public Student(string prenume, string nume, string an) : base(prenume, nume)
        {
            if (string.IsNullOrWhiteSpace(an))
            {
                throw new ArgumentException("Study year cannot be empty");
            }

            An = an;
        }

        public override string Descriere()
        {
            throw new NotImplementedException();
        }
    }
}
