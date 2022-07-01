using EfHomework.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EfHomework.Pages
{
    public class IndexModel : PageModel
    { 
        private static readonly AccountantController _accountantController = new AccountantController();
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public List<string> ResultStrings { get; set; } = new List<string>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            InitVars();
        }

        public void OnPost()
        {
            InitVars();
            var datePicked = Request.Form["weekDate"];
            ResultStrings = _accountantController.GetSalary(DateTime.Parse(datePicked));
        }

        public void InitVars()
        {
            ViewData["MaxFormDate"] = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
