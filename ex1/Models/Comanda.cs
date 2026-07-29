namespace DesignPatterns.ex1.Models
{
    public class Comanda
    {
        public string Client { get; }
        public decimal GreutateKg { get; }
        public decimal DistantaKm { get; }

        private ILivrareStrategie strategie;

        public Comanda(string client, decimal greutateKg, decimal distantaKm, ILivrareStrategie strategie)
        {
            if (greutateKg <= 0)
            {
                throw new ArgumentException("Weight must be positive");
            }

            if (distantaKm < 0)
            {
                throw new ArgumentException("Distance cannot be negative");
            }

            Client = client;
            GreutateKg = greutateKg;
            DistantaKm = distantaKm;
            this.strategie = strategie;
        }

        public void SchimbaStrategie(ILivrareStrategie noua)
        {
            strategie = noua;
        }

        public decimal CostTransport()
        {
            return strategie.CalculeazaCost(GreutateKg, DistantaKm);
        }
    }
}