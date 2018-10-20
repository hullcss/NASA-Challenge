using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApps.Controllers
{
    public static class LaunchController2
    {
        private readonly List<Models.RawData.Launch> Launches;

        static LaunchController2()
        {
            Launches = new List<Models.RawData.Launch>();
        }


    }
}