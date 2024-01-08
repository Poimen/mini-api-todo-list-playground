using MiniApiToDoPlayground.ToDoList.Data;
using MiniApiToDoPlayground.ToDoList.Data.Entities;

namespace MiniApiToDoPlayground.TodoList.CreateTodo;

internal interface ICreateTodoHandler
{
    ValueTask<Todo> CreateNewTodo(CreateTodoRequest request);
}

internal class CreateTodoHandler : ICreateTodoHandler
{
    private readonly TodoContext _todoContext;

    public CreateTodoHandler(TodoContext todoContext)
    {
        _todoContext = todoContext;
    }

    public async ValueTask<Todo> CreateNewTodo(CreateTodoRequest request)
    {
        var todo = new Todo
        {
            Name = request.Name,
            IsComplete = false
        };

        await _todoContext.Todos.AddAsync(todo);

        await _todoContext.SaveChangesAsync();

        return todo;
    }
}
