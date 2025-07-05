using System.Runtime.Serialization;

namespace Aptiverse.Application.UserCategories.Dtos
{
    public class UserCategoryDto
    {
        [DataMember(Name = "id")] public int Id { get; set; }
        [DataMember(Name = "displayName")] public string? DisplayName { get; set; }
    }
}
