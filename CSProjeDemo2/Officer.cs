using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Officer : Employee
    {
        private decimal hourlyWage;

        // Personelin saat ücretini kullanıcıdan alma
        public override decimal GetHourlyWage()
        {
            Console.WriteLine($"Please enter hourly wage of the manager named {Name}");

            while (!decimal.TryParse(Console.ReadLine(), out hourlyWage) || hourlyWage < 500)
            {
                Console.WriteLine("Invalid value! Hourly wage can not be less than 500 TRY. Please enter again:");
            }

            return hourlyWage;
        }

        // Net maaş hesaplama
        public decimal CalculateNetSalary(int workHours)
        {
            decimal hourlyWage = GetHourlyWage();
            decimal netSalary = workHours <= 180 ? hourlyWage * workHours : hourlyWage * 180;
            return netSalary;
        }

        // Ekstra mesai ücreti hesaplama
        public decimal CalculateOvertimeWage(int workHours)
        {
            decimal hourlyWage = GetHourlyWage();
            decimal overtimeWage = workHours > 180 ? (workHours - 180) * hourlyWage * 1.5m : 0;
            return overtimeWage;
        }

        // Ekstra mesai ücreti dahil maaş hesaplama
        public override decimal CalculateSalary(int workHours)
        {
            decimal netSalary = CalculateNetSalary(workHours);
            decimal overtimeWage = CalculateOvertimeWage(workHours);
            decimal salary = netSalary + overtimeWage;

            return salary;
        }
    }
}
