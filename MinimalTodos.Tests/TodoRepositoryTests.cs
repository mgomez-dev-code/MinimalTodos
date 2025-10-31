using MinimalTodos.API.Domain;
using MinimalTodos.API.Repositories;
using MinimalTodos.API.Validation;

namespace MinimalTodos.Tests 
{
    public class TodoRepositoryTests
    {
        [Fact]
        public void Add_Should_AssignIncrementalId()
        {
            // Arrange
            var repo = new InMemoryTodoRepository();
            var item = new TodoItem(0, "New task", false);

            // Act
            var created = repo.Add(item);

            // Assert
            Assert.True(created.Id > 0);
        }

        [Fact]
        public void Toggle_Should_Change_IsDone_State()
        {
            // Arrange
            var repo = new InMemoryTodoRepository();
            var id = 1;
            var before = repo.Get(id)!.IsDone;

            // Act
            repo.Toggle(id);

            // Assert
            var after = repo.Get(id)!.IsDone;
            Assert.NotEqual(before, after);
        }

        [Fact]
        public void Validate_Should_ReturnError_WhenTitleEmpty()
        {
            // Arrange
            var dto = new TodoCreateDto("  ");

            // Act
            var result = TodoValidator.Validate(dto);

            // Assert
            Assert.NotNull(result);
            Assert.True(result!.ContainsKey("Title"));
        }
    }
}
