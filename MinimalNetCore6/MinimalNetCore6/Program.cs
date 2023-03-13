using Microsoft.EntityFrameworkCore;
using MinimalNetCore6;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.MapPostArray();

// app.MapArray();

///////////////////////////////////////

app.MapTodoitems();

app.Run();

public class ArrayModel
{
    public int[]? ArrayNumber { get; set; }
    public int? SortType { get; set; }
}

public class SetArray
{
    public int[]? ArrayNumber { get; set;}
}

class Todo
{
    public int Id { get; set; }
    public string? Product { get; set; }
    public double Price { get; set; }
    public bool IsComplete { get; set; }

}

