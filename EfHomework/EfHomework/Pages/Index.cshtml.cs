using EfHomework.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfHomework.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly AccountantController _accountantController = new AccountantController();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["EmployeeSalary"] = _accountantController.GetSalary(34);
        }
    }
}
