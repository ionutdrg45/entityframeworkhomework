using EfHomework.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EfHomework.Controller
{
    public class AccountantController
    {
        private readonly AccountantContext _accountantContext = new AccountantContext(new DbContextOptions<AccountantContext>());
        public void GetSalary(int employeeId)
        {
            var employeeList = _accountantContext.Employees.ToList();

            var employeeFound = employeeList.Find(emp => emp.Id == employeeId);
            
            if(employeeFound != null)
            {
                double salary = 0;
                List<EmployeeTasks> employeeTasksList = _accountantContext.EmpoyeeTasks.Where(emptsk => emptsk.EmployeeId == employeeFound.Id).ToList();
                var tasksList = _accountantContext.Tasks.ToList();

                foreach(EmployeeTasks empTask in employeeTasksList)
                {
                    var task = tasksList.FirstOrDefault(tsk => tsk.Id == empTask.TaskId);

                    Debug.WriteLine(employeeFound.Name + " Total days " + (DateTime.Now - task.Date).TotalDays + " date " + task.Date);

                    if ((DateTime.Now - task.Date).TotalDays <= 7)
                    {
                        if (task.IsSpecial == true) salary += task.Price;
                        else
                        {
                            var totalHours = (task.EndTime - task.StartTime).TotalHours;
                            Debug.WriteLine(employeeFound.Name + " " + totalHours);
                            salary += Math.Abs(Convert.ToDouble(totalHours)) * task.Price;
                        }
                    }
                }

                Debug.WriteLine(employeeFound.Name + " salary is " + salary);
            }
            else
            {
                Debug.WriteLine("No emplyee found.");
            }
        }
    }
}
