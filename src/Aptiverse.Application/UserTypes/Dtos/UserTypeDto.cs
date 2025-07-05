using System.Runtime.Serialization;

namespace Aptiverse.Application.UserTypes.Dtos
{
    [DataContract]
    public class UserTypeDto
    {
        [DataMember(Name = "id")] public int Id { get; set; }
        [DataMember(Name = "displayName")] public string? DisplayName { get; set; }
    }
}
