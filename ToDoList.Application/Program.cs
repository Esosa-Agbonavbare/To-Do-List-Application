using System.Data.SqlClient;
using ToDoList.Core.Services;
using ToDoList.Data.Repositories.Implementations;
using ToDoList.Data.Repositories.Interfaces;

namespace ToDoList.Application
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            TodoRepository todoRepository = new TodoRepository();
            TodoService todoService = new TodoService(todoRepository);
            ToDoList toDoListForm = new ToDoList(todoService);
            System.Windows.Forms.Application.Run(toDoListForm);
        }
    }
}