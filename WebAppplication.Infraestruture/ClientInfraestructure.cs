using WebAppplication.Infraestruture.Context;
using WebAppplication.Infraestruture.Models;

namespace WebAppplication.Infraestruture;

public class ClientInfraestructure : IClientInfraestructure
{
    private readonly ClientDBContext _clientDbContext;

    public ClientInfraestructure(ClientDBContext clientDbContext)
    {
        _clientDbContext = clientDbContext;
    }
    public async Task<bool> Add(string name)
    {
        var cliente = new Client()
        {
            Name = name
        };

        await _clientDbContext.Clients.AddAsync(cliente);
        await _clientDbContext.SaveChangesAsync();
        return true;
    }
}