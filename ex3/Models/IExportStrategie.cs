namespace DesignPatterns.ex3.Models
{
    public interface IExportStrategie
    {
        string Nume { get; }
        string Formateaza(string[] randuri);
    }
}
