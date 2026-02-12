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
    private static readonly List<Food> FoodList =
    [
        new Food
        {
            Id = 1,
            Name = "ave",
            Description = "descripcionn",
            ImageUrl = "imagen"
        },
    ];

    public FoodService()
    {
    }

    public List<FoodDto> GetFoods()
    {
        var foods = FoodList.Select(g => new FoodDto
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
        var foods = FoodList.Where(g => g.Name.Contains(name)).Select(g => new FoodDto
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
        var food = FoodList.FirstOrDefault(c => c.Id == id);
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
            Id = FoodList.Max(g => g.Id) + 1,
            Name = createFoodDto.Name,
            Description = createFoodDto.Description,
            ImageUrl = createFoodDto.ImageUrl,
        };
        FoodList.Add(newFood);
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
        Food? food = FoodList.FirstOrDefault(c => c.Id == id);
        if (food == null)
        {
            return null;
        }

        food.Name = updateFoodDto.Name;
        food.Description = updateFoodDto.Description;
        food.ImageUrl = updateFoodDto.ImageUrl;
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
        var food = FoodList.FirstOrDefault(c => c.Id == id);

        if (food == null)
        {
            return false;
        }

        FoodList.Remove(food);

        return true;
    }
}