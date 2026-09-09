namespace DesignPatterns.ex11.Models
{
    public class NotificatorEmail : INotificator
    {
        public string Nume => "Email";

        public void Trimite(string mesaj)
        {
            if (string.IsNullOrWhiteSpace(mesaj))
            {
                throw new ArgumentException("Message cannot be empty");
            }

            Console.WriteLine("[EMAIL] " + mesaj);
        }
    }
}
