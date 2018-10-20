using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceApps.Models;
using System.ComponentModel.DataAnnotations;

namespace SpaceApps.Controllers
{
    public class CalendarController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new EventViewModel());
        }
    }
}