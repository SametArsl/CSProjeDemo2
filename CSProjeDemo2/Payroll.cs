using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Payroll
    {
        private List<Employee> employees;
        private List<Employee> lessWorkers;

        public Payroll(List<Employee> employees)
        {
            this.employees = employees;
            this.lessWorkers = new List<Employee>();
        }

        public void CreatePayroll()
        {
            foreach ( Employee employee in employees )
            {
                int workHours;
                string salaryInformation = "";

                Console.WriteLine($"Please enter the working hours of the staff named {employee.Name}");

                while(!int.TryParse(Console.ReadLine(), out workHours) || workHours < 0 || workHours > 270)
                {
                    Console.WriteLine("Invalid value! Please enter a positive integer value: ");
                }

                if (workHours < 150)
                {
                    lessWorkers.Add(employee);
                }

                if (employee.Title == "Officer")
                {
                    salaryInformation = JsonConvert.SerializeObject(new
                    {
                        EmployeeName = employee.Name,
                        WorkHours = workHours,
                        NetSalary = (employee as Officer).CalculateNetSalary(workHours),
                        OvertimeWage = (employee as Officer).CalculateOvertimeWage(workHours),
                        Salary = (employee as Officer).CalculateSalary(workHours)
                    });
                }

                if (employee.Title == "Manager")
                {
                    salaryInformation = JsonConvert.SerializeObject(new
                    {
                        EmployeeName = employee.Name,
                        WorkHours = workHours,
                        NetSalary = (employee as Manager).CalculateNetSalary(workHours),
                        OvertimeWage = (employee as Manager).CalculateOvertimeWage(workHours),
                        Salary = (employee as Manager).CalculateSalary(workHours)
                    });
                }

                string folderName = $"{employee.Name}";

                if (!Directory.Exists(folderName)) 
                {
                    Directory.CreateDirectory(folderName);
                }

                string fileName = $"{folderName}\\MaasBordro_{GetLastMonthAndYear()}";

                File.WriteAllText(fileName, salaryInformation);
            }
        }

        public string GetLastMonthAndYear()
        {
            DateTime lastMonth = DateTime.Now.AddMonths(-1);

            string lastMonthsYear = lastMonth.Year.ToString();
            string lastMonthsName = lastMonth.ToString("MMMM");

            return $"{lastMonthsYear}_{lastMonthsName}";
        }

        public void GetEmployeesWorksLessThen150Hours()
        {
            Console.WriteLine("Employees working less than 150 hours");

            foreach (Employee employee in lessWorkers)
            {
                Console.WriteLine($"{employee.Name}");
            }
        }
    }
}
