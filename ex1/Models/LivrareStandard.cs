namespace DesignPatterns.ex1.Models
{
    public class LivrareStandard : ILivrareStrategie
    {
        public string Nume => "Standard";

        public decimal CalculeazaCost(decimal greutateKg, decimal distantaKm)
        {
            return 5 + 1.0m * greutateKg + 0.25m * distantaKm;
        }
    }
}
