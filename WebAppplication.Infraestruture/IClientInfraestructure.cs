namespace WebAppplication.Infraestruture;

public interface IClientInfraestructure
{
    Task<bool> Add(string name);
}