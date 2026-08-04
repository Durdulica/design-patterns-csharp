namespace DesignPatterns.ex2.Models
{
    public class Comanda
    {
        public string Stare { get; private set; }

        private IObservator[] observatori;

        public Comanda(IObservator[] observatori)
        {
            Stare = "Plasata";
            this.observatori = observatori;
        }

        public void Aboneaza(IObservator nou)
        {
            IObservator[] obsNou = new IObservator[observatori.Length + 1];
            for (int i = 0; i < observatori.Length; i++) 
            {
                obsNou[i] = observatori[i];
            }

            obsNou[observatori.Length] = nou;
            observatori = obsNou;
        }

        public void Dezaboneaza(IObservator vechi)
        {
            int cnt = 0;
            for (int i = 0; i < observatori.Length; i++)
            {
                if (observatori[i] != vechi)
                {
                    cnt++;
                }
            }

            IObservator[] obsNou = new IObservator[cnt];
            int index = 0;
            for(int i = 0; i < observatori.Length; i++)
            {
                if(observatori[i] != vechi)
                {
                    obsNou[index++] = observatori[i];
                }
            }

            observatori = obsNou;
        }

        public void SchimbaStare(string stareNoua)
        {
            if(Stare == stareNoua) return;

            Stare = stareNoua;
            for(int i = 0; i < observatori.Length; i++)
            {
                observatori[i].Actualizeaza(Stare);
            }
        }
    }
}
