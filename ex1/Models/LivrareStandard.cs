namespace DesignPatterns.ex1.Models
{
    public class LivrareStandard : ILivrareStrategie
    {
        public string Nume => "Standard";

        public decimal CalculeazaCost(decimal greutateKg, decimal distantaKm)
        {
            return 5 + (decimal)0.5 * greutateKg + (decimal)0.1 * distantaKm;
        }
    }
}
