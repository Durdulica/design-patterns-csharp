namespace DesignPatterns.ex11.Models
{
    public class CuPrefix : INotificator
    {
        private readonly INotificator interior;
        private readonly string prefix;

        public CuPrefix(string prefix, INotificator interior)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentException("Prefix cannot be empty");
            }

            if (interior == null)
            {
                throw new ArgumentNullException(nameof(interior));
            }

            this.prefix = prefix;
            this.interior = interior;
        }

        public string Nume => interior.Nume + " " + prefix;

        public void Trimite(string mesaj)
        {
            if (string.IsNullOrWhiteSpace(mesaj))
            {
                throw new ArgumentException("Message cannot be empty");
            }

            Console.WriteLine(Nume + ": " + mesaj);
        }
    }
}
