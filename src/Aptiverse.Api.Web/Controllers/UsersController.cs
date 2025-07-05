using Aptiverse.Application.Users.Dtos;
using Aptiverse.Application.Users.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Aptiverse.Api.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService, ILogger<UsersController> logger) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly ILogger<UsersController> _logger = logger;

        [SwaggerResponse(201, "User created", typeof(UserDto))]
        [SwaggerResponse(400, "Invalid user data")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserDto result = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = result.Id }, result);
        }

        [SwaggerResponse(200, Type = typeof(UserDto))]
        [SwaggerResponse(404, "User not found")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var user = await _userService.GetOneUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [SwaggerResponse(200, Type = typeof(List<UserDto>))]
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] string filter = "{}")
        {
            var users = await _userService.GetManyUsersAsync(filter);
            return Ok(users);
        }

        [SwaggerResponse(200, "User updated", typeof(UserDto))]
        [SwaggerResponse(400, "Invalid user data")]
        [SwaggerResponse(404, "User not found")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                UserDto updatedUser = await _userService.UpdateUserAsync(id, userDto);
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [SwaggerResponse(204, "User deleted")]
        [SwaggerResponse(404, "User not found")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}