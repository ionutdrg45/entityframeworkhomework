using EfHomework.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfHomework.Controller
{
    public class AccountantController
    {
        private readonly AccountantContext _accountantContext = new AccountantContext(new DbContextOptions<AccountantContext>());
        public List<string> GetSalary(DateTime date)
        {
            _accountantContext.Employees.Include(x => x.Tasks).ToList();
            _accountantContext.Tasks.Include(x => x.Employees).ToList();
            _accountantContext.Projects.Include(x => x.Tasks).ToList();

            List<string> finalResult = new List<string>();
            var employeeList = _accountantContext.Employees.ToList();
            var projectList = _accountantContext.Projects.ToList();

            foreach(Employee employee in employeeList)
            {
                double finalSalary = 0;
                foreach(Task task in employee.Tasks)
                {
                    double salary = 0;

                    if (task.Date >= date && task.Date <= date.AddDays(7))
                    {
                        Project project = projectList.FirstOrDefault(prj => prj.Id == task.ProjectId);

                        var totalHours = Math.Abs(Convert.ToDouble((task.EndTime - task.StartTime).TotalHours));

                        if (task.IsSpecial == true) salary += task.Price;
                        else salary += totalHours * task.Price;

                        finalResult.Add($"{employee.Name}, {project.Name}, {task.Name}, {(task.IsSpecial ? "fixed price" : totalHours + " hours")}, {salary}");
                        finalSalary += salary;
                    }
                }
                finalResult.Add($"{employee.Name} - Total week ({date} - {date.AddDays(7)}): {finalSalary}");
            }
            return finalResult;
        }
    }
}
