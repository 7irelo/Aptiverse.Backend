using System.ComponentModel.DataAnnotations;

namespace Aptiverse.Backend.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required] public int CategoryId { get; set; }
        [Required] public int TypeId { get; set; }
        [Required] [StringLength(50)] public string? FirstName { get; set; }
        [StringLength(50)] public string? LastName { get; set; }
    }
}
