using Aptiverse.Backend.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Aptiverse.Backend.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        private readonly List<UserDto> Users =
        [
            new() { Id = 1, CategoryId = 1, TypeId = 1, FirstName = "Eric", LastName = "Ncube"},
            new() { Id = 2, CategoryId = 2, TypeId = 2, FirstName = "School", LastName = "Principal" },
            new() { Id = 3, CategoryId = 2, TypeId = 3, FirstName = "School", LastName = "Teacher" },
            new() { Id = 4, CategoryId = 2, TypeId = 4, FirstName = "School", LastName = "Admin" },
            new() { Id = 5, CategoryId = 3, TypeId = 5, FirstName = "Veronica", LastName = "Khumalo" },
            new() { Id = 6, CategoryId = 4, TypeId = 6, FirstName = "Erica", LastName = "Khumalo" },
            new() { Id = 7, CategoryId = 4, TypeId = 6, FirstName = "Jessica", LastName = "Khumalo" },
        ];

        // POST: UsersController
        [HttpPost]
        [Route("Users")]
        [ValidateAntiForgeryToken]
        public UserDto? CreateUser(UserDto user)
        {
            try
            {
                Users.Add(user);
                return user;
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }

        // GET: UsersController
        [HttpGet]
        [Route("Users")]
        public IResult ReadManyUsers()
        {
            return Users is null ? Results.NotFound() : Results.Ok(Users);
        }

        // GET: UsersController/5
        [HttpGet]
        [Route("Users/{id}")]
        public IResult ReadOneUser(int id)
        {
            UserDto? user = Users.FirstOrDefault(u => u.Id == id);
            return user is null ? Results.NotFound() : Results.Ok(user);
        }

        // PUT: UsersController/5
        [HttpPut]
        [Route("Users/{id}")]
        [ValidateAntiForgeryToken]
        public IResult UpdateUser(int id, [FromBody] UserDto user)
        {
            try
            {
                UserDto? dbUser = Users.FirstOrDefault(u => u.Id == id);
                if (dbUser is null)
                {
                    return Results.NotFound();
                }
                dbUser = user;
                return Results.Ok(dbUser);
            }
            catch
            {
                return null;
            }
        }

        // DELETE: UsersController/5
        [HttpDelete]
        [Route("Users/{id}")]
        public IResult DeleteUser(int id)
        {
            Users.RemoveAll(u => u.Id == id);
            return Results.NoContent();
        }
    }
}
