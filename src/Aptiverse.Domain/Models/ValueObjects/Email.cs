using System.Text.RegularExpressions;
using Aptiverse.Domain.Exceptions;

namespace Aptiverse.Domain.Models.ValueObjects
{
    public record Email(string Value)
    {
        private static readonly Regex EmailRegex = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.Compiled);

        public static Email Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Email cannot be empty.");

            if (!EmailRegex.IsMatch(value))
                throw new DomainException("Invalid email format.");

            return new Email(value);
        }
    }
}