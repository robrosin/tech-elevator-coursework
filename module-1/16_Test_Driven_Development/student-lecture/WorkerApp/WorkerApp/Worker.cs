using System;

namespace WorkerApp
{
    public class Worker
    {
        protected const int BASELINE_WORK_WEEK_HOURS = 40;
        protected const int WEEKS_IN_YEAR = 52;
        private decimal hourlyRate;
        private string workerType;
        private decimal annualSalary;
        private string v;



        public decimal CalculateWeeklyPay(int hoursWorked)
        {
            decimal pay = 0;
            switch (workerType)
            {
                case "Salary":
                    // Calculate based on annual salary
                    pay = annualSalary / WEEKS_IN_YEAR;
                    break;
                case "Hourly":
                    if (hoursWorked > BASELINE_WORK_WEEK_HOURS)
                    {
                        pay = (BASELINE_WORK_WEEK_HOURS * hourlyRate) + ((hoursWorked - BASELINE_WORK_WEEK_HOURS) * hourlyRate * 1.5M);
                    }
                    else
                    {
                        pay = this.hourlyRate * hoursWorked;
                    }
                    break;
                case "Volunteer":
                    pay = 0.00M;
                    break;
            }
            return pay;
        }
    }
    public class HourlyWorker : Worker
    {
        public HourlyWorker(decimal hourlyRate)
        {
            this.hourlyRate = hourlyRate;
        }
    }
    public class SalaryWorker : Worker
    {
        public SalaryWorker(decimal annualSalary)
        {
            this.annualSalary = annualSalary;
        }
    }
    public class VolunteerWorker : Worker
    {
        public VolunteerWorker()
    }
}
