using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceApps.Models;
using SpaceApps.Models.CleanData;
using Newtonsoft.Json;

namespace SpaceApps.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }

        public async Task<IActionResult> Launch(int launchId)
        {
            MainLaunch launchModel;
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress =new Uri("https://localhost:5001");
                var result = await client.GetAsync($"launch/grab/?id={launchId}");
                var resultString = await result.Content.ReadAsStringAsync();
                launchModel = JsonConvert.DeserializeObject<MainLaunch>(resultString);
            }
            return View(launchModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
