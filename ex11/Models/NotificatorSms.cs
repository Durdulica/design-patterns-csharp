namespace DesignPatterns.ex11.Models
{
    public class NotificatorSms : INotificator
    {
        public const int LungimeMaxima = 160;

        public string Nume => "SMS";

        public void Trimite(string mesaj)
        {
            if (string.IsNullOrWhiteSpace(mesaj))
            {
                throw new ArgumentException("Message cannot be empty");
            }

            if (mesaj.Length > LungimeMaxima)
            {
                throw new ArgumentException("Message exceeds SMS length limit");
            }

            Console.WriteLine("[SMS] " + mesaj);
        }
    }
}
