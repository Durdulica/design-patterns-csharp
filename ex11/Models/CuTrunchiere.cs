namespace DesignPatterns.ex11.Models
{
    public class CuTrunchiere : INotificator
    {
        private readonly INotificator interior;
        private readonly int lungimeMaxima;

        public CuTrunchiere(int lungimeMaxima, INotificator interior)
        {
            if (lungimeMaxima <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lungimeMaxima), "Length limit must be positive");
            }

            if (interior == null)
            {
                throw new ArgumentNullException(nameof(interior));
            }

            this.lungimeMaxima = lungimeMaxima;
            this.interior = interior;
        }

        public string Nume => throw new NotImplementedException();

        public void Trimite(string mesaj)
        {
            throw new NotImplementedException();
        }
    }
}
