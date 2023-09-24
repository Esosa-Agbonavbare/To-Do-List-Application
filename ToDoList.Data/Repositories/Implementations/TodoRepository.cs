using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Repositories.Interfaces;
using ToDoList.Model;

namespace ToDoList.Data.Repositories.Implementations
{
    public class TodoRepository : ITodoRepository
    {
        public List<TodoItem> GetAllTodoItems()
        {
            List<TodoItem> todoItems = new List<TodoItem>();

            using (SqlConnection connection = new("Server=(localdb)\\MSSqlLocalDb;Database=TODODB;Trusted_Connection=True"))

            try
            {
                connection.Open();

                string query = "SELECT Id, Title, DueDate, Description, Completed FROM TodoTable";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TodoItem todoItem = new TodoItem
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                DueDate = reader.GetDateTime(2),
                                Description = reader.GetString(3),
                                Completed = reader.GetBoolean(4)
                            };

                            todoItems.Add(todoItem);
                        }
                    }
                }
            }
            finally
            {
                connection.Close();
            }

            return todoItems;
        }

        public TodoItem GetById(int id)
        {
            TodoItem todoItem = null;

            using (SqlConnection connection = new("Server=(localdb)\\MSSqlLocalDb;Database=TODODB;Trusted_Connection=True"))

            try
            {
                connection.Open();

                string query = "SELECT Id, Title, DueDate, Description, Completed FROM TodoTable WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            todoItem = new TodoItem
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                DueDate = reader.GetDateTime(2),
                                Description = reader.GetString(3),
                                Completed = reader.GetBoolean(4)
                            };
                        }
                    }
                }
            }
            finally
            {
                connection.Close();
            }

            return todoItem;
        }

        public void Add(TodoItem item)
        {
            using (SqlConnection connection = new("Server=(localdb)\\MSSqlLocalDb;Database=TODODB;Trusted_Connection=True"))
            try
            {
                connection.Open();

                string query = "INSERT INTO TodoTable (Title, DueDate, Description, Completed) " +
                               "VALUES (@Title, @DueDate, @Description, @Completed)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", item.Title);
                    command.Parameters.AddWithValue("@DueDate", item.DueDate);
                    command.Parameters.AddWithValue("@Description", item.Description);
                    command.Parameters.AddWithValue("@Completed", item.Completed);

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void Update(TodoItem item)
        {
            using (SqlConnection connection = new("Server=(localdb)\\MSSqlLocalDb;Database=TODODB;Trusted_Connection=True"))
            try
            {
                connection.Open();

                string query = "UPDATE TodoTable " +
                               "SET Title = @Title, DueDate = @DueDate, Description = @Description, Completed = @Completed " +
                               "WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Title", item.Title);
                    command.Parameters.AddWithValue("@DueDate", item.DueDate);
                    command.Parameters.AddWithValue("@Description", item.Description);
                    command.Parameters.AddWithValue("@Completed", item.Completed);

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new("Server=(localdb)\\MSSqlLocalDb;Database=TODODB;Trusted_Connection=True"))
            try
            {
                connection.Open();

                string query = "DELETE FROM TodoTable WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
