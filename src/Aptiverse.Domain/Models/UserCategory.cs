using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aptiverse.Domain.Models
{
    [Table("UserCategories", Schema = "Identity")]
    public class UserCategory
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [MaxLength(50)] public required string DisplayName { get; set; }
    }
}
