using ChickenSystem.Dto.User;
using ChickenSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChickenSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<List<UserDto>> Get()
        {
            return Ok(_userService.GetUsers());
        }
        [HttpGet("search/{name}")]
        public ActionResult<List<UserDto>> GetByName(string name)
        {
            return Ok(_userService.GetByName(name));
        }
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            var result = _userService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult<UserDto> Post(CreateUserDto createUserDto)
        {
            var result = _userService.Post(createUserDto);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public ActionResult<UserDto> Put(int id, UpdateUserDto updateUserDto)
        {
            var result = _userService.Put(id, updateUserDto);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _userService.Delete(id);
            return Ok(result);
        }
    }
}

