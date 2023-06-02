using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas_Admin_Controllers
{
    
    [Area("Admin")]
    [Route("/admin-manage/[action]")]
    public class AdminManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}