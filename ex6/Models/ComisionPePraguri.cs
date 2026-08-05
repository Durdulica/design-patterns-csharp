namespace DesignPatterns.ex6.Models
{
    public class ComisionPePraguri : IComision
    {
        public string Nume { get; } = "Pe praguri";

        public decimal Calculeaza(decimal valoareVanzare)
        {
            decimal diff = valoareVanzare - 1000;
            if(diff <= 0)
            {
                return 0.05m * valoareVanzare;
            }

            return 0.05m * 1000 + 0.1m * diff;
        }
    }
}