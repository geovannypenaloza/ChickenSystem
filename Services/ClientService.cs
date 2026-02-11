using ChickenSystem.Dto;
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
public class ClientService:IClientService
{
    private static List<Client> _clientList =
    [
        new Client
        {
            Id = 1,
            Name = "geovanny",
            Email = "geovanny@hotmail.com",
            Phone = "movistar",
        }
    ];

    public ClientService()
    {
        
    }


    public List<ClientDto> Get()
    {
        var clientList = _clientList.Select(g => new ClientDto
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
        var client = _clientList.FirstOrDefault(c => c.Id == id);
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

    public ClientDto Post(CreateClientDto clientpostdto)
    {
        var newClient = new Client
        {
            Id = _clientList.Max(g => g.Id) + 1,
            Name = clientpostdto.Name,
            Email = clientpostdto.Email,
            Phone = clientpostdto.Phone
        };
        _clientList.Add(newClient);
        var clientDto = new ClientDto
        {
            Id = newClient.Id,
            Name = newClient.Name,
            Email = newClient.Email,
            Phone = newClient.Phone
        };
        return clientDto;
    }

    public ClientDto? Put(int id, UpdateClientDto clientputdto)
    {
        var client = _clientList.FirstOrDefault(c => c.Id == id);
        if (client == null)
        {
            return null;
        }
        client.Name = clientputdto.Name;
        client.Email = clientputdto.Email;
        client.Phone = clientputdto.Phone;
        var result = new ClientDto()
        {
            Name = client.Name,
            Email = clientputdto.Email,
            Phone = clientputdto.Phone
        };
            return result;
    }

    public bool Delete(int id)
    {
        var client = _clientList.FirstOrDefault(n => n.Id == id);
        if (client == null)
        {
            return false;
        }
        _clientList.Remove(client);

        return true;
    }
}