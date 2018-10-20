using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApps.Models.CleanData
{
    public class Launch
    {
        public int Id  {get; set;}
        public int RocketFamilyName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set;}
        public string LaunchPadName {get; set;}
        public string AgencyName { get; set; }
        public string MissionType { get; set; }
    }
}