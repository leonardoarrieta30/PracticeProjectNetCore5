using WebAppplication.Infraestruture;

namespace WebApplication.Domain;

public class ClientDomain :IClienteDomian
{
    private readonly IClientInfraestructure _clientInfraestructure;

    public ClientDomain(IClientInfraestructure clientInfraestructure)
    {
        _clientInfraestructure = clientInfraestructure;
    }

    public async Task<bool> add(string name)
    {
        //Cliente N
        
        return  await _clientInfraestructure.Add(name);
    }
}