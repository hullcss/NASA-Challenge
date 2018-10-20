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
            List<Models.CleanData.MainLaunch> datas = new List<Models.CleanData.MainLaunch>();
            foreach (var item in Launches.launches)
            {
                datas.Add(new Models.CleanData.MainLaunch(item));
            }
            return Ok(datas);
        }

        [Route("Grab")]
        public async Task<IActionResult> Grab(int id)
        {
            var searchedObject = Launches.launches.FirstOrDefault(x => x.id == id);
            if(searchedObject == new Models.RawData.Launch())
            {
                return NotFound("Id Not Found");
            }
            return Ok(searchedObject);
        }

        static async Task<Models.RawData.Launches> doTheScrape()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://launchlibrary.net/1.4/");
                    var response = await client.GetAsync($"launch/next/1");
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