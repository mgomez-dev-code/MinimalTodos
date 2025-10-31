using MinimalTodos.API.Domain;

namespace MinimalTodos.API.Repositories
{
    public interface ITodoRepository
    {
        TodoItem Add(TodoItem item);
        bool Delete(int id);
        TodoItem? Get(int id);
        IEnumerable<TodoItem> GetAll();
        void Toggle(int id);
        void Update(TodoItem item);
    }
}
