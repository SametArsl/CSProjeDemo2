namespace CSProjeDemo2
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public string Title { get; set; }

        public abstract decimal GetHourlyWage();

        public abstract decimal CalculateSalary(int workHours);
    }
}
