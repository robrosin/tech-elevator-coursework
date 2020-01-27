﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Employee
    {
        public int EmployeeId { get; }
        public string FirstName { get; }
        public string LastName { get; set; }
        public string FullName { get; } // Derived property that returns LastName, FirstName
        public string Department { get; set; }
        public double AnnualSalary { get; private set; }

        // Method

        public void RaiseSalary(double percent)
        {
            AnnualSalary += (AnnualSalary * (percent/100));
        }

        // Constructor

        public Employee(int employeeId, string firstName, string lastName, double salary)
        {

            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = salary;
            FullName = $"{ lastName}, { firstName}";
        }
    }
}