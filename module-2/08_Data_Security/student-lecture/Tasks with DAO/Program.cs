using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.DAL;
using Tasks.Models;

namespace Tasks
{
    class Program
    {
        static private ITaskDAO taskDAO;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Task List!\r\n");
            System.Threading.Thread.Sleep(500);

            // Read the config file
            Config config = new Config("appsettings.json");

            if (config.UseSql)
            {
                taskDAO = new TaskSqlDAO(config.ConnectionString);
            }
            else
            {
                taskDAO = new TaskFileDAO(config.FilePath);
            }

            while (true)
            {
                Console.Clear();

                // List all the tasks
                IList<Task> list = taskDAO.GetOpenTasks();
                ListTasks(list);

                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(A)dd a task");
                Console.WriteLine("(C)omplete a task");
                Console.WriteLine("(Q)uit");

                string input = Console.ReadLine().Trim().ToUpper();

                if (input.Length == 0)
                {
                    continue;
                }
                if (input.Substring(0, 1) == "Q")
                {
                    break;
                }
                int taskId;
                switch (input.Substring(0, 1))
                {
                    case "A":
                        // Prompt the user to add a task
                        Task task = GetTaskinfo();
                        taskDAO.AddTask(task);
                        break;

                    case "C":
                        taskId = GetTaskId(list);
                        if (taskId > 0)
                        {
                            task = taskDAO.GetById(taskId);
                            task.Completed = true;
                            taskDAO.Update(task);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Prompt the user for a valid task id, which is in the list
        /// </summary>
        /// <returns>The task id entered by the user</returns>
        private static int GetTaskId(IList<Task> taskList)
        {
            int taskId = 0;
            while (true)
            {
                // Prompt the user for a task# and complete it
                Console.Write("Task # (0 to quit): ");
                if (int.TryParse(Console.ReadLine().Trim(), out taskId))
                {
                    if (taskId == 0)
                    {
                        return 0;
                    }

                    if (taskList.Any(t => t.Id == taskId))
                    {
                        return taskId;
                    }
                }
            }
        }

        private static void ListTasks(IList<Task> list)
        {
            string[] headings = {"Number", "Task", "Due Date", "Completed" };
            Console.WriteLine($"{headings[0], 6} {headings[1],-30} {headings[2],-15} {headings[3],-10}");
            foreach (Task task in list)
            {
                Console.WriteLine($"{task.Id,6} {task.TaskName,-30} {task.DueDate,-15:d} {task.Completed,-10}");
            }
        }

        private static Task GetTaskinfo()
        {
            Console.WriteLine("\r\n*** Add a Task ***");
            Console.Write("\tTask name: ");
            string taskName = Console.ReadLine();

            DateTime dueDate = DateTime.MinValue;
            while (dueDate == DateTime.MinValue)
            {
                try
                {
                    Console.Write("\tDue Date: ");
                    dueDate = DateTime.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("No!");
                }
            }
            return new Task(0, taskName, dueDate);
        }
    }
}
