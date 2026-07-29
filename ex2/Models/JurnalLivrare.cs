namespace DesignPatterns.ex2.Models
{
    public class JurnalLivrare : IObservator
    {
        public void Actualizeaza(string stareNoua)
        {
            Console.WriteLine("[LOG] Stare inregistrata: " + stareNoua);
        }
    }
}
