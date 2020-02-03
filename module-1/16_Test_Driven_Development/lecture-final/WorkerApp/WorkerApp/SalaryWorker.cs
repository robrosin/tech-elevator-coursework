namespace WorkerApp
{
    public class SalaryWorker : Worker
    {
        private decimal annualSalary;
        public SalaryWorker(decimal annualSalary)
        {
            this.annualSalary = annualSalary;
        }

        public override decimal CalculateWeeklyPay(int hoursWorked)
        {
            // Calculate based on annual salary
            return annualSalary / WEEKS_IN_YEAR;
        }
    }

}