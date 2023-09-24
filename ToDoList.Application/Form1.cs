using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using static ToDoList.Application.ToDoList;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using ToDoList.Core.Services;
using ToDoList.Model;

namespace ToDoList.Application
{
    public partial class ToDoList : Form
    {
        private readonly TodoService _toDoService;

        public ToDoList(TodoService toDoService)
        {
            _toDoService = toDoService;
            InitializeComponent();
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            RefreshDataGridView();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            AddTodoItem();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            DescriptionTextBox.Text = "";
            idtxt.Text = "";
            TitleTextBox.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (checkedIn.Count == 0)
            {
                MessageBox.Show("Select record(s) to delete");
                return;
            }

            DeleteTodoItems();

            MessageBox.Show("Information deleted successfully");
        }

        private void RefreshDataGridView()
        {
            List<TodoItem> todoItems = _toDoService.GetAllTodoItems();
            DataGridView.DataSource = todoItems;
        }

        public void AddTodoItem()
        {
            if (TitleTextBox.Text == "" || DescriptionTextBox.Text == "")
            {
                MessageBox.Show("Please input all fields");
                return;
            }

            TodoItem newItem = new TodoItem
            {
                Title = TitleTextBox.Text,
                DueDate = dateTimePicker1.Value,
                Description = DescriptionTextBox.Text,
                Completed = comboBox1.SelectedItem.ToString() == "Completed"
            };

            _toDoService.AddTodoItem(newItem);

            RefreshDataGridView();

            Reset();
        }

        DataGridViewCheckBoxColumn check;
        DataGridViewButtonColumn button;

        public void showAll()
        {
            check = new DataGridViewCheckBoxColumn();
            check.Name = "CheckItem";
            check.HeaderText = "Select";

            button = new DataGridViewButtonColumn();
            button.Name = "Edit";
            button.HeaderText = "Edit";
            button.Text = "Edit";
            button.UseColumnTextForButtonValue = true;

            string sql = "usp_todoapp '','','','','','VIEW'";

            DataGridView.Columns.Clear();
            DataGridView.Columns.Add(check);

            DataGridView.Columns.Add(button);
        }

