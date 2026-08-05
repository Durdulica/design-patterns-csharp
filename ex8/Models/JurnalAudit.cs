namespace DesignPatterns.ex8.Models
{
    public class JurnalAudit : IObservatorCont
    {
        public void Actualizeaza(decimal soldNou)
        {
            Console.WriteLine("[AUDIT] Sold inregistrat: " + soldNou);
        }
    }
}
