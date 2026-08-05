namespace DesignPatterns.ex7.Models
{
    public class AbonatEmail : IAbonat
    {
        public void Notifica(string titluVideo)
        {
            Console.WriteLine("[EMAIL] Video nou: " + titluVideo);
        }
    }
}
