namespace DesignPatterns.ex8.Models
{
    public class AlertaSoldMic : IObservatorCont
    {
        private decimal prag;

        public AlertaSoldMic(decimal prag)
        {
            this.prag = prag;
        }

        public void Actualizeaza(decimal soldNou)
        {
            if(soldNou < prag)
            {
                Console.WriteLine("[ALERTA] Sold sub prag: " + soldNou);
            }
        }
    }
}
