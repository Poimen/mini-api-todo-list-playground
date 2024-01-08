using Microsoft.EntityFrameworkCore;
using MiniApiToDoPlayground.ToDoList.Data.Entities;

namespace MiniApiToDoPlayground.ToDoList.Data;

internal class TodoContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Todo> Todos => Set<Todo>();
}
