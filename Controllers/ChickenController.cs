using Microsoft.AspNetCore.Mvc;
using ChickenSystem.Models;
using ChickenSystem.Dto;
using ChickenSystem.Services;

namespace ChickenSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChickenController : ControllerBase
    { //1
        private readonly IChickenService _chickenService;
        public ChickenController(IChickenService chickenService)
        {
            _chickenService = chickenService;
        }
        //2
        [HttpGet]
        public ActionResult<List<ChickenDto>> Get()
        {
            return Ok(_chickenService.GetChickens());
        } 
        
        //3
        [HttpGet("{id}")]
        public ActionResult<ChickenDto> GetById(int id)
        {
            var result = _chickenService.GetById(id);
            return Ok(result);
        }
        //post create sin ID en createChickenDto
        [HttpPost]
        public ActionResult<ChickenDto> Post(CreateChickenDto chickenpostdto)
        {
           var result = _chickenService.Post(chickenpostdto);
           return Ok(result);
        }
        //put update
        [HttpPut("{id}")]
        public ActionResult<ChickenDto> Put(int id, UpdateChickenDto chickenputdto)
        {
            var result = _chickenService.Put(id, chickenputdto);
            return Ok(result);
        }
        //delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _chickenService.Delete(id);
            return Ok(result);
        }

    }
}

