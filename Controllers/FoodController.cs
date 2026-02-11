using ChickenSystem.Dto;
using ChickenSystem.Models;
using ChickenSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChickenSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)//constructor
        {
            _foodService = foodService;
        }
        [HttpGet]
        public ActionResult<List<FoodDto>> Get()
        {
            return Ok(_foodService.GetFoods());
        } 
        [HttpGet("{id}")]
        public ActionResult<FoodDto> GetById(int id)
        {
            var result = _foodService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult<FoodDto> Post(CreateFoodDto createFoodDto)
        {
            var result = _foodService.Post(createFoodDto);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public ActionResult<FoodDto> Put(int id, UpdateFoodDto updateFoodDto)
        {
            var result = _foodService.Put(id, updateFoodDto);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _foodService.Delete(id);
            return Ok(result);
        }
    }
}