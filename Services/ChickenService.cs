using ChickenSystem.Dto;
using ChickenSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChickenSystem.Services;

public interface IChickenService
{
    public List<ChickenDto> GetChickens();
    public ChickenDto? GetById(int id);
    public ChickenDto Post(CreateChickenDto chickenpostdto);
    public ChickenDto? Put(int id, UpdateChickenDto chickenputdto);
    public bool Delete(int id);
}

public class ChickenService:IChickenService
{
    private static List<Chicken> ChickenList =
    [
        new Chicken
        {
            Id = 1,
            Name = "ave",
            Date = DateTime.Now,
            Height = 10,
            Weight = 15,
            Color = "gris",
            Age = 15,
            Breed = "carioca",
            Sex = "hembra",
            Sing = true,
        },

        new Chicken
        {
            Id = 1,
            Name = "pollo",
            Date = DateTime.Now,
            Height = 10,
            Weight = 15,
            Color = "gris",
            Age = 15,
            Breed = "carioca",
            Sex = "hembra",
            Sing = true,
        }
    ];
    public ChickenService()
    {
        
    }


    public List<ChickenDto> GetChickens()
    {
        var chickens = ChickenList.Select(g => new ChickenDto
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
        var chicken = ChickenList.FirstOrDefault(c => c.Id == id);
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
            Id = ChickenList.Max(g => g.Id) + 1,
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
        ChickenList.Add(newChicken);
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
        Chicken? chicken = ChickenList.FirstOrDefault(c => c.Id == id);
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
        var chicken = ChickenList.FirstOrDefault(c => c.Id == id);

        if (chicken == null)
        {
            return false;
        }
        ChickenList.Remove(chicken);

        return true;
    }
}