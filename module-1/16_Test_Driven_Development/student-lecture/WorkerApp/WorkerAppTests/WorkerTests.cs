using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkerApp;

namespace WorkerAppTests
{
    /**********
     * Worker app requirements
     * 
     * 1. A workers weekly pay is calculated by multiplying the hourly rate by number of hours worked
     * 2. A worker can make overtime and is paid 1.5 time for hours worked > 40
     * 3. If a worker is on Salary, the weekly pay is calculated by dividing the annual pay by 52, regardless of hours worked
     * 4. A volunteer working is paid $0, regardless of hours worked
     * 
     **********/

    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        public void WorkerGetsPaidHoursTimesRate()
        {
            // Arrange
            Worker worker = new Worker(10.00M);

            // Act
            int hoursWorked = 40;
            decimal pay = worker.CalculateWeeklyPay(hoursWorked);

            //Assert
            Assert.AreEqual(400.00M, pay);

            // Add another assert that stretches our code
            Assert.AreEqual(200.00M, worker.CalculateWeeklyPay(20));

            // Add a couple more
            Assert.AreEqual(0.00M, worker.CalculateWeeklyPay(0));
        }

        // Write a test for overtime
        [TestMethod]
        public void WorkerGetsTimeAndAHalfForOvertime()
        {
            // Arrange
            Worker worker = new Worker(10.00M);

            // Act
            int hoursWorked = 50;
            decimal pay = worker.CalculateWeeklyPay(hoursWorked);

            //Assert
            Assert.AreEqual(550.00M, pay);

            // Check another example
            Assert.AreEqual(1300.00M, worker.CalculateWeeklyPay(100));
        }
        [TestMethod]
        public void SalaryWorkerGetsPaidBasedOnAnnualSalary()
        {
            // Arrange
            decimal annualSalary = 52000M;
            Worker worker = new Worker("Salary", annualSalary);

            // Act
            decimal pay = worker.CalculateWeeklyPay(40);

            // Assert
            Assert.AreEqual(1000M, pay);

            // Try again with a different salary
            worker = new Worker("Salary", 104000.00M);
            pay = worker.CalculateWeeklyPay(40);
            Assert.AreEqual(2000.00M, pay);

            // Try with different hours worked
            pay = worker.CalculateWeeklyPay(0);
            Assert.AreEqual(2000.00M, pay);

            // Try with different hours worked
            pay = worker.CalculateWeeklyPay(100);
            Assert.AreEqual(2000.00M, pay);
        }
        [TestMethod]
        public void VolunteerWorkerGetsDidley()
        {
            // Arrange
            Worker worker = new Worker("Volunteer");

            // Act
            decimal pay = worker.CalculateWeeklyPay(40);

            // Assert
            // Try with different hours worked
            pay = worker.CalculateWeeklyPay(0);
            Assert.AreEqual(0.00M, pay);

            // Try with different hours worked
            pay = worker.CalculateWeeklyPay(100);
            Assert.AreEqual(0.00M, pay);
        }
    }
}
