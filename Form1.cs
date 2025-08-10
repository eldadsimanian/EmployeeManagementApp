using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // ���� ����� �-LINQ ��� .FirstOrDefault()
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // ���� ������ �����
using System.Text.Json; // ���� ����������� JSON
#nullable enable


namespace EmployeeManagementApp 
{
    public partial class Form1 : Form
    {
        private List<Employee> _employees = new List<Employee>(); // ��� ����� ����� �-List
        private const string FilePath = "employees.json"; // ���� ���� ����� �����

        public Form1()
        {
            InitializeComponent();

         
     
            if (cmbEmployeeType.Items.Count == 0)
            {
                cmbEmployeeType.Items.AddRange(new object[] {
                    "SalariedEmployee",
                    "HourlyEmployee",
                    "Manager",
                    "Executive"
                });
            }
            cmbEmployeeType.SelectedIndex = 0; 

        
            UpdateEmployeeSpecificFieldsVisibility();

            // ��� ������ ��� ����� ����� (�� ����� ����)
            LoadFromFile();
            RefreshDataGridView(); // ���� �� ������ ���� �����
        }

        // ���� ������ ����� ����� ��������� �����
        // (����� �-Load ��-ComboBox SelectedIndexChanged)
        private void UpdateEmployeeSpecificFieldsVisibility()
        {
            // ���� �� �� ����� ��������� ������
            lblMonthlySalary.Visible = false;
            txtMonthlySalary.Visible = false;
            lblHourlyRate.Visible = false;
            txtHourlyRate.Visible = false;
            lblHoursWorked.Visible = false;
            txtHoursWorked.Visible = false;
            lblBonus.Visible = false;
            txtBonus.Visible = false;
            lblStockOptions.Visible = false; 
            txtStockOptions.Visible = false; 

            // ��� ���� ������ �� ��� ����� �����
            if (cmbEmployeeType.SelectedItem == null) return;

            string selectedType = cmbEmployeeType.SelectedItem.ToString();

            switch (selectedType)
            {
                case "SalariedEmployee":
                    lblMonthlySalary.Visible = true;
                    txtMonthlySalary.Visible = true;
                    break;
                case "HourlyEmployee":
                    lblHourlyRate.Visible = true;
                    txtHourlyRate.Visible = true;
                    lblHoursWorked.Visible = true;
                    txtHoursWorked.Visible = true;
                    break;
                case "Manager":
                    lblMonthlySalary.Visible = true;
                    txtMonthlySalary.Visible = true;
                    lblBonus.Visible = true;
                    txtBonus.Visible = true;
                    break;
                case "Executive": 
                    lblMonthlySalary.Visible = true;
                    txtMonthlySalary.Visible = true;
                    lblBonus.Visible = true;
                    txtBonus.Visible = true;
                    lblStockOptions.Visible = true; // ��� �� ���� ����
                    txtStockOptions.Visible = true; // ��� �� ���� ����
                    break;
            }
            // ��� ���� ��� �������� ���� ��� ����� �����
            txtMonthlySalary.Clear();
            txtHourlyRate.Clear();
            txtHoursWorked.Clear();
            txtBonus.Clear();
            txtStockOptions.Clear(); 
        }

        // ���� ������� ������ ����� �-ComboBox
        private void cmbEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEmployeeSpecificFieldsVisibility();
        }

