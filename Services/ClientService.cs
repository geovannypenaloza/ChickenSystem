using ChickenSystem.Data;
using ChickenSystem.Dto.Client;
using ChickenSystem.Models;

namespace ChickenSystem.Services;

public interface IClientService
{
    public List<ClientDto> Get();
    public ClientDto? GetById(int id);
    public ClientDto Post(CreateClientDto createClientDto);
    public ClientDto? Put(int id, UpdateClientDto updateClientDto);
    public bool Delete(int id);
}

public class ClientService : IClientService
{
    private readonly AppDbContext _db;
    private readonly  ILogger<ClientService> _logger;
    public ClientService(AppDbContext db, ILogger<ClientService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public List<ClientDto> Get()
    {
        var clientList = _db.Clients.Select(g => new ClientDto
        {
            Email = g.Email,
            Id = g.Id,
            Name = g.Name,
            Phone = g.Phone
        }).ToList();

        return clientList;
    }

    public ClientDto? GetById(int id)
    {
        var client = _db.Clients.FirstOrDefault(c => c.Id == id);
        if (client == null)
        {
            return null;
        }

        var clientdto = new ClientDto
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Phone = client.Phone
        };
        return clientdto;
    }

    public ClientDto Post(CreateClientDto createClientDto)
    {
        var newClient = new Client
        {
            Id = 0,
            Name = createClientDto.Name,
            Email = createClientDto.Email,
            Phone = createClientDto.Phone
        };
        _db.Clients.Add(newClient);
        _db.SaveChanges();
        var clientDto = new ClientDto
        {
            Id = newClient.Id,
            Name = newClient.Name,
            Email = newClient.Email,
            Phone = newClient.Phone
        };
        return clientDto;
    }

    public ClientDto? Put(int id, UpdateClientDto updateClientDto)
    {
        var client = _db.Clients.FirstOrDefault(c => c.Id == id);
        if (client == null)
        {
            return null;
        }

        client.Name = updateClientDto.Name;
        client.Email = updateClientDto.Email;
        client.Phone = updateClientDto.Phone;
        _db.SaveChanges();
        var result = new ClientDto()
        {
            Name = client.Name,
            Email = client.Email,
            Phone = client.Phone
        };
        return result;
    }

    public bool Delete(int id)
    {
        var client = _db.Clients.FirstOrDefault(n => n.Id == id);
        if (client == null)
        {
            return false;
        }

        _db.Clients.Remove(client);

        return true;
    }
}