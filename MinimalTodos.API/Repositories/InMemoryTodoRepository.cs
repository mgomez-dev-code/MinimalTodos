using MinimalTodos.API.Domain;

namespace MinimalTodos.API.Repositories
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        List<TodoItem> lstTodoItem = new List<TodoItem>() {
            new TodoItem(1, "Learn LINQ", true),
            new TodoItem(2, "Build Minimal API", false),
            new TodoItem(3, "Write unit tests", false),
            new TodoItem(4, "Refactor repository", false),
            new TodoItem(5, "Ship to prod", false),
            new TodoItem(6, "Document endpoints", false),
            new TodoItem(7, "Create Swagger UI", false),
            new TodoItem(8, "Handle exceptions globally", false),
            new TodoItem(9, "Implement logging", false),
            new TodoItem(10, "Test pagination logic", false),
            new TodoItem(11, "Add search filter", false),
            new TodoItem(12, "Integrate frontend", false),
            new TodoItem(13, "Clean up warnings", false),
            new TodoItem(14, "Improve validation rules", false),
            new TodoItem(15, "Polish README.md", false),
        };

        public TodoItem Add(TodoItem item)
        {
            var currentItemWithMaxId = lstTodoItem.OrderByDescending(x => x.Id).FirstOrDefault();
            if (currentItemWithMaxId != null)
            {
                item.Id = currentItemWithMaxId.Id + 1;
                lstTodoItem.Add(item);
            }
            return item;
        }

        public bool Delete(int id)
        {
            var itemDelete = lstTodoItem.Where(x => x.Id == id).FirstOrDefault();
            if (itemDelete != null)
            {
                lstTodoItem.Remove(itemDelete);
                return true;
            }
            else
            {
                return false;
            }
        }

        public TodoItem? Get(int id)
        {
            return lstTodoItem.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return lstTodoItem;
        }

        public void Toggle(int id)
        {
            var itemToggle = lstTodoItem.Where(x => x.Id == id).FirstOrDefault();
            if (itemToggle != null)
            {
                if (itemToggle.IsDone == null)
                {
                    itemToggle.IsDone = false;
                }
                else
                {
                    itemToggle.IsDone = !itemToggle.IsDone;
                }
            }
        }

        public void Update(TodoItem item)
        {
            var itemUpdate = lstTodoItem.Where(x => x.Id == item.Id).FirstOrDefault();
            if (itemUpdate != null)
            {
                if (!string.IsNullOrWhiteSpace(item.Title))
                    itemUpdate.Title = item.Title;

                itemUpdate.IsDone = item.IsDone;
            }
        }
    }
}
