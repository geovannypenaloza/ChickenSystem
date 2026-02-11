
using ChickenSystem.Dto;
using ChickenSystem.Models;
using ChickenSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChickenSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        
        [HttpGet]
        public ActionResult<List<ClientDto>> Get()
        {
            return Ok(_clientService.Get());
        } 
        
        
        [HttpGet("{id}")]
        public ActionResult<ClientDto> GetById(int id)
        {
            var result = _clientService.GetById(id);
            return Ok(result);
        }//post 
        
        [HttpPost]
        public ActionResult<ClientDto> Post(CreateClientDto clientpostdto)
        {
            var result = _clientService.Post(clientpostdto);
            return Ok(result);
        }
        //put update
        [HttpPut("{id}")]
        public ActionResult<ClientDto> Put(int id, UpdateClientDto clientputdto)
        {
            var  result = _clientService.Put(id, clientputdto);
            return  Ok(result);
        }//delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var  result = _clientService.Delete(id);
            return Ok(result);
        }
    }
}

