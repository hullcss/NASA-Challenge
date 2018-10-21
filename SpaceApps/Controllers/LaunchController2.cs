using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace SpaceApps.Controllers
{
    [Route("[controller]")]
    public class LaunchController : Controller
    {
        static Models.RawData.Launches Launches;
        static List<Models.CleanData.MainLaunch> CleanDataLaunches = new List<Models.CleanData.MainLaunch>();

        static LaunchController()
        {
            Launches = doTheScrape().Result;
            foreach (var item in Launches.launches)
            {
                CleanDataLaunches.Add(new Models.CleanData.MainLaunch(item));
            }

        }

        [Route("GetEvents")]
        public async Task<IActionResult> GetEvents(DateTime start, DateTime end)
        {
            var x = CleanDataLaunches.Where(y => y.net > start);
            var a = x.Where(b => b.net < end);


            List<Models.EventViewModel> events = new List<Models.EventViewModel>();
            foreach (var item in a)
            {
                //"2018-10-021T20:00:10"
                events.Add(new Models.EventViewModel
                {   
                    id = item.id,
                    title = item.name,
                    start = item.WindowStart.ToString("O"),
                    end = item.WindowEnd.ToString("O"),
                    allDay = false
                });
            }

            return Ok(events);
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
            var searchedObject = CleanDataLaunches.FirstOrDefault(x => x.id == id);
            if (searchedObject == new Models.CleanData.MainLaunch(new Models.RawData.Launch()))
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
                    var response = await client.GetAsync($"launch/next/3000");
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