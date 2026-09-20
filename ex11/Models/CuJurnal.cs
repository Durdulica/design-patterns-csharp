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

        public string Nume => interior.Nume + " + jurnal";

        public void Trimite(string mesaj)
        {
            if (string.IsNullOrWhiteSpace(mesaj))
            {
                throw new ArgumentException("Message cannot be empty");
            }
            Console.WriteLine($"[JURNAL] catre {interior.Nume}: {mesaj}");
        }
    }
}
