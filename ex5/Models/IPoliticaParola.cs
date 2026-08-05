namespace DesignPatterns.ex5.Models
{
    public interface IPoliticaParola
    {
        string Nume { get; }
        bool EsteValida(string parola);
    }
}