        // ���� ������� ������ "���� ����"
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation for common input fields
                if (!int.TryParse(txtEmployeeId.Text, out int id))
                {
                    MessageBox.Show("��� ��� ID ���� ����.", "����� ���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmployeeId.Focus();
                    return;
                }
                string firstName = txtFirstName.Text;
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    MessageBox.Show("��� ��� �� ����.", "����� ���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFirstName.Focus();
                    return;
                }
                string lastName = txtLastName.Text;
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    MessageBox.Show("��� ��� �� �����.", "����� ���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLastName.Focus();
                    return;
                }
                string department = txtDepartment.Text;
                if (string.IsNullOrWhiteSpace(department))
                {
                    MessageBox.Show("��� ��� �����.", "����� ���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDepartment.Focus();
                    return;
                }

                // Ensure ID is unique
                if (_employees.Any(emp => emp.Id == id))
                {
                    MessageBox.Show("���� �� ID �� ��� ����. ��� ����� �-ID ������.", "����� ���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmployeeId.Focus();
                    return;
                }

                Employee? newEmployee = null; // Use nullable type
                string selectedEmployeeType = cmbEmployeeType.SelectedItem?.ToString() ?? string.Empty;

                // Validation and creation of employee based on selected type and input
                switch (selectedEmployeeType)
                {
                    case "SalariedEmployee":
                        if (!double.TryParse(txtMonthlySalary.Text, out double monthlySalaryS) || monthlySalaryS <= 0)
                        {
                            MessageBox.Show("��� ��� ��� ����� ����.", "����� ���");
                            txtMonthlySalary.Focus();
                            return;
                        }
                        newEmployee = new SalariedEmployee(id, firstName, lastName, department, monthlySalaryS);
                        break;
                    case "HourlyEmployee":
                        if (!double.TryParse(txtHourlyRate.Text, out double hourlyRateH) || hourlyRateH <= 0)
                        {
                            MessageBox.Show("��� ��� ����� ���� ����.", "����� ���");
                            txtHourlyRate.Focus();
                            return;
                        }
                        if (!int.TryParse(txtHoursWorked.Text, out int hoursWorkedH) || hoursWorkedH < 0)
                        {
                            MessageBox.Show("��� ��� ���� ����� ������.", "����� ���");
                            txtHoursWorked.Focus();
                            return;
                        }
                        newEmployee = new HourlyEmployee(id, firstName, lastName, department, hourlyRateH, hoursWorkedH);
                        break;
                    case "Manager":
                        if (!double.TryParse(txtMonthlySalary.Text, out double monthlySalaryM) || monthlySalaryM <= 0)
                        {
                            MessageBox.Show("��� ��� ��� ����� ����.", "����� ���");
                            txtMonthlySalary.Focus();
                            return;
                        }
                        if (!double.TryParse(txtBonus.Text, out double bonusM) || bonusM < 0)
                        {
                            MessageBox.Show("��� ��� ����� ����.", "����� ���");
                            txtBonus.Focus();
                            return;
                        }
                        newEmployee = new Manager(id, firstName, lastName, department, monthlySalaryM, bonusM);
                        break;
                    case "Executive": // New case for Executive
                        if (!double.TryParse(txtMonthlySalary.Text, out double execMonthlySalary) || execMonthlySalary <= 0)
                        {
                            MessageBox.Show("��� ��� ��� ����� ���� ����� ����.", "����� ���", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!double.TryParse(txtBonus.Text, out double execBonus) || execBonus < 0)
                        {
                            MessageBox.Show("��� ��� ����� ���� ����� ����.", "����� ���", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!int.TryParse(txtStockOptions.Text, out int stockOptions) || stockOptions < 0)
                        {
                            MessageBox.Show("��� ��� ���� ������� ������ ����� ����� ����.", "����� ���", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        newEmployee = new Executive(id, firstName, lastName, department, execMonthlySalary, execBonus, stockOptions);
                        break;
                    default:
                        MessageBox.Show("��� ��� ��� ����.", "����� ���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbEmployeeType.Focus();
                        return;
                }

                if (newEmployee != null)
                {
                    _employees.Add(newEmployee);
                    MessageBox.Show("����� ���� ������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearEmployeeInputFields();
                    RefreshDataGridView(); // Update the display
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"����� ����� ���� �����: {ex.Message}", "�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ���� ������� ������ "��� �� �� �������"
        private void btnShowAllEmployees_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(); // ���� ���� �� ������
            if (_employees.Count == 0)
            {
                MessageBox.Show("��� ������ �����.", "��� ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ���� ������� ������ "��� ����"
        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtRemoveId.Text, out int idToRemove))
                {
                    MessageBox.Show("��� ��� ID ���� ���� �����.", "����� ���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRemoveId.Focus();
                    return;
                }

                Employee? toRemove = _employees.FirstOrDefault(emp => emp.Id == idToRemove);

                if (toRemove != null)
                {
                    _employees.Remove(toRemove);
                    MessageBox.Show($"����� �� ID {idToRemove} ���� ������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGridView(); // ���� �� ������
                    txtRemoveId.Clear();
                }
                else
                {
                    MessageBox.Show($"����� �� ID {idToRemove} �� ����.", "���� �� ����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"����� ����� ��� ���� �����: {ex.Message}", "�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ���� ������� ������ "����"
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        // ���� ������� ������ "���"
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        // =============================================================
        // �������� ����������/����������� ������
        // =============================================================

        private void SaveToFile()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    //IncludeFields = true // ���� ��� �� ���� �� ��������� �� Prop-��
                };

                // ���� �� ����� ������ ����� ��� ���� �������� �������
                options.Converters.Add(new EmployeeConverter()); // ���� �-EmployeeConverter ����

                string json = JsonSerializer.Serialize(_employees, options);
                File.WriteAllText(FilePath, json);
                MessageBox.Show($"����� ������� ����� �-'{FilePath}' ������.", "����� ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("���� ����� ����� �������: " + ex.Message, "����� �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFromFile()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    MessageBox.Show("���� ����� ������� �� ����. ����� �� ����� ����.", "����� ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _employees = new List<Employee>();
                    return;
                }

                string json = File.ReadAllText(FilePath);

                var options = new JsonSerializerOptions
                {
                    //IncludeFields = true // ���� ��� �� ���� �� ��������� �� Prop-��
                };

                options.Converters.Add(new EmployeeConverter()); // ���� �-EmployeeConverter ����

                var loaded = JsonSerializer.Deserialize<List<Employee>>(json, options);
                if (loaded != null)
                {
                    _employees = loaded;
                    MessageBox.Show("����� ������� ����� ������ ������.", "����� ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGridView(); // ���� ����� ���� �����
                }
                else
                {
                    MessageBox.Show("������� ������ ��� �����. ����� �� ����� ����.", "����� �����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _employees = new List<Employee>();
                }
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"����� ������ ����� ������ ������: {ex.Message}\n����� ���� ����� ����.", "����� �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _employees = new List<Employee>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("���� ����� ����� �������: " + ex.Message, "����� �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ���� ��� ������ ���� ���
        private void ClearEmployeeInputFields()
        {
            txtEmployeeId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtDepartment.Clear();
            // ��� �� �� ����� ���������, �� �� �� ��� �������
            txtMonthlySalary.Clear();
            txtHourlyRate.Clear();
            txtHoursWorked.Clear();
            txtBonus.Clear();
            cmbEmployeeType.SelectedIndex = 0; // ���� ������ �������
            txtEmployeeId.Focus();
        }

        // ���� ��� ������ �-DataGridView
        private void RefreshDataGridView()
        {
            dataGridViewEmployees.Rows.Clear(); // ��� ����� ������
            foreach (var emp in _employees)
            {
                // ���� ���� ���� �-DataGridView �� ����� �����
                // ���� ����� ������� �-DataGridView ���� ����� ������� ���� �����
                dataGridViewEmployees.Rows.Add(
                    emp.Id,
                    emp.FirstName,
                    emp.LastName,
                    emp.Department,
                    emp.GetType().Name, // ��� �����
                    emp.GetDetails(), // ���� ���� ��������
                    emp.CalculateSalary() // ����� ����� ��� ������ ����� (�� �����)
                );
            }
        }
    }
}