namespace ToDoList.Application
{
    partial class ToDoList
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToDoList));
            menuStrip1 = new MenuStrip();
            myToDoListToolStripMenuItem = new ToolStripMenuItem();
            jToolStripMenuItem = new ToolStripMenuItem();
            comboBox2 = new ToolStripComboBox();
            SearchTextBox = new ToolStripTextBox();
            DeleteButton = new Button();
            TitleTextBox = new TextBox();
            UpdateButton = new Button();
            SaveButton = new Button();
            NewButton = new Button();
            DescriptionTextBox = new TextBox();
            DataGridView = new DataGridView();
            CheckItem = new DataGridViewCheckBoxColumn();
            Edit = new DataGridViewButtonColumn();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            idtxt = new Label();
            comboBox1 = new ComboBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Wheat;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { myToDoListToolStripMenuItem, jToolStripMenuItem, comboBox2, SearchTextBox });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1727, 60);
            menuStrip1.Stretch = false;
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // myToDoListToolStripMenuItem
            // 
            myToDoListToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            myToDoListToolStripMenuItem.Image = (Image)resources.GetObject("myToDoListToolStripMenuItem.Image");
            myToDoListToolStripMenuItem.Margin = new Padding(0, 10, 0, 10);
            myToDoListToolStripMenuItem.Name = "myToDoListToolStripMenuItem";
            myToDoListToolStripMenuItem.Size = new Size(213, 36);
            myToDoListToolStripMenuItem.Text = "My To-Do List";
            // 
            // jToolStripMenuItem
            // 
            jToolStripMenuItem.Image = (Image)resources.GetObject("jToolStripMenuItem.Image");
            jToolStripMenuItem.Margin = new Padding(1030, 0, 0, 0);
            jToolStripMenuItem.Name = "jToolStripMenuItem";
            jToolStripMenuItem.Size = new Size(40, 56);
            // 
            // comboBox2
            // 
            comboBox2.Items.AddRange(new object[] { "By Title" });
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 56);
            // 
            // SearchTextBox
            // 
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(300, 56);
            SearchTextBox.KeyUp += SearchTextBox_KeyUp_1;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = Color.FromArgb(2, 14, 53);
            DeleteButton.ForeColor = Color.White;
            DeleteButton.Location = new Point(1546, 84);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(177, 35);
            DeleteButton.TabIndex = 9;
            DeleteButton.Text = "Delete Selected";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // TitleTextBox
            // 
            TitleTextBox.Location = new Point(523, 225);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(819, 31);
            TitleTextBox.TabIndex = 10;
            // 
            // UpdateButton
            // 
            UpdateButton.BackColor = Color.Wheat;
            UpdateButton.Location = new Point(1420, 85);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(112, 34);
            UpdateButton.TabIndex = 11;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = false;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.Wheat;
            SaveButton.Location = new Point(1292, 85);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(112, 34);
            SaveButton.TabIndex = 12;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // NewButton
            // 
            NewButton.BackColor = Color.Wheat;
            NewButton.Location = new Point(386, 86);
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(112, 34);
            NewButton.TabIndex = 13;
            NewButton.Text = "New";
            NewButton.UseVisualStyleBackColor = false;
            NewButton.Click += NewButton_Click;
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new Point(522, 295);
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(819, 31);
            DescriptionTextBox.TabIndex = 14;
            // 
            // DataGridView
            // 
            DataGridView.AllowUserToAddRows = false;
            DataGridView.AllowUserToDeleteRows = false;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.BackgroundColor = Color.FromArgb(2, 14, 53);
            DataGridView.BorderStyle = BorderStyle.None;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Columns.AddRange(new DataGridViewColumn[] { CheckItem, Edit });
            DataGridView.Location = new Point(54, 392);
            DataGridView.Name = "DataGridView";
            DataGridView.RowHeadersWidth = 62;
            DataGridView.RowTemplate.Height = 33;
            DataGridView.Size = new Size(1661, 443);
            DataGridView.TabIndex = 16;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // CheckItem
            // 
            CheckItem.HeaderText = "Check";
            CheckItem.MinimumWidth = 8;
            CheckItem.Name = "CheckItem";
            CheckItem.Resizable = DataGridViewTriState.True;
            CheckItem.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Edit
            // 
            Edit.HeaderText = "Edit";
            Edit.MinimumWidth = 8;
            Edit.Name = "Edit";
            Edit.Text = "Edit";
            Edit.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(410, 225);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 17;
            label1.Text = "Title:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(410, 298);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 18;
            label2.Text = "Description:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(54, 88);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 19;
            // 
            // idtxt
            // 
            idtxt.AutoSize = true;
            idtxt.Location = new Point(570, 92);
            idtxt.Name = "idtxt";
            idtxt.Size = new Size(0, 25);
            idtxt.TabIndex = 22;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(2, 14, 53);
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "yes", "no" });
            comboBox1.Location = new Point(1720, 85);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(1, 33);
            comboBox1.TabIndex = 23;
            // 
            // ToDoList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 14, 53);
            ClientSize = new Size(1727, 858);
            Controls.Add(comboBox1);
            Controls.Add(idtxt);
            Controls.Add(menuStrip1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DataGridView);
            Controls.Add(DescriptionTextBox);
            Controls.Add(NewButton);
            Controls.Add(SaveButton);
            Controls.Add(UpdateButton);
            Controls.Add(TitleTextBox);
            Controls.Add(DeleteButton);
            ForeColor = Color.FromArgb(2, 14, 53);
            MainMenuStrip = menuStrip1;
            Name = "ToDoList";
            Text = "ToDoList";
            Load += ToDoList_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem myToDoListToolStripMenuItem;
        private ToolStripMenuItem jToolStripMenuItem;
        private Button DeleteButton;
        private TextBox TitleTextBox;
        private Button UpdateButton;
        private Button SaveButton;
        private Button NewButton;
        private TextBox DescriptionTextBox;
        private DataGridView DataGridView;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label idtxt;
        private DataGridViewCheckBoxColumn CheckItem;
        private DataGridViewButtonColumn Edit;
        private ComboBox comboBox1;
        private ToolStripComboBox comboBox2;
        private ToolStripTextBox SearchTextBox;
    }
}