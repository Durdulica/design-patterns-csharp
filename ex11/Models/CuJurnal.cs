namespace DesignPatterns.ex11.Models
{
    public class CuJurnal : INotificator
    {
        private readonly INotificator interior;

        public CuJurnal(INotificator interior)
        {
            if (interior == null)
            {
                throw new ArgumentNullException(nameof(interior));
            }

            this.interior = interior;
        }

        public string Nume => throw new NotImplementedException();

        public void Trimite(string mesaj)
        {
            throw new NotImplementedException();
        }
    }
}
