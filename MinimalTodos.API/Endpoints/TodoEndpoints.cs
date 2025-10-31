﻿using MinimalTodos.API.Domain;
using MinimalTodos.API.Repositories;
using MinimalTodos.API.Validation;

namespace MinimalTodos.API.Endpoints 
{
    public static class TodoEndpoints
    {
        public static RouteGroupBuilder MapTodoEndpoints(this WebApplication app)
        {
            var todos = app.MapGroup("/todos");

            todos.MapPost("/", CreateAsync).WithName("CreateTodo");
            todos.MapGet("/", FilterAsync).WithName("FilterTodo");
            todos.MapGet("/{id:int}", GetAsync).WithName("GetTodo");
            todos.MapPut("/{id:int}", UpdateAsync).WithName("UpdateTodo");
            todos.MapPatch("/{id:int}/toggle", ToggleAsync).WithName("ToggleTodo");
            todos.MapDelete("/{id:int}", DeleteAsync).WithName("DeleteTodo");

            return todos;
        }

        private static IResult CreateAsync(ITodoRepository repo, TodoCreateDto dto)
        {
            var errors = TodoValidator.Validate(dto);
            if (errors is not null)
                return Results.ValidationProblem(errors);

            var item = new TodoItem(0, dto.Title!.Trim(), false);
            var created = repo.Add(item);

            return Results.Created($"/todos/{created.Id}", created);
        }

        private static IResult FilterAsync(ITodoRepository repo, string? search, int pageIndex = 0, int pageSize = 10)
        {
            const int MaxPageSize = 100;
            if (pageIndex < 0 || pageSize <= 0 || pageSize > MaxPageSize)
                return Results.BadRequest();

            var items = repo.GetAll();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var txt = search.Trim().ToLowerInvariant();
                items = items.Where(x => x.Title!.ToLowerInvariant().Contains(txt));
            }

            var page = items
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            return Results.Ok(page);
        }

        private static IResult GetAsync(ITodoRepository repo, int id) =>
            repo.Get(id) is { } item
                ? Results.Ok(item)
                : Results.NotFound();

        private static IResult UpdateAsync(ITodoRepository repo, int id, TodoCreateDto dto)
        {
            var errors = TodoValidator.Validate(dto);
            if (errors is not null)
                return Results.ValidationProblem(errors);

            if (repo.Get(id) is not { } existing)
                return Results.NotFound();

            existing.Title = dto.Title!.Trim();
            repo.Update(existing);

            return Results.Ok(existing);
        }

        private static IResult ToggleAsync(ITodoRepository repo, int id)
        {
            if (repo.Get(id) is not { } item)
                return Results.NotFound();

            repo.Toggle(id);

            return Results.Ok(item);
        }

        private static IResult DeleteAsync(ITodoRepository repo, int id) =>
            repo.Delete(id)
                ? Results.NoContent()
                : Results.NotFound();
    }
}
