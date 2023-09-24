using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model;

namespace ToDoList.Data.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        List<TodoItem> GetAllTodoItems();
        TodoItem GetById(int id);
        void Add(TodoItem item);
        void Update(TodoItem item);
        void Delete(int id);
    }
}
