using Microsoft.AspNetCore.Http.HttpResults;
using MiniApiToDoPlayground.ToDoList.Data;
using MiniApiToDoPlayground.ToDoList.Data.Entities;

namespace MiniApiToDoPlayground.TodoList.UpdateTodo;

internal interface IUpdateTodoHandler
{
    ValueTask<Results<Ok<Todo>, NotFound>> UpdateTodo(int id, UpdateTodoRequest request);
}

internal class UpdateTodoHandler : IUpdateTodoHandler
{
    private readonly TodoContext _todoContext;

    public UpdateTodoHandler(TodoContext todoContext)
    {
        _todoContext = todoContext;
    }

    public async ValueTask<Results<Ok<Todo>, NotFound>> UpdateTodo(int id, UpdateTodoRequest request)
    {
        var todo = await _todoContext.Todos.FindAsync(id);

        if (todo is null)
        {
            return TypedResults.NotFound();
        }

        todo.Name = request.Name;
        await _todoContext.SaveChangesAsync();

        return TypedResults.Ok(todo);
    }
}
