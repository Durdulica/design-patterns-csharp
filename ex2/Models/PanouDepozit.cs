namespace DesignPatterns.ex2.Models
{
    public class PanouDepozit : IObservator
    {
        public void Actualizeaza(string stareNoua)
        {
            Console.WriteLine("[DEPOZIT] Pregatesc pentru: " + stareNoua);
        }
    }
}
