using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace SpaceApps.Controllers
{
    [Route("api/[controller]")]
    public class LaunchController : Controller
    {
        static Models.RawData.Launches Launches;

        static LaunchController()
        {
            Launches = doTheScrape().Result;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(Launches);
        }

        static async Task<Models.RawData.Launches> doTheScrape()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://launchlibrary.net/1.4/");
                    var response = await client.GetAsync($"launch/next/5");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    Models.RawData.Launches rawWeather = JsonConvert.DeserializeObject<Models.RawData.Launches>(stringResult);
                    return rawWeather;
                }
                catch (HttpRequestException httpRequestException)
                {
                    return new Models.RawData.Launches();
                }
            }
        }
    }
}