using System.Collections.Generic;

namespace FirstApp.Models
{
    public static class EmployeeTaskRepository
    {
        private static List<EmployeeTask> allEmployeeTasks = new List<EmployeeTask>();
        public static IEnumerable<EmployeeTask> AllEmployeeTasks
        {
            get { return allEmployeeTasks; }
        }
        public static void Create(EmployeeTask employeeTask)
        {
            allEmployeeTasks.Add(employeeTask);
        }

        public static void Delete(EmployeeTask EmployeeTask)
        {
            allEmployeeTasks.Remove(EmployeeTask);
        }
    }
}
