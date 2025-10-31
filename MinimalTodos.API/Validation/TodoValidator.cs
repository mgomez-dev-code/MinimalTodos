using MinimalTodos.API.Domain;

namespace MinimalTodos.API.Validation
{
    public static class TodoValidator
    {
        public static Dictionary<string, string[]>? Validate(TodoCreateDto dto)
        {
            var title = dto.Title?.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                return new()
                {
                    ["Title"] = new[] { "Title is required (1-100 chars)." }
                };
            }
            if (title.Length > 100)
            {
                return new()
                {
                    ["Title"] = new[] { "Max length is 100 chars." }
                };
            }
            return null;
        }
    }
}
