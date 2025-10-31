using System.ComponentModel.DataAnnotations;

namespace MinimalTodos.API.Domain
{
    public class TodoItem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string? Title { get; set; }
        public bool? IsDone { get; set; }
        public TodoItem()
        {
            Id = 0;
            IsDone = false;
        }

        public TodoItem(int id, string title, bool? isDone)
        {
            Id = id;
            Title = title;
            IsDone = isDone;
        }
    }
}
