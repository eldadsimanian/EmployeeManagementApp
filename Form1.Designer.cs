namespace EmployeeManagementApp
{
    partial class Form1
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
            grpAddEmployee = new GroupBox();
            txtStockOptions = new TextBox();
            lblStockOptions = new Label();
            txtHoursWorked = new TextBox();
            lblHoursWorked = new Label();
            btnAddEmployee = new Button();
            txtBonus = new TextBox();
            lblBonus = new Label();
            txtHourlyRate = new TextBox();
            lblHourlyRate = new Label();
            txtMonthlySalary = new TextBox();
            lblMonthlySalary = new Label();
            cmbEmployeeType = new ComboBox();
            lblEmployeeType = new Label();
            txtDepartment = new TextBox();
            lblDepartment = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            txtEmployeeId = new TextBox();
            lblEmployeeId = new Label();
            dataGridViewEmployees = new DataGridView();
            IdColumn = new DataGridViewTextBoxColumn();
            FirstNameColumn = new DataGridViewTextBoxColumn();
            LastNameColumn = new DataGridViewTextBoxColumn();
            DepartmentColumn = new DataGridViewTextBoxColumn();
            EmployeeTypeColumn = new DataGridViewTextBoxColumn();
            DetailsColumn = new DataGridViewTextBoxColumn();
            btnShowAllEmployees = new Button();
            grpRemoveEmployee = new GroupBox();
            btnRemoveEmployee = new Button();
            txtRemoveId = new TextBox();
            lblRemoveId = new Label();
            grpFileOperations = new GroupBox();
            btnLoad = new Button();
            btnSave = new Button();
            grpAddEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).BeginInit();
            grpRemoveEmployee.SuspendLayout();
            grpFileOperations.SuspendLayout();
            SuspendLayout();
            // 
            // grpAddEmployee
            // 
            grpAddEmployee.BackColor = SystemColors.ActiveCaption;
            grpAddEmployee.Controls.Add(txtStockOptions);
            grpAddEmployee.Controls.Add(lblStockOptions);
            grpAddEmployee.Controls.Add(txtHoursWorked);
            grpAddEmployee.Controls.Add(lblHoursWorked);
            grpAddEmployee.Controls.Add(btnAddEmployee);
            grpAddEmployee.Controls.Add(txtBonus);
            grpAddEmployee.Controls.Add(lblBonus);
            grpAddEmployee.Controls.Add(txtHourlyRate);
            grpAddEmployee.Controls.Add(lblHourlyRate);
            grpAddEmployee.Controls.Add(txtMonthlySalary);
            grpAddEmployee.Controls.Add(lblMonthlySalary);
            grpAddEmployee.Controls.Add(cmbEmployeeType);
            grpAddEmployee.Controls.Add(lblEmployeeType);
            grpAddEmployee.Controls.Add(txtDepartment);
            grpAddEmployee.Controls.Add(lblDepartment);
            grpAddEmployee.Controls.Add(txtLastName);
            grpAddEmployee.Controls.Add(lblLastName);
            grpAddEmployee.Controls.Add(txtFirstName);
            grpAddEmployee.Controls.Add(lblFirstName);
            grpAddEmployee.Controls.Add(txtEmployeeId);
            grpAddEmployee.Controls.Add(lblEmployeeId);
            grpAddEmployee.Location = new Point(34, 12);
            grpAddEmployee.Name = "grpAddEmployee";
            grpAddEmployee.Size = new Size(747, 306);
            grpAddEmployee.TabIndex = 0;
            grpAddEmployee.TabStop = false;
            grpAddEmployee.Text = "Add New Employee";
            // 
            // txtStockOptions
            // 
            txtStockOptions.Location = new Point(417, 56);
            txtStockOptions.Name = "txtStockOptions";
            txtStockOptions.Size = new Size(125, 27);
            txtStockOptions.TabIndex = 20;
            txtStockOptions.Visible = false;
            // 
            // lblStockOptions
            // 
            lblStockOptions.AutoSize = true;
            lblStockOptions.Location = new Point(417, 33);
            lblStockOptions.Name = "lblStockOptions";
            lblStockOptions.Size = new Size(97, 20);
            lblStockOptions.TabIndex = 19;
            lblStockOptions.Text = "StockOptions";
            lblStockOptions.Visible = false;
            // 
            // txtHoursWorked
            // 
            txtHoursWorked.Location = new Point(473, 142);
            txtHoursWorked.Name = "txtHoursWorked";
            txtHoursWorked.Size = new Size(125, 27);
            txtHoursWorked.TabIndex = 18;
            txtHoursWorked.Visible = false;
            // 
            // lblHoursWorked
            // 
            lblHoursWorked.AutoSize = true;
            lblHoursWorked.Location = new Point(487, 122);
            lblHoursWorked.Name = "lblHoursWorked";
            lblHoursWorked.Size = new Size(103, 20);
            lblHoursWorked.TabIndex = 17;
            lblHoursWorked.Text = "Hours Worked";
            lblHoursWorked.Visible = false;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Location = new Point(224, 192);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(124, 29);
            btnAddEmployee.TabIndex = 16;
            btnAddEmployee.Text = "Add Employee";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // txtBonus
            // 
            txtBonus.Location = new Point(604, 142);
            txtBonus.Name = "txtBonus";
            txtBonus.Size = new Size(125, 27);
            txtBonus.TabIndex = 15;
            txtBonus.Visible = false;
            // 
            // lblBonus
            // 
            lblBonus.AutoSize = true;
            lblBonus.Location = new Point(632, 122);
            lblBonus.Name = "lblBonus";
            lblBonus.Size = new Size(49, 20);
            lblBonus.TabIndex = 14;
            lblBonus.Text = "Bonus";
            lblBonus.Visible = false;
            // 
            // txtHourlyRate
            // 
            txtHourlyRate.Location = new Point(340, 142);
            txtHourlyRate.Name = "txtHourlyRate";
            txtHourlyRate.Size = new Size(125, 27);
            txtHourlyRate.TabIndex = 13;
            txtHourlyRate.Visible = false;
            // 
            // lblHourlyRate
            // 
            lblHourlyRate.AutoSize = true;
            lblHourlyRate.Location = new Point(360, 122);
            lblHourlyRate.Name = "lblHourlyRate";
            lblHourlyRate.Size = new Size(87, 20);
            lblHourlyRate.TabIndex = 12;
            lblHourlyRate.Text = "Hourly Rate";
            lblHourlyRate.Visible = false;
            // 
            // txtMonthlySalary
            // 
            txtMonthlySalary.Location = new Point(209, 142);
            txtMonthlySalary.Name = "txtMonthlySalary";
            txtMonthlySalary.Size = new Size(125, 27);
            txtMonthlySalary.TabIndex = 11;
            txtMonthlySalary.Visible = false;
            // 
            // lblMonthlySalary
            // 
            lblMonthlySalary.AutoSize = true;
            lblMonthlySalary.Location = new Point(209, 119);
            lblMonthlySalary.Name = "lblMonthlySalary";
            lblMonthlySalary.Size = new Size(107, 20);
            lblMonthlySalary.TabIndex = 10;
            lblMonthlySalary.Text = "Monthly Salary";
            lblMonthlySalary.Visible = false;
            // 
            // cmbEmployeeType
            // 
            cmbEmployeeType.FormattingEnabled = true;
            cmbEmployeeType.Items.AddRange(new object[] { "SalariedEmployee", "", "", "HourlyEmployee", "", "", "Manager", "", "", "Executive" });
            cmbEmployeeType.Location = new Point(212, 65);
            cmbEmployeeType.Name = "cmbEmployeeType";
            cmbEmployeeType.Size = new Size(151, 28);
            cmbEmployeeType.TabIndex = 9;
            cmbEmployeeType.SelectedIndexChanged += cmbEmployeeType_SelectedIndexChanged;
            // 
            // lblEmployeeType
            // 
            lblEmployeeType.AutoSize = true;
            lblEmployeeType.Location = new Point(209, 33);
            lblEmployeeType.Name = "lblEmployeeType";
            lblEmployeeType.Size = new Size(113, 20);
            lblEmployeeType.TabIndex = 8;
            lblEmployeeType.Text = "Employee Type:";
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(6, 264);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(125, 27);
            txtDepartment.TabIndex = 7;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(6, 241);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(89, 20);
            lblDepartment.TabIndex = 6;
            lblDepartment.Text = "Department";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(6, 189);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 5;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(6, 166);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(79, 20);
            lblLastName.TabIndex = 4;
            lblLastName.Text = "Last Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(6, 119);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 3;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(6, 96);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(83, 20);
            lblFirstName.TabIndex = 2;
            lblFirstName.Text = "First Name:";
            // 
            // txtEmployeeId
            // 
            txtEmployeeId.Location = new Point(6, 56);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.Size = new Size(125, 27);
            txtEmployeeId.TabIndex = 1;
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Location = new Point(6, 33);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(24, 20);
            lblEmployeeId.TabIndex = 0;
            lblEmployeeId.Text = "ID";
            // 
            // dataGridViewEmployees
            // 
            dataGridViewEmployees.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmployees.Columns.AddRange(new DataGridViewColumn[] { IdColumn, FirstNameColumn, LastNameColumn, DepartmentColumn, EmployeeTypeColumn, DetailsColumn });
            dataGridViewEmployees.Location = new Point(830, 45);
            dataGridViewEmployees.Name = "dataGridViewEmployees";
            dataGridViewEmployees.RowHeadersWidth = 51;
            dataGridViewEmployees.Size = new Size(954, 188);
            dataGridViewEmployees.TabIndex = 1;
            // 
            // IdColumn
            // 
            IdColumn.HeaderText = "ID";
            IdColumn.MinimumWidth = 6;
            IdColumn.Name = "IdColumn";
            IdColumn.Width = 125;
            // 
            // FirstNameColumn
            // 
            FirstNameColumn.HeaderText = "First Name";
            FirstNameColumn.MinimumWidth = 6;
            FirstNameColumn.Name = "FirstNameColumn";
            FirstNameColumn.Width = 125;
            // 
            // LastNameColumn
            // 
            LastNameColumn.HeaderText = "Last Name";
            LastNameColumn.MinimumWidth = 6;
            LastNameColumn.Name = "LastNameColumn";
            LastNameColumn.Width = 125;
            // 
            // DepartmentColumn
            // 
            DepartmentColumn.HeaderText = "Department";
            DepartmentColumn.MinimumWidth = 6;
            DepartmentColumn.Name = "DepartmentColumn";
            DepartmentColumn.Width = 125;
            // 
            // EmployeeTypeColumn
            // 
            EmployeeTypeColumn.HeaderText = "EmployeeTypeColumn";
            EmployeeTypeColumn.MinimumWidth = 6;
            EmployeeTypeColumn.Name = "EmployeeTypeColumn";
            EmployeeTypeColumn.Width = 125;
            // 
            // DetailsColumn
            // 
            DetailsColumn.HeaderText = "Details";
            DetailsColumn.MinimumWidth = 6;
            DetailsColumn.Name = "DetailsColumn";
            DetailsColumn.Width = 125;
            // 
            // btnShowAllEmployees
            // 
            btnShowAllEmployees.Location = new Point(830, 12);
            btnShowAllEmployees.Name = "btnShowAllEmployees";
            btnShowAllEmployees.Size = new Size(227, 29);
            btnShowAllEmployees.TabIndex = 2;
            btnShowAllEmployees.Text = "Show All Employees";
            btnShowAllEmployees.UseVisualStyleBackColor = true;
            btnShowAllEmployees.Click += btnShowAllEmployees_Click;
            // 
            // grpRemoveEmployee
            // 
            grpRemoveEmployee.BackColor = SystemColors.ActiveCaption;
            grpRemoveEmployee.Controls.Add(btnRemoveEmployee);
            grpRemoveEmployee.Controls.Add(txtRemoveId);
            grpRemoveEmployee.Controls.Add(lblRemoveId);
            grpRemoveEmployee.Location = new Point(179, 385);
            grpRemoveEmployee.Name = "grpRemoveEmployee";
            grpRemoveEmployee.Size = new Size(454, 219);
            grpRemoveEmployee.TabIndex = 3;
            grpRemoveEmployee.TabStop = false;
            grpRemoveEmployee.Text = "Remove Employee";
            // 
            // btnRemoveEmployee
            // 
            btnRemoveEmployee.Location = new Point(6, 143);
            btnRemoveEmployee.Name = "btnRemoveEmployee";
            btnRemoveEmployee.Size = new Size(170, 29);
            btnRemoveEmployee.TabIndex = 9;
            btnRemoveEmployee.Text = "Remove Employee";
            btnRemoveEmployee.UseVisualStyleBackColor = true;
            btnRemoveEmployee.Click += btnRemoveEmployee_Click;
            // 
            // txtRemoveId
            // 
            txtRemoveId.Location = new Point(4, 65);
            txtRemoveId.Name = "txtRemoveId";
            txtRemoveId.Size = new Size(125, 27);
            txtRemoveId.TabIndex = 8;
            // 
            // lblRemoveId
            // 
            lblRemoveId.AutoSize = true;
            lblRemoveId.Location = new Point(6, 42);
            lblRemoveId.Name = "lblRemoveId";
            lblRemoveId.Size = new Size(170, 20);
            lblRemoveId.TabIndex = 0;
            lblRemoveId.Text = "Employee ID to Remove";
            // 
            // grpFileOperations
            // 
            grpFileOperations.BackColor = SystemColors.ActiveCaption;
            grpFileOperations.Controls.Add(btnLoad);
            grpFileOperations.Controls.Add(btnSave);
            grpFileOperations.Location = new Point(1084, 405);
            grpFileOperations.Name = "grpFileOperations";
            grpFileOperations.Size = new Size(441, 209);
            grpFileOperations.TabIndex = 4;
            grpFileOperations.TabStop = false;
            grpFileOperations.Text = "File Operations";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(6, 93);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(211, 29);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load Employee Data";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(6, 45);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(211, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save Employee Data";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1777, 792);
            Controls.Add(grpFileOperations);
            Controls.Add(grpRemoveEmployee);
            Controls.Add(btnShowAllEmployees);
            Controls.Add(dataGridViewEmployees);
            Controls.Add(grpAddEmployee);
            Name = "Form1";
            Text = "Form1";
            grpAddEmployee.ResumeLayout(false);
            grpAddEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).EndInit();
            grpRemoveEmployee.ResumeLayout(false);
            grpRemoveEmployee.PerformLayout();
            grpFileOperations.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpAddEmployee;
        private Label lblEmployeeId;
        private TextBox txtEmployeeId;
        private TextBox txtFirstName;
        private Label lblFirstName;
        private Label lblDepartment;
        private TextBox txtLastName;
        private Label lblLastName;
        private Label lblEmployeeType;
        private TextBox txtDepartment;
        private ComboBox cmbEmployeeType;
        private TextBox txtMonthlySalary;
        private Label lblMonthlySalary;
        private Label lblHourlyRate;
        private Button btnAddEmployee;
        private TextBox txtBonus;
        private Label lblBonus;
        private TextBox txtHourlyRate;
        private DataGridView dataGridViewEmployees;
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewTextBoxColumn FirstNameColumn;
        private DataGridViewTextBoxColumn LastNameColumn;
        private DataGridViewTextBoxColumn DepartmentColumn;
        private DataGridViewTextBoxColumn EmployeeTypeColumn;
        private DataGridViewTextBoxColumn DetailsColumn;
        private Button btnShowAllEmployees;
        private GroupBox grpRemoveEmployee;
        private Button btnRemoveEmployee;
        private TextBox txtRemoveId;
        private Label lblRemoveId;
        private GroupBox grpFileOperations;
        private Button btnLoad;
        private Button btnSave;
        private TextBox txtHoursWorked;
        private Label lblHoursWorked;
        private TextBox txtStockOptions;
        private Label lblStockOptions;
    }
}
