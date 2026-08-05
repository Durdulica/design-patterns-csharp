namespace DesignPatterns.ex7.Models
{
    public class AbonatPush : IAbonat
    {
        public void Notifica(string titluVideo)
        {
            Console.WriteLine("[PUSH] " + titluVideo);
        }
    }
}
