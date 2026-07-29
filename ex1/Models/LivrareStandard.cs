namespace DesignPatterns.ex1.Models
{
    public class LivrareStandard : ILivrareStrategie
    {
        public string Nume => "Standard";

        public decimal CalculeazaCost(decimal greutateKg, decimal distantaKm)
        {
            throw new NotImplementedException();
        }
    }
}