        List<string> checkedIn = new List<string>();

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataGridView.Columns["CheckItem"].Index)
            {
                HandleCheckBoxColumnClick(e.RowIndex);
            }
            else if (e.ColumnIndex == DataGridView.Columns["Edit"].Index)
            {
                HandleEditButtonColumnClick(e.RowIndex);
            }
        }

        private void HandleCheckBoxColumnClick(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < DataGridView.Rows.Count)
            {
                DataGridViewCheckBoxCell checkCell = DataGridView.Rows[rowIndex].Cells["CheckItem"] as DataGridViewCheckBoxCell;
                DataGridViewTextBoxCell idCell = DataGridView.Rows[rowIndex].Cells["Id"] as DataGridViewTextBoxCell;

                if (checkCell != null && idCell != null)
                {
                    object checkCellValue = checkCell.Value;
                    object idCellValue = idCell.Value;

                    if (checkCellValue != null && idCellValue != null)
                    {
                        bool isChecked = (bool)checkCellValue;
                        string id = idCellValue.ToString();

                        if (isChecked && !checkedIn.Contains(id))
                        {
                            checkedIn.Add(id);
                        }
                        else if (!isChecked && checkedIn.Contains(id))
                        {
                            checkedIn.Remove(id);
                        }
                    }
                }
            }
        }

        private void HandleEditButtonColumnClick(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < DataGridView.Rows.Count)
            {
                DataGridViewTextBoxCell idCell = DataGridView.Rows[rowIndex].Cells["Id"] as DataGridViewTextBoxCell;
                DataGridViewTextBoxCell titleCell = DataGridView.Rows[rowIndex].Cells["Title"] as DataGridViewTextBoxCell;
                DataGridViewTextBoxCell descriptionCell = DataGridView.Rows[rowIndex].Cells["Description"] as DataGridViewTextBoxCell;
                DataGridViewTextBoxCell dateCell = DataGridView.Rows[rowIndex].Cells["DueDate"] as DataGridViewTextBoxCell;
                DataGridViewCheckBoxCell completedCell = DataGridView.Rows[rowIndex].Cells["Completed"] as DataGridViewCheckBoxCell;

                if (idCell != null && titleCell != null && descriptionCell != null && dateCell != null && completedCell != null)
                {
                    object idCellValue = idCell.Value;
                    object titleCellValue = titleCell.Value;
                    object descriptionCellValue = descriptionCell.Value;
                    object dateCellValue = dateCell.Value;
                    object completedCellValue = completedCell.Value;

                    if (idCellValue != null && titleCellValue != null && descriptionCellValue != null && dateCellValue != null && completedCellValue != null)
                    {
                        idtxt.Text = idCellValue.ToString();
                        TitleTextBox.Text = titleCellValue.ToString();
                        DescriptionTextBox.Text = descriptionCellValue.ToString();
                        dateTimePicker1.Value = DateTime.Parse(dateCellValue.ToString());
                        comboBox1.SelectedItem = completedCellValue.ToString();
                    }
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (idtxt.Text == "")
            {
                MessageBox.Show("Select record to update");
                return;
            }

            UpdateTodoItem();
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string search = SearchTextBox.Text;
            if (search == "")
            {
                showAll();
            }
            else
            {
                string? search_criteria = comboBox1.SelectedIndex == 0 ? "TITLE" : "DATE";
                string sql = "usp_todoapp '','','','','" + search + "','" + search_criteria + "'";
            }
        }

        private void UpdateTodoItem()
        {
            if (int.TryParse(idtxt.Text, out int itemId))
            {

                TodoItem updatedItem = new TodoItem
                {
                    Id = itemId,
                    Title = TitleTextBox.Text,
                    DueDate = dateTimePicker1.Value,
                    Description = DescriptionTextBox.Text,
                    Completed = comboBox1.SelectedItem.ToString() == "Completed"
                };

                _toDoService.UpdateTodoItem(updatedItem);

                RefreshDataGridView();

                Reset();
            }
            else
            {
                MessageBox.Show("Invalid item ID.");
            }
        }

        private void DeleteTodoItems()
        {
            List<string> checkedItems = new List<string>();

            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells["CheckItem"] as DataGridViewCheckBoxCell;
                if (checkCell.Value != null && (bool)checkCell.Value)
                {
                    string itemId = row.Cells["Id"].Value.ToString();
                    checkedItems.Add(itemId);
                }
            }

            foreach (string itemId in checkedItems)
            {
                if (int.TryParse(itemId, out int id))
                {
                    _toDoService.DeleteTodoItem(id);
                }
            }

            RefreshDataGridView();

            Reset();
        }

        private void SearchTextBox_KeyUp_1(object sender, KeyEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            string searchCriteria = comboBox2.SelectedItem.ToString();

            // Perform the search as the user types
            PerformSearch(searchText, searchCriteria);
        }

        private void PerformSearch(string searchText, string searchCriteria)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                RefreshDataGridView();
                return;
            }

            string connectionString = "Server=(localdb)\\MSSqlLocalDb;Database=TODODB;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "";

                if (searchCriteria == "By Title")
                {
                    // Define the SQL query for title search
                    query = "SELECT Id, Title, DueDate, Description, Completed FROM TodoTable WHERE Title LIKE @SearchText";
                }
                else if (searchCriteria == "By Date")
                {
                    // Attempt to convert the search text to a valid date format
                    string formattedDate = ConvertToValidDateFormat(searchText);

                    if (formattedDate == null)
                    {
                        MessageBox.Show("Invalid date format. Please use a valid date format (e.g., YYYY-MM-DD).");
                        return;
                    }

                    // Define the SQL query for date search
                    query = "SELECT Id, Title, DueDate, Description, Completed FROM TodoTable WHERE DueDate = @SearchDate";
                }
                else
                {
                    // Handle unsupported search criteria
                    MessageBox.Show("Unsupported search criteria.");
                    return;
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (searchCriteria == "By Title")
                    {
                        // Add a parameter for the title search text
                        command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    }
                    else if (searchCriteria == "By Date")
                    {
                        // Add a parameter for the date search
                        command.Parameters.AddWithValue("@SearchDate", searchText);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the search results to the DataGridView
                        DataGridView.DataSource = dataTable;
                    }
                }
            }
        }

        private string ConvertToValidDateFormat(string searchText)
        {
            string[] inputDateFormats = { "MM/dd/yyyy", "M/dd/yyyy", "MM/d/yyyy", "M/d/yyyy", "MM/dd/yy", "M/dd/yy", "MM/d/yy", "M/d/yy" };

            foreach (string format in inputDateFormats)
            {
                if (DateTime.TryParseExact(searchText, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    // If a valid date is found, return it in the "yyyy-MM-dd" format
                    return result.ToString("yyyy-MM-dd");
                }
            }

            return null;
        }
    }
}