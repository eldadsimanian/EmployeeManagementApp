#nullable enable // Enable nullable reference types for this file

using System.Text.Json.Serialization; // עדיין צריך את ה-using עבור JsonConverterAttribute, גם אם לא משתמשים בו ישירות כאן.

namespace EmployeeManagementApp
{
    
    public class SalariedEmployee : Employee
    {
        public double MonthlySalary { get; set; }

        // Parameterized constructor - calls the base (Employee) constructor
        public SalariedEmployee(int id, string firstName, string lastName, string department, double monthlySalary)
            : base(id, firstName, lastName, department) // Pass common properties to base constructor
        {
            MonthlySalary = monthlySalary;
        }

        // Parameterless constructor for JSON deserialization
        // This is crucial when using System.Text.Json, as it needs a way to create an instance.
        public SalariedEmployee() : base() { } // Call the base parameterless constructor

        public override double CalculateSalary()
        {
            return MonthlySalary;
        }

        public override string GetDetails()
        {
            // Include base details and then add specific details
            return $"ID: {Id}, Name: {FirstName} {LastName}, Dept: {Department}, Type: Salaried, Monthly Salary: {MonthlySalary:C}";
        }
    }
}