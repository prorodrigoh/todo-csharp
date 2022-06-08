using Models;

namespace Services;

public interface ITodoItemService {
    // a Task is a thread and we expect to get a result
    Task<IEnumerable<TodoItem>> GetAllTodoItems();
    Task<TodoItem> GetTodoItemById(string id);
    Task<TodoItem> UpdateItemById(string id, TodoItem todoItem);
    Task<TodoItem> CreateItemById(TodoItem todoItem);
    

}
public class TodoItemService : ITodoItemService
{
    public Task<TodoItem> CreateItemById(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItem>> GetAllTodoItems()
    {
        throw new NotImplementedException();
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

