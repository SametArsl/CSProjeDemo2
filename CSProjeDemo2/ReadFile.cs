using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class ReadFile
    {
        public static List<Employee> ReadEmployeeList(string filePath)
        {
            string json = File.ReadAllText(filePath);

            List<Employee> employeeList = JsonConvert.DeserializeObject<List<Employee>>(json);

            return employeeList;
        }
    }
}
