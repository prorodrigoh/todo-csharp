using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;
using Settings;

namespace Services;

public interface ITodoItemService {
    // a Task is a thread and we expect to get a result
    Task<IEnumerable<TodoItem>> GetAllTodoItems();
    Task<TodoItem> GetTodoItemById(string id);
    Task<TodoItem> UpdateItemById(string id, TodoItem todoItem);
    Task<TodoItem> CreateTodoItem(TodoItem newTodoItem);
}
public class TodoItemService : ITodoItemService
{
    private readonly IMongoCollection<TodoItem> todoItemCollection;
    public TodoItemService(IOptions<TodoDBSettings> todoDbSettings)
    {
        var client = new MongoClient(todoDbSettings.Value.ConnectionString);
        var db = client.GetDatabase(todoDbSettings.Value.DatabaseName);
        todoItemCollection = db.GetCollection<TodoItem>(todoDbSettings.Value.CollectionName);
        
    }
    
    // CRUD actions 
    public async Task<TodoItem> CreateTodoItem(TodoItem newTodoItem)
    {
        await todoItemCollection.InsertOneAsync(newTodoItem);
        return newTodoItem;
    }

    public async Task<IEnumerable<TodoItem>> GetAllTodoItems()
    {
        var res = await todoItemCollection.FindAsync(x => true); // x is a filter to get all = true
        return res.ToList();
    }

    public Task<TodoItem> GetTodoItemById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<TodoItem> UpdateItemById(string id, TodoItem todoItem)
    {
        throw new NotImplementedException();
    }
}

