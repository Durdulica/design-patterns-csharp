namespace DesignPatterns.ex8.Models
{
    public class Cont
    {
        
        private IObservatorCont[] observatori;
        public decimal Sold { get; private set; }

        public Cont(decimal sold, IObservatorCont[] observatori)
        {
            Sold = sold;
            this.observatori = observatori;
        }

        private void NotificaObservatori()
        {
            for (int i = 0; i < observatori.Length; i++)
            {
                observatori[i].Actualizeaza(Sold);
            }
        }

        public void Depune(decimal suma)
        {
            if (suma < 0)
            {
                throw new ArgumentException("Deposit amount must be positive");
            }
            Sold += suma;

            NotificaObservatori();
        }

        public void Retrage(decimal suma) 
        {
            if(suma < 0)
            {
                throw new ArgumentException("Withdraw amount must be positive");
            }
            if(suma > Sold)
            {
                throw new InvalidOperationException("Not enough money in the account");
            }

            Sold -= suma;
            
            NotificaObservatori();
        }
    }
}
