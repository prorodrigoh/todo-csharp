using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITodoItemService, TodoItemService>();
var app = builder.Build();

//read
app.MapGet("/items", () => {});  

//read by id - http://localhost:5191/items/rod
app.MapGet("/items/{id}", (string id) => {

    var todoItem = new {
        Id = Guid.NewGuid().ToString(),
        Title = "Complete Todo in C#",
        IsCompleted = false
    };
    return Results.Ok(todoItem);
    
});

app.MapPost("/items", () => {});                    //create
app.MapPut("/items/{id}", (string id) => {});       //update
app.MapDelete("/items/{id}", (string id) => {});    //delete

app.Run();
