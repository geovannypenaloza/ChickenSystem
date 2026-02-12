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


public class ShedService:IShedService
{
    private static readonly List<Shed> ShedList =
    [
        new Shed
        {
            Id = 1,
            Name = "geovanny",
            Color = "blue",
            Active = true
        },
    ];
    public ShedService() { }
    
        public List<ShedDto> GetSheds()
        {
            var sheds = ShedList.Select(g => new ShedDto
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
            var sheds = ShedList.Where(g => g.Name.Contains(name)).Select(g => new ShedDto
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
            var shed = ShedList.FirstOrDefault(c => c.Id == id);
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
                Id = ShedList.Max(g => g.Id) + 1,
                Name = createShedDto.Name,
                Color = createShedDto.Color,
                Active = createShedDto.Active
            };
            ShedList.Add(newShed);
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
            Shed? shed = ShedList.FirstOrDefault(c => c.Id == id);
            if (shed == null)
            {
                return null;
            }
            shed.Name = updateShedDto.Name;
            shed.Color = updateShedDto.Color;
            shed.Active = updateShedDto.Active;
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
            var shed = ShedList.FirstOrDefault(c => c.Id == id);
            if (shed == null)
            {
                return false;
            }
            ShedList.Remove(shed);
            return true;
        }
}