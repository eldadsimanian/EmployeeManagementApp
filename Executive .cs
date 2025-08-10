using System;
using System.Text.Json.Serialization;
#nullable enable


namespace EmployeeManagementApp
{
    // Executive יורש מ-Manager
    //[JsonConverter(typeof(EmployeeConverter))] 
    public class Executive : Manager
    {
        // מאפיין חדש וספציפי למנהל בכיר
        public int StockOptions { get; set; }

        // קונסטרקטור שמעביר נתונים לקונסטרקטור של מחלקת האב (Manager)
        public Executive(int id, string firstName, string lastName, string department, double monthlySalary, double bonus, int stockOptions)
            : base(id, firstName, lastName, department, monthlySalary, bonus)
        {
            StockOptions = stockOptions;
        }

        // מימוש מחדש (override) של CalculateSalary אם חישוב השכר שונה
        public override double CalculateSalary()
        {
            // לדוגמה, נוסיף ערך קבוע עבור כל אופציה למניה
            double baseSalary = base.CalculateSalary(); // מקבל את חישוב השכר של Manager
            return baseSalary + (StockOptions * 100); // כל אופציה שווה 100 ש"ח נוספים
        }

        // מימוש מחדש (override) של GetDetails כדי לכלול את המאפיין החדש
        public override string GetDetails()
        {
            // נקבל את הפרטים מה-Manager ונוסיף עליהם
            return base.GetDetails() + $", Stock Options: {StockOptions}";
        }
    }
}