namespace DesignPatterns.ex9.Models
{
    public class Spectator : IParticipant
    {
        public void OfertaNoua(decimal pretCurent)
        {
            Console.WriteLine("[SPECTATOR] Pret curent: " + pretCurent);
        }
    }
}
