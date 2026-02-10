using Microsoft.AspNetCore.Mvc;
using ChickenSystem.Models;
using ChickenSystem.Dto;

namespace ChickenSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChickenController : ControllerBase
    {
        public static List<Chicken> ChickenList = new List<Chicken>()
        {
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
        };
        // GET: api/chickens
        [HttpGet]
        public ActionResult<List<ChickenDto>> Get()
        {
            var chickengetdot = ChickenList.Select(g => new ChickenDto
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
            return Ok(chickengetdot);
        } //get 2 id
        [HttpGet("{id}")]
        public ActionResult<ChickenDto> GetById(int id)
        {
            var chicken = ChickenList.FirstOrDefault(c => c.Id == id);
            if (chicken == null)
            {
                return NotFound();
            }
            var chickengetdot = new ChickenDto
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
            return Ok(chickengetdot);
        }

        [HttpPost]
        public ActionResult<ChickenDto> Post(CreateChickenDto chickenpostdto)
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
            var chickendot = new ChickenDto
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
            return Ok(chickendot);
        }
        [HttpPut("{id}")]
        public ActionResult<ChickenDto> Put(int id, UpdateChickenDto chickenputdto)
        {
            var chicken = ChickenList.FirstOrDefault(c => c.Id == id);
            if (chicken == null)
            {
                return NotFound();
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
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var chicken = ChickenList.FirstOrDefault(c => c.Id == id);
            if (chicken == null)
            {
                return NotFound();
            }
            ChickenList.Remove(chicken);           

            return NoContent();
        }

    }
}

