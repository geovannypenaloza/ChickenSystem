using ChickenSystem.Data;
using ChickenSystem.Dto.Chicken;
using ChickenSystem.Models;


namespace ChickenSystem.Services;

public interface IChickenService
{
    public List<ChickenDto> GetChickens();
    public ChickenDto? GetById(int id);
    public ChickenDto Post(CreateChickenDto createChickenDto);
    public ChickenDto? Put(int id, UpdateChickenDto updateChickenDto);
    public bool Delete(int id);
}

public class ChickenService:IChickenService
{
    private readonly AppDbContext _db;
    
    public ChickenService(AppDbContext db)
    {
        _db = db;
    }
    

    public List<ChickenDto> GetChickens()
    {
        
        var chickens = _db.Chickens.Select(g => new ChickenDto
        {
            Id = g.Id,
            Name = g.Name,
            Date = g.Date,
            Height = g.Height,
            Weight = g.Weight,
            Color = g.Color,
            Age = g.Age,
            Breed = g.Breed,
            Sex = g.Sex,
            Sing = g.Sing,

        }).ToList();
        return chickens;
    }

    public ChickenDto? GetById(int id)
    {
        var chicken = _db.Chickens.FirstOrDefault(c => c.Id == id);
        if (chicken == null)
        {
            return null;
        }
        var chickenDto = new ChickenDto
        {
            Id = chicken.Id,
            Name =chicken.Name,
            Date = chicken.Date,
            Height = chicken.Height,
            Weight = chicken.Weight,
            Color = chicken.Color,
            Age= chicken.Age,
            Breed = chicken.Breed,
            Sex = chicken.Sex,
            Sing = chicken.Sing,
        };
        return chickenDto;
    }

    public ChickenDto Post(CreateChickenDto chickenpostdto)
    {
        var newChicken = new Chicken
        {
            Id = 0,
            Name = chickenpostdto.Name,
            Date = chickenpostdto.Date,
            Height = chickenpostdto.Height,
            Weight = chickenpostdto.Weight,
            Color = chickenpostdto.Color,
            Age = chickenpostdto.Age,
            Breed = chickenpostdto.Breed,
            Sex = chickenpostdto.Sex,
            Sing = chickenpostdto.Sing,

        };
        _db.Chickens.Add(newChicken);
        _db.SaveChanges();
        var chickenDto = new ChickenDto
        {
            Id= newChicken.Id,
            Name = newChicken.Name,
            Date = newChicken.Date,
            Height = newChicken.Height,
            Weight = newChicken.Weight,
            Color = newChicken.Color,
            Age = newChicken.Age,
            Breed = newChicken.Breed,
            Sex = newChicken.Sex,
            Sing = newChicken.Sing,

        };
        return chickenDto;
    }

    public ChickenDto? Put(int id, UpdateChickenDto chickenputdto)
    {
        Chicken? chicken = _db.Chickens.FirstOrDefault(c => c.Id == id);
        if (chicken == null)
        {
            return null;
        }
        chicken.Name = chickenputdto.Name;
        chicken.Date = chickenputdto.Date;
        chicken.Height = chickenputdto.Height;
        chicken.Weight = chickenputdto.Weight;
        chicken.Color = chickenputdto.Color;
        chicken.Age = chickenputdto.Age;
        chicken.Breed = chickenputdto.Breed;
        chicken.Sex = chickenputdto.Sex;
        chicken.Sing = chickenputdto.Sing;
        _db.SaveChanges();
        var result = new ChickenDto()
        {
            Id = chicken.Id,
            Name = chicken.Name,
            Date = chicken.Date,
            Height = chicken.Height,
            Weight = chicken.Weight,
            Color = chicken.Color,
            Age = chicken.Age,
            Breed = chicken.Breed,
            Sex = chicken.Sex,
            Sing = chicken.Sing,
        };
        return result;
    }

    public bool Delete(int id)
    {
        var chicken = _db.Chickens.FirstOrDefault(c => c.Id == id);

        if (chicken == null)
        {
            return false;
        }
        _db.Chickens.Remove(chicken);
        _db.SaveChanges();
        return true;
    }
}