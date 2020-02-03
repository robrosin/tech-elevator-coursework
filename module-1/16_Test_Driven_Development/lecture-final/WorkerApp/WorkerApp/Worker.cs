using System;

namespace WorkerApp
{
    abstract public class Worker
    {
        protected const int BASELINE_WORK_WEEK_HOURS = 40;
        protected const int WEEKS_IN_YEAR = 52;

        abstract public decimal CalculateWeeklyPay(int hoursWorked);
    }
}