# Employee Management App 🧑‍💼💻

## 📌 Overview
The **Employee Management App** is a Windows Forms application built in **C# (.NET 8)** that allows organizations to manage their employees efficiently.  
It supports **different employee types** (Salaried, Hourly, Manager, Executive), saves employee data in **JSON format**, and provides a **user-friendly interface** for adding, editing, and viewing employees.

---

## ✨ Features
- 👥 **Employee Types** — Manage Salaried, Hourly, Manager, and Executive employees.
- 💾 **Data Persistence** — Save and load employee records from a local `employees.json` file.
- 🖥 **Windows Forms UI** — Intuitive interface for easy employee management.
- 🔄 **Custom JSON Converter** — Serialize and deserialize employee objects using `EmployeeConverter.cs`.
- 📊 **Dynamic Calculations** — Handle different salary calculation methods based on employee type.

---

## 🛠 Project Structure
EmployeeManagementApp/
│── Employee.cs              # Base class for all employees

│── SalariedEmployee.cs      # Employee with fixed salary

│── HourlyEmployee.cs        # Employee paid by the hour

│── Manager.cs               # Manager with bonuses

│── Executive .cs            # Executive-level employee logic

│── EmployeeConverter.cs     # JSON serialization/deserialization logic

│── Form1.cs                 # Main UI logic

│── Program.cs               # App entry point

│── employees.json           # Stored employee data

│── EmployeeManagementApp.sln # Solution file


## 🚀 How to Run

### 1️⃣ Clone the Repository
git clone https://github.com/YourUsername/EmployeeManagementApp.git

### 2️⃣ Open in Visual Studio
Double-click `EmployeeManagementApp.sln`

### 3️⃣ Build the Project
Press `Ctrl + Shift + B`

### 4️⃣ Run the App
Press `F5` or click **Start**

🎉 Enjoy Managing Employees!


## 📚 Requirements
- Windows OS 🪟  
- .NET 8 SDK installed  
- Visual Studio 2022 (or newer) with **Windows Forms** workload  

---

## 🌟 Highlights for Recruiters
- **Object-Oriented Design** — Demonstrates inheritance, abstraction, and polymorphism.  
- **Custom JSON Converter** — Real-world example of advanced serialization.  
- **Windows Forms UI Development** — User-friendly desktop app.  
- **Clean and Readable Code** — Follows C# coding best practices.  



