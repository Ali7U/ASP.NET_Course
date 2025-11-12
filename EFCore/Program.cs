// See https://aka.ms/new-console-template for more information

using EFCore.ClinicModels;
using EFCore.HrModels;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var clinicDB = new ClinicContext();

// var AddPatient = new Patient
// {
//     FullName = "Mohammed",
//     NationalId = "1234567890",
//     Email = "m@gmail.com",
//     DateOfBirth = new DateOnly(1990, 1, 1),
//     PhoneNumber = "1234567890"
// };
//
// clinicDB.Patients.Add(AddPatient);
// clinicDB.SaveChanges();

// var updatePatient = clinicDB.Patients.FirstOrDefault(x => x.PatientId == 1);
// updatePatient.FullName = "Saad";
// clinicDB.SaveChanges();
//
// clinicDB.Patients
//     .Where(p => p.FullName == "Saad")
//     .ExecuteUpdate(p => p.SetProperty(p => p.Email, "DD@gmail.com"));

// var patients = clinicDB.Patients.Where(p => p.DateOfBirth >= new DateOnly(1990, 1, 1));
// foreach (var p in patients)
// {
//     p.DateOfBirth = new DateOnly(2010, 01, 01);
// }
//
// clinicDB.SaveChanges();
//
// var deletePatient = clinicDB.Patients.Find(1);
// clinicDB.Patients.Remove(deletePatient);
// clinicDB.SaveChanges();

var hrDB = new HrContext();

 // Select all employee in department 30
 
 // var employees = hrDB.Employees
 //     .Select(e => e.DepartmentId == 30)
 //     .ToList();

// Select all employees of Seattle city and show their department name 

 var emps = hrDB.Employees
     .Where(e => e.Department.Location.City == "Seattle")
     .Select(e => new
     {
         e.Department.DepartmentName,
         e.FirstName,
         e.LastName,
         e.HireDate,
         e.Salary,
         e.Department.Location.City
     }).ToList();

// Select number of employees hired in each year

 var empsHiredByYear = hrDB.Employees
     .GroupBy(h => h.HireDate.Year)
     .Select(e => new
     {
       Year = e.Key,
       NumOfEmployees = e.Count()
       
     })
     .ToList();

Console.WriteLine();