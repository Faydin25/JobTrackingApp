using Microsoft.AspNetCore.Mvc;
using MyApplication.Web.Data;
using MyApplication.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Web.Controllers
{
    public class MainPageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly List<User> users;

        public MainPageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var _AgeGroups = GroupsAge(users);
            var _UserCount = _context.Users.Count();
            var _TasksAndCount = GetCountTasks(users);

            //var _UserData = _context.Users.ToList();
            //var _TaskData = _context.Tasks.ToList();

            //ViewData["UserData"] = _UserData;
            //ViewData["TaskData"] = _TaskData;

            ViewData["AgeGroups"] = _AgeGroups;
            ViewData["UserCount"] = _UserCount;
            ViewData["TasksAndCount"] = _TasksAndCount;
            return View();
        }

        public int CalculateAge(DateTime? dateOfBirth)
        {
            if (!dateOfBirth.HasValue)
            {
                return 0;
            }
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Value.Year;

            if (dateOfBirth.Value.Date > today.AddYears(-age)) age--;
            return age;
        }

        private Dictionary<int, int> GroupsAge(List <User> users)
        {
            var ageGruops = new Dictionary<int, int>();
            foreach (var user in users)
            {
                var age = CalculateAge(user.DateOfBirth);
                if (ageGruops.ContainsKey(age)) ageGruops[age]++;
                else
                    ageGruops[age] = 1;
            }
            return ageGruops;
        }

        private Dictionary<string, int> GetCountTasks(List<User> users)
        {
            var countTasks = new Dictionary<string, int>
            {
                { "ToDo", 0 },
                { "InProgress", 0 },
                { "Done", 0 }
            };

            foreach (var user in users)
            {
                foreach (var task in user.Tasks)
                {
                    switch (task.Status)
                    {
                        case Models.TaskStatus.ToDo:
                            countTasks["ToDo"]++;
                            break;
                        case Models.TaskStatus.InProgress:
                            countTasks["InProgress"]++;
                            break;
                        case Models.TaskStatus.Done:
                            countTasks["Done"]++;
                            break;
                    }
                }
            }

            return countTasks;
        }
    }
}
