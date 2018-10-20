using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApps.Models.CleanData
{
    public enum LaunchStatus
    {
        StatusNotFound,
        Green,
        Red,
        Success,
        Fail,
    };
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

    public class MainData
    {
        public string CountryCode { get; set; }
        public string MissionDescription { get; set; }
        public LaunchStatus Status { get; set; }
        public string HoldReadon { get; set; }
        public string FailReason { get; set; }
    }
}