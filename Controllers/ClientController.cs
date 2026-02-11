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
        }

        [HttpPost]
        public ActionResult<ClientDto> Post(CreateClientDto createClientDto)
        {
            var result = _clientService.Post(createClientDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<ClientDto> Put(int id, UpdateClientDto updateClientDto)
        {
            var result = _clientService.Put(id, updateClientDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _clientService.Delete(id);
            return Ok(result);
        }
    }
}