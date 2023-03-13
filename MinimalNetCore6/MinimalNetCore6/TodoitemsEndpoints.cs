using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Diagnostics.Eventing.Reader;

namespace MinimalNetCore6
{
    public static class TodoitemsEndpoints
    {
        public static void MapTodoitems(this WebApplication app)
        {
            List<Todo> todos = new List<Todo>();
           
            app.MapGet("/todoitems", () =>
            {
                return Results.Ok(todos);
            });

            app.MapPost("/todoitems", (Todo todo) =>
            {
                todos.Add(todo);
                return Results.Created($"/todoitems/{todo.Id}", todo);
            });

            app.MapGet("/todoitems/complete", () =>
            {
                return Results.Ok(todos.Where(t => t.IsComplete));
            });

            app.MapGet("/todoitems/{id}", (int id) =>
            {
                var todo = todos.Find(t => t.Id == id);
                if (todo != null)
                {                   
                    return Results.Ok(todo);
                }
                else
                    return Results.NotFound();
            });

            app.MapPut("/todoitems/{id}", (int id, Todo inputTodo) =>
            {                
                var todo = todos.Find(t => t.Id == id);
                if (todo != null)
                {
                    todo.Product = inputTodo.Product;
                    todo.Price = inputTodo.Price;
                    todo.IsComplete = inputTodo.IsComplete;
                    return Results.NoContent();
                }
                else 
                    return Results.NotFound();              
            });

            app.MapDelete("/todoitems/{id}", (int id) =>
            {
                var todo = todos.Find(t => t.Id == id);
                if (todo != null)
                {   
                    todos.Remove(todo);
                    return Results.NoContent();
                }
                else
                    return Results.NotFound();
            });
        }
    }
}
