namespace DesignPatterns.ex8.Models
{
    public class NotificatorSms : IObservatorCont
    {
        public void Actualizeaza(decimal soldNou)
        {
            Console.WriteLine("[SMS] Sold nou: " + soldNou);
        }
    }
}
