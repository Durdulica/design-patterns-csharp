namespace DesignPatterns.ex1.Models
{
    public class LivrareExpress : ILivrareStrategie
    {
        public string Nume => "Express";

        public decimal CalculeazaCost(decimal greutateKg, decimal distantaKm)
        {
            throw new NotImplementedException();
        }
    }
}
