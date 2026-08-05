namespace DesignPatterns.ex6.Models
{
    public interface IComision
    {
        string Nume { get; }
        decimal Calculeaza(decimal valoareVanzare);
    }
}
