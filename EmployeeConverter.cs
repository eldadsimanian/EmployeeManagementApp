using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmployeeManagementApp 
{
    public class EmployeeConverter : JsonConverter<Employee>
    {
        public override Employee Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;

                // נבדוק אילו מאפיינים ייחודיים קיימים כדי לזהות את סוג העובד
                if (root.TryGetProperty("Bonus", out _) && root.TryGetProperty("MonthlySalary", out _))
                {
                    return JsonSerializer.Deserialize<Manager>(root.GetRawText(), options)!;
                }
                else if (root.TryGetProperty("MonthlySalary", out _))
                {
                    return JsonSerializer.Deserialize<SalariedEmployee>(root.GetRawText(), options)!;
                }
                else if (root.TryGetProperty("HourlyRate", out _) && root.TryGetProperty("HoursWorked", out _))
                {
                    return JsonSerializer.Deserialize<HourlyEmployee>(root.GetRawText(), options)!;
                }
                else
                {
                    throw new JsonException("Unknown employee type.");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, Employee value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}