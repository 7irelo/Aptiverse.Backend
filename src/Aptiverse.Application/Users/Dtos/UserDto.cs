using Swashbuckle.AspNetCore.Annotations;
using System.Runtime.Serialization;

namespace Aptiverse.Application.Users.Dtos
{
    [DataContract]
    public class UserDto
    {
        [DataMember(Name = "id")][SwaggerSchema(ReadOnly = true)] public long Id { get; set; }
        [DataMember(Name = "firstName")] public required string FirstName { get; set; }
        [DataMember(Name = "lastName")] public required string LastName { get; set; }
        [DataMember(Name = "email")] public string? Email { get; set; }
        [DataMember(Name = "phoneNumber")] public string? PhoneNumber { get; set; }
        [DataMember(Name = "password")] public required string Password { get; set; }
        [DataMember(Name = "typeId")] public int TypeId { get; set; }
        [DataMember(Name = "categoryId")] public int CategoryId { get; set; }
    }

}
