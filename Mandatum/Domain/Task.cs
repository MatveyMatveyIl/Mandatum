using System;

namespace Domain
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public string Executors { get; set; }

        public void RefreshToValidTask()
        {
            CheckDatetime();
        }

        private void CheckDatetime()
        {
            var check = DateTime.Compare(Deadline, DateTime.Now);
            if (check < 0)
            {
                Deadline = DateTime.Now;
            }
        }
    }
}