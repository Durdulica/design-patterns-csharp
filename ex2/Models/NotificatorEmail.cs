namespace DesignPatterns.ex2.Models
{
    public class NotificatorEmail : IObservator
    {
        public void Actualizeaza(string stareNoua)
        {
            Console.WriteLine("[EMAIL] Comanda a trecut in starea: " +  stareNoua);
        }
    }
}
