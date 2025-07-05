using Aptiverse.Application.Users.Dtos;

namespace Aptiverse.Application.Users.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<UserDto> GetOneUserAsync(long id);
        Task<IEnumerable<UserDto>> GetManyUsersAsync(string filter);
        Task<UserDto> UpdateUserAsync(long id, UserDto userDto);
        Task DeleteUserAsync(long id);
    }
}