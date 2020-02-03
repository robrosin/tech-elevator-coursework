using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkerApp;

namespace WorkerAppTests
{
    /************************************************
     * Worker app requirements
     * 
     * 1. A worker's weekly pay is calculated by multiplying the hourly rate by number of hours worked
     * 2. A worker can make overtime, and is paid 1.5 time for hours worked > 40/week.
     * 3. If a worker is on Salary, the weekly pay is calculated by dividing the annual pay by 52, regardless of hours worked.
     * 4. A volunteer worker is paid 0, regardless of number of hours worked.
     * 
     ************************************************/
    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        public void HourlyWorkerGetsPaidHoursTimesRate()
        {
            // Arrange
            Worker worker = new HourlyWorker(10.00M);

            // Act
            int hoursWorked = 40;
            decimal pay = worker.CalculateWeeklyPay(hoursWorked);

            // Assert
            Assert.AreEqual(400.00M, pay);

            // Add another assert that stretches our code

            Assert.AreEqual(200.00m, worker.CalculateWeeklyPay(20));

            // Let's write a couple more tests to make sure...
            Assert.AreEqual(0.00m, worker.CalculateWeeklyPay(0));

        }

        // Write a test for overtime
        [TestMethod]
        public void HourlyWorkerGetsTimeAndAHalfForOvertime()
        {
            // Arrange
            Worker worker = new HourlyWorker(10.00M);

            // Act
            int hoursWorked = 50;
            decimal pay = worker.CalculateWeeklyPay(hoursWorked);

            // Assert
            Assert.AreEqual(550.00M, pay);

            // Check another example
            Assert.AreEqual(1300.00m, worker.CalculateWeeklyPay(100)); // 40 * 10 + 60 * 15 = 400 + 900 = 1300
        }

        [TestMethod]
        public void SalaryWorkerGetsPaidBasedOnAnnualSalary()
        {
            // Arrange
            decimal annualSalary = 52000M;
            Worker worker = new SalaryWorker(annualSalary);

            // Act
            decimal pay = worker.CalculateWeeklyPay(40);

            // Assert
            Assert.AreEqual(1000m, pay);

            // Try again with a different salary
            worker = new SalaryWorker(104000m);
            pay = worker.CalculateWeeklyPay(40);
            Assert.AreEqual(2000m, pay);

            // Try with different hours worked
            pay = worker.CalculateWeeklyPay(0);
            Assert.AreEqual(2000m, pay);

            // Try with different hours worked
            pay = worker.CalculateWeeklyPay(100);
            Assert.AreEqual(2000m, pay);
        }

        [TestMethod]
        public void VolunteerWorkerGetsDidley()
        {
            // Arrange
            Worker worker = new VolunteerWorker();

            // Act
            decimal pay = worker.CalculateWeeklyPay(40);

            // Assert
            Assert.AreEqual(0m, pay);

            // Try with different hours worked
            pay = worker.CalculateWeeklyPay(0);
            Assert.AreEqual(0m, pay);

            // Try with different hours worked
            pay = worker.CalculateWeeklyPay(100);
            Assert.AreEqual(0m, pay);

        }
    }
}
