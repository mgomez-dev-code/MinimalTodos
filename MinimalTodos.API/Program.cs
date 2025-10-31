using MinimalTodos.API.Extensions;
using MinimalTodos.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register essential services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection: register in-memory repository
builder.Services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();

var app = builder.Build();

// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI();

// Register all endpoints (currently only /todos)
app.MapEndpoints();

app.Run();
