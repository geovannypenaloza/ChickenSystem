using ChickenSystem.Data;
using ChickenSystem.Dto.User;
using ChickenSystem.Models;

namespace ChickenSystem.Services;

public interface IUserService
{
    public List<UserDto> GetUsers();
    public List<UserDto> GetByName(string name);
    public UserDto? GetById(int id);
    public UserDto Post(CreateUserDto createUserDto);
    public UserDto? Put(int id, UpdateUserDto updateUserDto);
    public bool Delete(int id);
}

public class UserService : IUserService
{
    private readonly  AppDbContext _db;
    private readonly  ILogger<UserService> _logger;
    public UserService(AppDbContext db, ILogger<UserService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public List<UserDto> GetUsers()
    {
        var users = _db.Users.Select(g => new UserDto
        {
            Id = g.Id,
            Name = g.Name,
            Age = g.Age,
            Gender = g.Gender
        }).ToList();
        return users;
    }

    public List<UserDto> GetByName(string name)
    {
        var foods = _db.Users.Where(g => g.Name.Contains(name)).Select(g => new UserDto
        {
            Id = g.Id,
            Name = g.Name,
            Age = g.Age,
            Gender = g.Gender
        }).ToList();
        return foods;
    }

    public UserDto? GetById(int id)
    {
        var user = _db.Users.FirstOrDefault(c => c.Id == id);
        if (user == null)
        {
            return null;
        }

        var userDto = new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Age = user.Age,
            Gender = user.Gender
        };
        return userDto;
    }

    public UserDto Post(CreateUserDto createUserDto)
    {
        var newUser = new User
        {
            Id = 0,
            Name = createUserDto.Name,
            Age = createUserDto.Age,
            Gender = createUserDto.Gender
        };
        _db.Users.Add(newUser);
        _db.SaveChanges();
        var userDto = new UserDto
        {
            Id = newUser.Id,
            Name = newUser.Name,
            Age = newUser.Age,
            Gender = newUser.Gender
        };
        return userDto;
    }

    public UserDto? Put(int id, UpdateUserDto updateUserDto)
    {
        User? user = _db.Users.FirstOrDefault(c => c.Id == id);
        if (user == null)
        {
            return null;
        }
        user.Name = updateUserDto.Name;
        user.Age = updateUserDto.Age;
        user.Gender = updateUserDto.Gender;
        _db.SaveChanges();
        var result = new UserDto()
        {
            Id = user.Id,
            Name = user.Name,
            Age = user.Age,
            Gender = user.Gender
        };
        return result;
    }

    public bool Delete(int id)
    {
        var user = _db.Users.FirstOrDefault(c => c.Id == id);
        if (user == null)
        {
            return false;
        }
        _db.Users.Remove(user);
        return true;
    }
}