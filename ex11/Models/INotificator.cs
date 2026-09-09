namespace DesignPatterns.ex11.Models
{
    public interface INotificator
    {
        string Nume { get; }
        void Trimite(string mesaj);
    }
}
