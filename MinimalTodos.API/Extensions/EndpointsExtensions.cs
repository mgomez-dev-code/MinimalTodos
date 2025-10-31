using MinimalTodos.API.Endpoints;

namespace MinimalTodos.API.Extensions
{
    public static class EndpointsExtensions
    {
        public static void MapEndpoints(this WebApplication app)
        {
            // Registers all endpoint groups in the project
            app.MapTodoEndpoints();
        }
    }
}
