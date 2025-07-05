using Aptiverse.Application.Users.Dtos;
using Aptiverse.Domain.Interfaces;
using Aptiverse.Domain.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace Aptiverse.Application.Users.Services
{
    public class UserService(IRepository<User> repository, IMapper mapper) : IUserService
    {
        private readonly IRepository<User> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _repository.AddAsync(user);
            return _mapper.Map<UserDto>(result);
        }

        public async Task<UserDto> GetOneUserAsync(long id)
        {
            var user = await _repository.GetOneAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetManyUsersAsync(string filter)
        {
            try
            {
                var filters = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
                var users = await _repository.GetManyAsync(filters);
                return _mapper.Map<IEnumerable<UserDto>>(users);
            }
            catch (JsonException ex)
            {
                throw new ArgumentException("Invalid filter format", nameof(filter), ex);
            }
        }

        public async Task<UserDto> UpdateUserAsync(long id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _repository.UpdateAsync(id, user);
            return _mapper.Map<UserDto>(result);
        }

        public async Task DeleteUserAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}