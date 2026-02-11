using ClientSystem.Dto;
using ClientSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        public static List<Client> ClientList = new List<Client>()
        {
            new Client
            {
                Id = 1,
                Name = "geovanny",
                Email = "geovanny@hotmail.com",
                Phone = "movistar",
             }
        };
        // GET: api/Client
        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            var clientgetdot = ClientList.Select(g => new ClientDto
            {
                Email = g.Email,
                Id = g.Id,
                Name = g.Name,
                Phone = g.Phone
            }).ToList();
            return Ok(clientgetdot);
        } //get 2 id
        [HttpGet("{id}")]
        public ActionResult<ClientDto> GetById(int id)
        {
            var Client = ClientList.FirstOrDefault(c => c.Id == id);
            if (Client == null)
            {
                return NotFound();
            }
            var clientgetdot = new ClientDto
            {
                Id = Client.Id,
                Name = Client.Name,
                Email = Client.Email,
                Phone = Client.Phone
            };
            return Ok(clientgetdot);
        }//post create sin ID en createClientDto
        [HttpPost]
        public ActionResult<ClientDto> Post(CreateClientDto clientpostdto)
        {
            var newClient = new Client
            {
                Id = ClientList.Max(g => g.Id) + 1,
                Name = clientpostdto.Name,
                Email = clientpostdto.Email,
                Phone = clientpostdto.Phone
            };
            ClientList.Add(newClient);
            var clientdot = new ClientDto
            {
                Id = newClient.Id,
                Name = newClient.Name,
                Email = newClient.Email,
                Phone = newClient.Phone
            };
            return Ok(clientdot);
        }
        //put update
        [HttpPut("{id}")]
        public ActionResult<ClientDto> Put(int id, UpdateClientDto clientputdto)
        {
            var client = ClientList.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            client.Name = clientputdto.Name;
            client.Email = clientputdto.Email;
            client.Phone = clientputdto.Phone;
            return NoContent();
        }//delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var client = ClientList.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            ClientList.Remove(client);

            return NoContent();
        }
    }
}

