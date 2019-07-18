using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartAC.Data;
using SmartAC.Models;

namespace SmartAC.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var x = _context.Users.ToList();
            List<ApplicationUser> appUsers = new List<ApplicationUser>();
            foreach(IdentityUser i in x)
            {
                ApplicationUser ApplicationUser = new ApplicationUser()
                {
                    UserName = i.UserName,
                    Email = i.Email,
                    LockoutEnabled = i.LockoutEnabled
                };
                appUsers.Add(ApplicationUser);
            }
           
            
           return View(appUsers);
        }
    }
}