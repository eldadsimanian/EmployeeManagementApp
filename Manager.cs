#nullable enable // Enable nullable reference types for this file

using System.Text.Json.Serialization; // Required for JsonConverter attribute

namespace EmployeeManagementApp
{
    //[JsonConverter(typeof(EmployeeConverter))] // Ensures correct serialization/deserialization
    public class Manager : Employee // Manager directly inherits from Employee
    {
        public double MonthlySalary { get; set; }
        public double Bonus { get; set; }

        // Parameterized constructor - calls the base (Employee) constructor
        public Manager(int id, string firstName, string lastName, string department, double monthlySalary, double bonus)
            : base(id, firstName, lastName, department) // Pass common properties to base constructor
        {
            MonthlySalary = monthlySalary;
            Bonus = bonus;
        }

        // Parameterless constructor for JSON deserialization
        public Manager() : base() { } // Call the base parameterless constructor

        public override double CalculateSalary()
        {
            return MonthlySalary + Bonus;
        }

        public override string GetDetails()
        {
            // Include base details and then add specific details
            return $"ID: {Id}, Name: {FirstName} {LastName}, Dept: {Department}, Type: Manager, Monthly Salary: {MonthlySalary:C}, Bonus: {Bonus:C}";
        }
    }
}