using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // עבור שימוש ב-LINQ כמו .FirstOrDefault()
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // עבור פעולות קבצים
using System.Text.Json; // עבור סריאליזציית JSON
#nullable enable


namespace EmployeeManagementApp 
{
    public partial class Form1 : Form
    {
        private List<Employee> _employees = new List<Employee>(); // השם הפרטי הנכון ל-List
        private const string FilePath = "employees.json"; // נתיב קבוע לקובץ שמירה

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

            // טען נתונים בעת אתחול הטופס (אם הקובץ קיים)
            LoadFromFile();
            RefreshDataGridView(); // רענן את התצוגה לאחר טעינה
        }

        // שיטה לעדכון נראות השדות הספציפיים לעובד
        // (נקראת ב-Load וב-ComboBox SelectedIndexChanged)
        private void UpdateEmployeeSpecificFieldsVisibility()
        {
            // הסתר את כל השדות הספציפיים בהתחלה
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

            // הצג שדות בהתבסס על סוג העובד שנבחר
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
                    lblStockOptions.Visible = true; // הצג את השדה החדש
                    txtStockOptions.Visible = true; // הצג את השדה החדש
                    break;
            }
            // נקה שדות קלט ספציפיים כאשר סוג העובד משתנה
            txtMonthlySalary.Clear();
            txtHourlyRate.Clear();
            txtHoursWorked.Clear();
            txtBonus.Clear();
            txtStockOptions.Clear(); 
        }

        // מטפל אירועים לשינוי בחירת ה-ComboBox
        private void cmbEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEmployeeSpecificFieldsVisibility();
        }

        // מטפל אירועים לכפתור "הוסף עובד"
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation for common input fields
                if (!int.TryParse(txtEmployeeId.Text, out int id))
                {
                    MessageBox.Show("אנא הזן ID עובד חוקי.", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmployeeId.Focus();
                    return;
                }
                string firstName = txtFirstName.Text;
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    MessageBox.Show("אנא הזן שם פרטי.", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFirstName.Focus();
                    return;
                }
                string lastName = txtLastName.Text;
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    MessageBox.Show("אנא הזן שם משפחה.", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLastName.Focus();
                    return;
                }
                string department = txtDepartment.Text;
                if (string.IsNullOrWhiteSpace(department))
                {
                    MessageBox.Show("אנא הזן מחלקה.", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDepartment.Focus();
                    return;
                }

                // Ensure ID is unique
                if (_employees.Any(emp => emp.Id == id))
                {
                    MessageBox.Show("עובד עם ID זה כבר קיים. אנא השתמש ב-ID ייחודי.", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("אנא הזן שכר חודשי חוקי.", "שגיאת קלט");
                            txtMonthlySalary.Focus();
                            return;
                        }
                        newEmployee = new SalariedEmployee(id, firstName, lastName, department, monthlySalaryS);
                        break;
                    case "HourlyEmployee":
                        if (!double.TryParse(txtHourlyRate.Text, out double hourlyRateH) || hourlyRateH <= 0)
                        {
                            MessageBox.Show("אנא הזן תעריף שעתי חוקי.", "שגיאת קלט");
                            txtHourlyRate.Focus();
                            return;
                        }
                        if (!int.TryParse(txtHoursWorked.Text, out int hoursWorkedH) || hoursWorkedH < 0)
                        {
                            MessageBox.Show("אנא הזן שעות עבודה חוקיות.", "שגיאת קלט");
                            txtHoursWorked.Focus();
                            return;
                        }
                        newEmployee = new HourlyEmployee(id, firstName, lastName, department, hourlyRateH, hoursWorkedH);
                        break;
                    case "Manager":
                        if (!double.TryParse(txtMonthlySalary.Text, out double monthlySalaryM) || monthlySalaryM <= 0)
                        {
                            MessageBox.Show("אנא הזן שכר חודשי חוקי.", "שגיאת קלט");
                            txtMonthlySalary.Focus();
                            return;
                        }
                        if (!double.TryParse(txtBonus.Text, out double bonusM) || bonusM < 0)
                        {
                            MessageBox.Show("אנא הזן בונוס חוקי.", "שגיאת קלט");
                            txtBonus.Focus();
                            return;
                        }
                        newEmployee = new Manager(id, firstName, lastName, department, monthlySalaryM, bonusM);
                        break;
                    case "Executive": // New case for Executive
                        if (!double.TryParse(txtMonthlySalary.Text, out double execMonthlySalary) || execMonthlySalary <= 0)
                        {
                            MessageBox.Show("אנא הזן שכר חודשי חוקי למנהל בכיר.", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!double.TryParse(txtBonus.Text, out double execBonus) || execBonus < 0)
                        {
                            MessageBox.Show("אנא הזן בונוס חוקי למנהל בכיר.", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!int.TryParse(txtStockOptions.Text, out int stockOptions) || stockOptions < 0)
                        {
                            MessageBox.Show("אנא הזן כמות אופציות למניות חוקית למנהל בכיר.", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        newEmployee = new Executive(id, firstName, lastName, department, execMonthlySalary, execBonus, stockOptions);
                        break;
                    default:
                        MessageBox.Show("אנא בחר סוג עובד.", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbEmployeeType.Focus();
                        return;
                }

                if (newEmployee != null)
                {
                    _employees.Add(newEmployee);
                    MessageBox.Show("העובד נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearEmployeeInputFields();
                    RefreshDataGridView(); // Update the display
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"אירעה שגיאה בלתי צפויה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // מטפל אירועים לכפתור "הצג את כל העובדים"
        private void btnShowAllEmployees_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(); // פשוט רענן את התצוגה
            if (_employees.Count == 0)
            {
                MessageBox.Show("אין עובדים להצגה.", "הצג עובדים", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // מטפל אירועים לכפתור "הסר עובד"
        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtRemoveId.Text, out int idToRemove))
                {
                    MessageBox.Show("אנא הזן ID עובד חוקי להסרה.", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRemoveId.Focus();
                    return;
                }

                Employee? toRemove = _employees.FirstOrDefault(emp => emp.Id == idToRemove);

                if (toRemove != null)
                {
                    _employees.Remove(toRemove);
                    MessageBox.Show($"העובד עם ID {idToRemove} הוסר בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGridView(); // עדכן את התצוגה
                    txtRemoveId.Clear();
                }
                else
                {
                    MessageBox.Show($"העובד עם ID {idToRemove} לא נמצא.", "עובד לא נמצא", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"אירעה שגיאה בעת הסרת העובד: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // מטפל אירועים לכפתור "שמור"
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        // מטפל אירועים לכפתור "טען"
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        // =============================================================
        // פונקציות סריאליזציה/דסריאליזציה לקבצים
        // =============================================================

        private void SaveToFile()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    //IncludeFields = true // בדרך כלל לא צריך אם המאפיינים הם Prop-ים
                };

                // הוסף את הממיר המותאם אישית שלך עבור היררכיית העובדים
                options.Converters.Add(new EmployeeConverter()); // וודא ש-EmployeeConverter קיים

                string json = JsonSerializer.Serialize(_employees, options);
                File.WriteAllText(FilePath, json);
                MessageBox.Show($"נתוני העובדים נשמרו ל-'{FilePath}' בהצלחה.", "שמירה הושלמה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("נכשל שמירת נתוני העובדים: " + ex.Message, "שגיאת שמירה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFromFile()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    MessageBox.Show("קובץ נתוני העובדים לא נמצא. מתחיל עם רשימה ריקה.", "טעינת מידע", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _employees = new List<Employee>();
                    return;
                }

                string json = File.ReadAllText(FilePath);

                var options = new JsonSerializerOptions
                {
                    //IncludeFields = true // בדרך כלל לא צריך אם המאפיינים הם Prop-ים
                };

                options.Converters.Add(new EmployeeConverter()); // וודא ש-EmployeeConverter קיים

                var loaded = JsonSerializer.Deserialize<List<Employee>>(json, options);
                if (loaded != null)
                {
                    _employees = loaded;
                    MessageBox.Show("נתוני העובדים נטענו מהקובץ בהצלחה.", "טעינה הושלמה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGridView(); // רענן תצוגה לאחר טעינה
                }
                else
                {
                    MessageBox.Show("הנתונים שנטענו היו ריקים. מתחיל עם רשימה ריקה.", "אזהרת טעינה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _employees = new List<Employee>();
                }
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"שגיאה בניתוח נתוני עובדים מהקובץ: {ex.Message}\nהקובץ עלול להיות פגום.", "שגיאת טעינה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _employees = new List<Employee>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("נכשל טעינת נתוני העובדים: " + ex.Message, "שגיאת טעינה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // שיטת עזר לניקוי שדות קלט
        private void ClearEmployeeInputFields()
        {
            txtEmployeeId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtDepartment.Clear();
            // נקה את כל השדות הספציפיים, גם אם הם היו מוסתרים
            txtMonthlySalary.Clear();
            txtHourlyRate.Clear();
            txtHoursWorked.Clear();
            txtBonus.Clear();
            cmbEmployeeType.SelectedIndex = 0; // החזר לבחירה הראשונה
            txtEmployeeId.Focus();
        }

        // שיטת עזר לרענון ה-DataGridView
        private void RefreshDataGridView()
        {
            dataGridViewEmployees.Rows.Clear(); // נקה שורות קיימות
            foreach (var emp in _employees)
            {
                // הוסף שורה חדשה ל-DataGridView עם נתוני העובד
                // וודא שמספר העמודות ב-DataGridView תואם למספר הנתונים שאתה מוסיף
                dataGridViewEmployees.Rows.Add(
                    emp.Id,
                    emp.FirstName,
                    emp.LastName,
                    emp.Department,
                    emp.GetType().Name, // סוג העובד
                    emp.GetDetails(), // פרטי עובד ספציפיים
                    emp.CalculateSalary() // הוספת חישוב שכר לעמודה נוספת (אם קיימת)
                );
            }
        }
    }
}