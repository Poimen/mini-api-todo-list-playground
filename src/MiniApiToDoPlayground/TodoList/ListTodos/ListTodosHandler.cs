using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MiniApiToDoPlayground.ToDoList.Data;
using MiniApiToDoPlayground.ToDoList.Data.Entities;

namespace MiniApiToDoPlayground.TodoList.ListTodos;

internal interface IListTodosHandler
{
    ValueTask<List<Todo>> GetAll();

    ValueTask<List<Todo>> GetAllComplete();

    ValueTask<Results<Ok<Todo>, NotFound>> GetById(int id);
}

internal class ListTodosHandler(TodoContext todoContext) : IListTodosHandler
{
    private readonly TodoContext _todoContext = todoContext;

    public async ValueTask<List<Todo>> GetAll()
    {
        return await _todoContext.Todos
            .AsNoTracking()
            .ToListAsync();
    }

    public async ValueTask<List<Todo>> GetAllComplete()
    {
        return await _todoContext.Todos
            .AsNoTracking()
            .Where(w => w.IsComplete)
            .ToListAsync();
    }

    public async ValueTask<Results<Ok<Todo>, NotFound>> GetById(int id)
    {
        var todo = await _todoContext.Todos.FindAsync(id);

        return todo is null
            ? TypedResults.NotFound()
            : TypedResults.Ok(todo);
    }
}
