using Models;
using Services;
using Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<TodoDBSettings>(builder.Configuration.GetSection("TodoDB"));
builder.Services.AddSingleton<ITodoItemService, TodoItemService>();
var app = builder.Build();

//read
app.MapGet("/items", async (ITodoItemService todoItemService) => {
    var todos = await todoItemService.GetAllTodoItems();
    return Results.Ok(todos);
});  

//read by id - http://localhost:5191/items/rod
app.MapGet("/items/{id}", async (string id, ITodoItemService todoItemService) => {

    var todoItem = await todoItemService.GetTodoItemById(id);

    return Results.Ok(todoItem);
    
});

//create
app.MapPost("/items", async (TodoItem newTodoItem, ITodoItemService service) => {
    TodoItem createTodoItem = await service.CreateTodoItem(newTodoItem);
    return Results.Created($"items/{createTodoItem}", createTodoItem);
});

app.MapPut("/items/{id}", (string id) => {});       //update
app.MapDelete("/items/{id}", (string id) => {});    //delete

app.Run();
