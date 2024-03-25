using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            // .json dosyasından personel listesini oku
            List<Employee> employees = ReadFile.ReadEmployeeList("personeller.json");

            // Maaş bordrosunu oluştur
            Payroll payroll = new Payroll(employees);
            payroll.CreatePayroll();

            // 150 saatten az çalışan personellerin raporunu al
            payroll.GetEmployeesWorksLessThen150Hours();

            Console.ReadLine();
        }
    }
}
