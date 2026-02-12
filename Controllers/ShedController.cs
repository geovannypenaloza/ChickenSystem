using ChickenSystem.Dto.Shed;
using ChickenSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChickenSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ShedController : ControllerBase
{
    private readonly IShedService _shedService;
    public ShedController(IShedService shedService)
    {
        _shedService = shedService;
    }
    [HttpGet]
    public ActionResult<List<ShedDto>> Get()
    {
        return Ok(_shedService.GetSheds());
    }
    [HttpGet("search/{name}")]
    public ActionResult<List<ShedDto>> GetByName(string name)
    {
        return Ok(_shedService.GetByName(name));
    }
    [HttpGet("{id}")]
    public ActionResult<ShedDto> GetById(int id)
    {
        var result = _shedService.GetById(id);
        return Ok(result);
    }
    [HttpPost]
    public ActionResult<ShedDto> Post(CreateShedDto createShedDto)
    {
        var result = _shedService.Post(createShedDto);
        return Ok(result);
    }
    [HttpPut("{id}")]
    public ActionResult<ShedDto> Put(int id, UpdateShedDto updateShedDto)
    {
        var result = _shedService.Put(id, updateShedDto);
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = _shedService.Delete(id);
        return Ok(result);
    }
}