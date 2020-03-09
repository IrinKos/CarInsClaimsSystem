using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInsClaims.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarInsClaims.App.Controllers
{
    public class ErrorHandlerController : Controller
    {
        public IActionResult Index(ErrorViewModel vm)
        {
            return View(vm);
        }

        [Route("{*url}", Order = 999)]
        public IActionResult CatchAll()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}