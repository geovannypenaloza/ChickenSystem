using ChickenSystem.Data;
using ChickenSystem.Dto.Food;
using ChickenSystem.Models;

namespace ChickenSystem.Services;

public interface IFoodService
{
    public List<FoodDto> GetFoods();
    public List<FoodDto> GetByName(string name);
    public FoodDto? GetById(int id);
    public FoodDto Post(CreateFoodDto createFoodDto);
    public FoodDto? Put(int id, UpdateFoodDto updateFoodDto);
    public bool Delete(int id);
}

public class FoodService : IFoodService
{
    private readonly AppDbContext _db;
    private readonly  ILogger<FoodService> _logger;
    private readonly IShedService _shedService;
    public FoodService(AppDbContext db, ILogger<FoodService> logger, IShedService shedService)
    {
        _db = db;
        _logger = logger;
        _shedService = shedService;
    }

    public List<FoodDto> GetFoods()
    {
        var foods = _db.Foods.Select(g => new FoodDto
        {
            Id = g.Id,
            Name = g.Name,
            Description = g.Description,
            ImageUrl = g.ImageUrl
        }).ToList();
        return foods;
    }

    public List<FoodDto> GetByName(string name)
    {
        var foods = _db.Foods.Where(g => g.Name.Contains(name)).Select(g => new FoodDto
        {
            Id = g.Id,
            Name = g.Name,
            Description = g.Description,
            ImageUrl = g.ImageUrl
        }).ToList();
        return foods;
    }

    public FoodDto? GetById(int id)
    {
        var food = _db.Foods.FirstOrDefault(c => c.Id == id);
        if (food == null)
        {
            return null;
        }

        var foodDto = new FoodDto
        {
            Id = food.Id,
            Name = food.Name,
            Description = food.Description,
            ImageUrl = food.ImageUrl
        };
        return foodDto;
    }

    public FoodDto Post(CreateFoodDto createFoodDto)
    {
        var newFood = new Food
        {
            Id = 0,
            Name = createFoodDto.Name,
            Description = createFoodDto.Description,
            ImageUrl = createFoodDto.ImageUrl,
        };
        _db.Foods.Add(newFood);
        _db.SaveChanges();
        var foodDto = new FoodDto
        {
            Id = newFood.Id,
            Name = newFood.Name,
            Description = newFood.Description,
            ImageUrl = newFood.ImageUrl
        };
        return foodDto;
    }

    public FoodDto? Put(int id, UpdateFoodDto updateFoodDto)
    {
        Food? food = _db.Foods.FirstOrDefault(c => c.Id == id);
        if (food == null)
        {
            return null;
        }
        food.Name = updateFoodDto.Name;
        food.Description = updateFoodDto.Description;
        food.ImageUrl = updateFoodDto.ImageUrl;
        _db.SaveChanges();
        var result = new FoodDto()
        {
            Id = food.Id,
            Name = food.Name,
            Description = food.Description,
            ImageUrl = food.ImageUrl
        };
        return result;
    }

    public bool Delete(int id)
    {
        var food = _db.Foods.FirstOrDefault(c => c.Id == id);

        if (food == null)
        {
            return false;
        }

        _db.Foods.Remove(food);

        return true;
    }
}