using ChickenSystem.Data;
using ChickenSystem.Dto.Shed;
using ChickenSystem.Models;

namespace ChickenSystem.Services;

public interface IShedService
{
    public List<ShedDto> GetSheds();
    public List<ShedDto> GetByName(string name);
    public ShedDto? GetById(int id);
    public ShedDto Post(CreateShedDto createShedDto);
    public ShedDto? Put(int id, UpdateShedDto updateShedDto);
    public bool Delete(int id);
}

public class ShedService : IShedService
{
    private readonly AppDbContext _db;

    public ShedService(AppDbContext db)
    {
        _db = db;
    }

    public List<ShedDto> GetSheds()
    {
        var sheds = _db.Sheds.Select(g => new ShedDto
        {
            Id = g.Id,
            Name = g.Name,
            Color = g.Color,
            Active = g.Active
        }).ToList();
        return sheds;
    }

    public List<ShedDto> GetByName(string name)
    {
        var sheds = _db.Sheds.Where(g => g.Name.Contains(name)).Select(g => new ShedDto
        {
            Id = g.Id,
            Name = g.Name,
            Color = g.Color,
            Active = g.Active
        }).ToList();
        return sheds;
    }

    public ShedDto? GetById(int id)
    {
        var shed = _db.Sheds.FirstOrDefault(c => c.Id == id);
        if (shed == null)
        {
            return null;
        }

        var shedDto = new ShedDto
        {
            Id = shed.Id,
            Name = shed.Name,
            Color = shed.Color,
            Active = shed.Active
        };
        return shedDto;
    }

    public ShedDto Post(CreateShedDto createShedDto)
    {
        var newShed = new Shed
        {
            Id = 0,
            Name = createShedDto.Name,
            Color = createShedDto.Color,
            Active = createShedDto.Active
        };
        _db.Sheds.Add(newShed);
        _db.SaveChanges();
        var shedDto = new ShedDto
        {
            Id = newShed.Id,
            Name = newShed.Name,
            Color = newShed.Color,
            Active = newShed.Active
        };
        return shedDto;
    }

    public ShedDto? Put(int id, UpdateShedDto updateShedDto)
    {
        Shed? shed = _db.Sheds.FirstOrDefault(c => c.Id == id);
        if (shed == null)
        {
            return null;
        }

        shed.Name = updateShedDto.Name;
        shed.Color = updateShedDto.Color;
        shed.Active = updateShedDto.Active;
        _db.SaveChanges();
        var result = new ShedDto()
        {
            Id = shed.Id,
            Name = shed.Name,
            Color = shed.Color,
            Active = shed.Active
        };
        return result;
    }

    public bool Delete(int id)
    {
        var shed = _db.Sheds.FirstOrDefault(c => c.Id == id);
        if (shed == null)
        {
            return false;
        }

        _db.Sheds.Remove(shed);
        return true;
    }
}