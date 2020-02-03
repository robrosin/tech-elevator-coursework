namespace WorkerApp
{
    public class HourlyWorker : Worker
    {
        private decimal hourlyRate;

        public HourlyWorker(decimal hourlyRate)
        {
            this.hourlyRate = hourlyRate;
        }

        public override decimal CalculateWeeklyPay(int hoursWorked)
        {
            if (hoursWorked > BASELINE_WORK_WEEK_HOURS)
            {
               return BASELINE_WORK_WEEK_HOURS * hourlyRate + ((hoursWorked - BASELINE_WORK_WEEK_HOURS) * hourlyRate * 1.5M);
            }
            else
            {
                return this.hourlyRate * hoursWorked;
            }
        }

    }

}