using ToDoList.Data.Repositories.Interfaces;
using ToDoList.Model;

namespace ToDoList.Core.Services
{
    public class TodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public void AddTodoItem(TodoItem item)
        {
            _todoRepository.Add(item);
        }

        public void UpdateTodoItem(TodoItem item)
        {
            _todoRepository.Update(item);
        }

        public void DeleteTodoItem(int id)
        {
            _todoRepository.Delete(id);
        }

        public List<TodoItem> GetAllTodoItems()
        {
            return _todoRepository.GetAllTodoItems();
        }

        public TodoItem GetTodoItemById(int id)
        {
            return _todoRepository.GetById(id);
        }
    }
}
