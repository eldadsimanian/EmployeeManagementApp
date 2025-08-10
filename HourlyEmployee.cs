#nullable enable // Enable nullable reference types for this file

using System.Text.Json.Serialization; // Required for JsonConverter attribute

namespace EmployeeManagementApp
{
    //[JsonConverter(typeof(EmployeeConverter))] // Ensures correct serialization/deserialization
    public class HourlyEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        // Parameterized constructor - calls the base (Employee) constructor
        public HourlyEmployee(int id, string firstName, string lastName, string department, double hourlyRate, int hoursWorked)
            : base(id, firstName, lastName, department) // Pass common properties to base constructor
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        // Parameterless constructor for JSON deserialization
        public HourlyEmployee() : base() { } // Call the base parameterless constructor

        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }

        public override string GetDetails()
        {
            // Include base details and then add specific details
            return $"ID: {Id}, Name: {FirstName} {LastName}, Dept: {Department}, Type: Hourly, Hourly Rate: {HourlyRate:C}, Hours Worked: {HoursWorked}";
        }
    }
}