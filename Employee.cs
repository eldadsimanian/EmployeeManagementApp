#nullable enable // Enable nullable reference types for this file

using System.Text.Json.Serialization; // Required for JsonConverter attribute

namespace EmployeeManagementApp
{
    // Make sure this is abstract
    [JsonConverter(typeof(EmployeeConverter))] // Ensures correct serialization/deserialization for derived types
    public abstract class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } // No default value here, as it's set in constructor
        public string LastName { get; set; }  // No default value here, as it's set in constructor
        public string Department { get; set; } // No default value here, as it's set in constructor

        // Parameterized constructor - all derived classes will call this
        public Employee(int id, string firstName, string lastName, string department)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Department = department;
        }

        // Parameterless constructor for JSON deserialization
        // This is often required by serializers to create an instance before populating properties.
        // It's 'protected' because Employee is abstract, so it cannot be instantiated directly.
        protected Employee()
        {
            // Initialize string properties to non-null defaults here if you don't set them in the constructor,
            // or if the deserializer doesn't guarantee they'll be set.
            // However, with nullable enabled, if you don't initialize here and they are non-nullable,
            // the compiler will warn you. Since we have a parameterized constructor
            // that sets them, this empty constructor mainly serves the serializer.
            FirstName = string.Empty;
            LastName = string.Empty;
            Department = string.Empty;
        }

        // Abstract methods must be implemented by derived classes
        public abstract double CalculateSalary();
        public abstract string GetDetails();
    }
}