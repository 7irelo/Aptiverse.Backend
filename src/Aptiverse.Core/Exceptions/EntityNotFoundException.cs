namespace Aptiverse.Core.Exceptions
{
    public class EntityNotFoundException(string entityName, object key) 
        : Exception($"Entity '{entityName}' with key '{key}' was not found.")
    {
    }
}