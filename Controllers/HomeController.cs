using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using assignment3_db.Models;

namespace assignment3_db.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string token)
        {
            ViewBag.token = token ?? "notset";
            return View();
        }
    }
}
