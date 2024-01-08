using Microsoft.AspNetCore.Http.HttpResults;
using MiniApiToDoPlayground.ToDoList.Data;
using MiniApiToDoPlayground.ToDoList.Data.Entities;

namespace MiniApiToDoPlayground.TodoList.CompleteTodo;

internal interface ICompleteTodoHandler
{
    ValueTask<Results<Ok<Todo>, NotFound>> CompleteTodo(int id);
}

internal class CompleteTodoHandler : ICompleteTodoHandler
{
    private readonly TodoContext _todoContext;

    public CompleteTodoHandler(TodoContext todoContext)
    {
        _todoContext = todoContext;
    }

    public async ValueTask<Results<Ok<Todo>, NotFound>> CompleteTodo(int id)
    {
        var todo = await _todoContext.Todos.FindAsync(id);

        if (todo is null)
        {
            return TypedResults.NotFound();
        }

        todo.IsComplete = true;
        await _todoContext.SaveChangesAsync();

        return TypedResults.Ok(todo);
    }
}
