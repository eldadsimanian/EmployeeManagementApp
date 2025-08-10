using System;
using System.Windows.Forms;

namespace EmployeeManagementApp // This MUST match your project's namespace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] // Required for Windows Forms applications
        static void Main()
        {
            Application.EnableVisualStyles(); // Enables visual styles for controls
            Application.SetCompatibleTextRenderingDefault(false); // Sets default text rendering compatibility
            Application.Run(new Form1()); // Runs the main form (Form1) of the application
        }
    }
}