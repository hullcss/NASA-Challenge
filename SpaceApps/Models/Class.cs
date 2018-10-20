using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApps.Models.RawData
{
    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
        public string countrycode { get; set; }
        public string wikiURL { get; set; }
        public string infoURL { get; set; }
        public string[] infoURLs { get; set; }
        public string changed { get; set; }
    }

    public class Rocket
    {
        public int id { get; set; }
        public string name { get; set; }
        public string defualtpads { get; set; } //comma delimited intergers
        public RocketFamily family { get; set; }
        public string wikiURL { get; set; }
        public string infoURL { get; set; }
        public string changed { get; set; }
        public string[] infoURLs { get; set; }
        public string imageURL { get; set; }
        public int[] imageSizes { get; set; }
    }

    public class RocketFamily
    {
        public int id { get; set; }
        public string name { get; set; }
        public Agency[] agencies { get; set; }
        public string changed { get; set; }
    }

    public class Agency
    {
        public int id { get; set; }
        public string name { get; set; }
        public string abbrev { get; set; }
        public int type { get; set; }
        public string countyCode { get; set; }
        public string wikiURL { get; set; }
        public string[] infoURLs { get; set; }
        public int islsp { get; set; } //0 = yes 1 = no
        public string changed { get; set; }
    }

    public class Mission
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int launch { get; set; }
        public int type { get; set; }
        public string wikiURl { get; set; }
        public string infoURL { get; set; }
        public string changed { get; set; }
        public string[] infoURLs { get; set; }
        public Agency[] agancies { get; set; }
        public MissionEvent[] events { get; set; }
        public Payload[] payloads { get; set; }
    }

    public class MissionEvent
    {
        public int id { get; set; }
        public string name { get; set; }
        public int relativeTime { get; set; } //time in seconds to/from T-0
        public int type { get; set; }
        public int duration { get; set; }
        public string description { get; set; }
        public int parentid { get; set; }
        public string changed { get; set; }
    }

    public class Payload
    {
        public int id { get; set; }
        public string name { get; set; }
        public string countyCodes { get; set; } //comma delimted
        public string description { get; set; }
        public int type { get; set; }
        public string dimensions { get; set; } //in meters
        public string weight { get; set; } //in kg
        public int total { get; set; }
        public string missionID { get; set; }
        public string changed { get; set; }
    }
}
