namespace DesignPatterns.ex7.Models
{
    public class Canal
    {
        private IAbonat[] abonati;

        public Canal(IAbonat[] abonati)
        {
            this.abonati = abonati;
        }

        public void Aboneaza(IAbonat nou)
        {
            IAbonat[] tempAbonati = new IAbonat[abonati.Length + 1];

            for (int i = 0; i < tempAbonati.Length; i++)
            {
                tempAbonati[i] = abonati[i];
            }

            tempAbonati[abonati.Length] = nou;
            abonati = tempAbonati;
        }

        public void Dezaboneaza(IAbonat vechi)
        {
            int cnt = 0;

            for(int i = 0; i < abonati.Length; i++)
            {
                if(abonati[i] == vechi) cnt++;
            }

            IAbonat[] tempAbonati = new IAbonat[cnt];
            cnt = 0;
            for(int i = 0; i < tempAbonati.Length; i++)
            {
                if (abonati[i] != vechi)
                {
                    tempAbonati[cnt++] = abonati[i];
                }
            }

            abonati = tempAbonati;
        }

        public void PublicaVideo(string titlu)
        {
            for(int i = 0; i < abonati.Length; i++)
            {
                abonati[i].Notifica(titlu);
            }
        }
    }
}