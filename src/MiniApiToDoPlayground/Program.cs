using Microsoft.EntityFrameworkCore;
using MiniApiToDoPlayground.TodoList;
using MiniApiToDoPlayground.ToDoList.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("ApiDatabase")));
builder.Services.AddTodoListServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapTodoListEndpoints();

app.Run();
