namespace Aptiverse.Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Foreign keys
        public required int TypeId { get; set; }
        public required int CategoryId { get; set; }

        // Navigation properties
        public UserType? Type { get; set; }
        public UserCategory? Category { get; set; }
    }
}