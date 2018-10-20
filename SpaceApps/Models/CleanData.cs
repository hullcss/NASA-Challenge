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

    public class HarrysClass
    {
        public int Id { get; set; }
        public int RocketFamilyName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LaunchPadName { get; set; }
        public string AgencyName { get; set; }
        public string MissionType { get; set; }
    }

    public class Mission
    {
        public int RelativeTime { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string WikiURL { get; set; }
        public string URLs { get; set; }
    }

    public class Launch
    {
        public LaunchStatus Status { get; set; }
        public string HoldReadon { get; set; }
        public string FailReason { get; set; }
        public string InfoURLs { get; set; }
        public string VideoURLs { get; set; }
    }

    public class Rocket
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string InfoURL { get; set; }
        public string WikiURL { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string wikiURL { get; set; }
        public string infoURL { get; set; }
    }

    public class PayLoad
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Descryption { get; set; }
        public string Weight { get; set; }
        public string Dimensions { get; set; }
        public int Total { get; set; }
        public string MissionsID { get; set; }
    }



}