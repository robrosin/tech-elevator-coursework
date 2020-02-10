using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tasks.Models
{
    public class TaskList
    {
        public string Path { get; set; }
        private List<Task> taskList { get; set; }
        public int Count
        {
            get
            {
                return this.taskList.Count;
            }
        }
        public Task[] List
        {
            get
            {
                return this.taskList.ToArray();
            }
        }

        public TaskList(string path)
        {
            this.Path = path;
        }

        public void Load()
        {
            // TODO: Load tasks from the file (in Path), parse and create Tasks, add them to the list
            this.taskList = new List<Task>();
            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] fields = line.Split("|");

                        Task task = new Task(fields[0], DateTime.Parse(fields[1]), bool.Parse(fields[2]));

                        taskList.Add(task);
                    }
                }
            }
            catch (Exception)
            { 
                // File is not there or is somehow corrupt, just swallow the exception and proceed with an empty task list
            }


        }

        public void Save()
        {
            // Open the file at Path, and write all the tasks there
            try
            {
                using (StreamWriter sw = new StreamWriter(Path, false))
                {
                    foreach (Task task in taskList)
                    {
                        string line = string.Join("|", task.TaskName, task.DueDate, task.Completed);
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving task list: {ex.Message}");
            }
        }

        public void AddTask(Task newTask)
        {
            this.taskList.Add(newTask);
            this.Save();
        }

        public void RemoveTask(Task taskToRemove)
        {
            if (this.taskList.Contains(taskToRemove))
            {
                this.taskList.Remove(taskToRemove);
                this.Save();
            }
        }

    }
}
