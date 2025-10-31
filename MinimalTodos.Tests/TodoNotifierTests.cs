using Moq;

namespace MinimalTodos.Tests
{
    // Mock interfaces and classes (used only to test Verify behavior)
    public interface INotifier { void Notify(string message); }

    public class TodoNotifier
    {
        private readonly INotifier _notifier;
        public TodoNotifier(INotifier notifier) => _notifier = notifier;

        public void NotifyCreated(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
                _notifier.Notify($"New todo: {title}");
        }
    }

    // Behavior-based tests using Moq's Verify
    public class TodoNotifierTests
    {
        [Fact]
        public void NotifyCreated_Should_CallNotifier_WhenTitleValid()
        {
            // Arrange
            var mock = new Mock<INotifier>();
            var service = new TodoNotifier(mock.Object);

            // Act
            service.NotifyCreated("Buy milk");

            // Assert
            mock.Verify(n => n.Notify("New todo: Buy milk"), Times.Once);
        }

        [Fact]
        public void NotifyCreated_Should_NotCallNotifier_WhenTitleEmpty()
        {
            // Arrange
            var mock = new Mock<INotifier>();
            var service = new TodoNotifier(mock.Object);

            // Act
            service.NotifyCreated("  "); // empty title

            // Assert
            mock.Verify(n => n.Notify(It.IsAny<string>()), Times.Never);
        }
    }
}
