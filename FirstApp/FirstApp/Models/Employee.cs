using System;
using System.ComponentModel.DataAnnotations;

namespace FirstApp.Models
{
    public class Employee
    {
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please enter your first name (letters or space only)")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please enter your last name (letters or space only)")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime HiredDate { get; set; }

        public String TaskName { get; set; }
        public EmployeeTask EmployeeTask { get; set; }
    }
}
