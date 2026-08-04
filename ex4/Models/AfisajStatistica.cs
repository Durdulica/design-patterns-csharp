namespace DesignPatterns.ex4.Models
{
    public class AfisajStatistica : IAfisaj
    {
        private decimal[] temperaturi = new decimal[0];
        private decimal minim = decimal.MaxValue;
        private decimal maxim = decimal.MinValue;
        private decimal media;

        public void Actualizeaza(decimal temperatura)
        {
            decimal[] tempNoi = new decimal[temperaturi.Length + 1];

            if (temperatura < minim)
            {
                minim = temperatura;
            }

            if (temperatura > maxim) 
            {
                maxim = temperatura;
            }

            media = 0;
            for (int i = 0; i < temperaturi.Length; i++) 
            {
                tempNoi[i] = temperaturi[i];
                media += temperaturi[i];
            }

            tempNoi[tempNoi.Length - 1] = temperatura;
            media = (media + temperatura) / tempNoi.Length;
            temperaturi = tempNoi;

            Console.WriteLine("[STATISTICA] Min: " + minim + " Max: " + maxim + " Media: " + media);
        }
    }
}