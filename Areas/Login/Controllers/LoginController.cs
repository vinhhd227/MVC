using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas_Login_Controllers;
[Area("Login")]
[Route("/login/[action]")]
public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
