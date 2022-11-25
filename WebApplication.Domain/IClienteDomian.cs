namespace WebApplication.Domain;

public interface IClienteDomian
{
    Task<bool> add(string name);
}