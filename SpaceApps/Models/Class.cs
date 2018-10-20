using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApps.Models.RawData
{
    public class Location : URLObject
    {
        public string countrycode { get; set; }
        public List<Pad> pads { get; set; }
    }

    public class Rocket : URLObject
    {
        public string defualtpads { get; set; } //comma delimited intergers
        public RocketFamily family { get; set; }
        public string imageURL { get; set; }
        public int[] imageSizes { get; set; }
    }

    public class RocketFamily : BaseObject
    {
        public Agency[] agencies { get; set; }
    }

    public class Agency : URLObject
    {
        public string abbrev { get; set; }
        public int type { get; set; }
        public string countyCode { get; set; }
        public int islsp { get; set; } //0 = no 1 = yes
    }

    public class Mission : URLObject
    {
        public string description { get; set; }
        public int launch { get; set; }
        public int type { get; set; }
        public string typeName { get; set; }
        public List<dynamic> agencies { get; set; }
        public dynamic[] events { get; set; }
        public List<dynamic> payloads { get; set; }
    }

    public class MissionEvent : BaseObject
    {
        public int relativeTime { get; set; } //time in seconds to/from T-0
        public int type { get; set; }
        public int duration { get; set; }
        public string description { get; set; }
        public int parentid { get; set; }
    }

    public class Payload : BaseObject
    {
        public string countyCodes { get; set; } //comma delimted
        public string description { get; set; }
        public int type { get; set; }
        public string dimensions { get; set; } //in meters
        public string weight { get; set; } //in kg
        public int total { get; set; }
        public string missionID { get; set; }
    }

    public class Pad : URLObject
    {
        public int padType { get; set; } //0 - launch 1 = landing
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string mapURL { get; set; }
        public int retired { get; set; }
        public int locationid { get; set; }
        public Agency[] agencies { get; set; }
    }

    public class lsp : Agency
    {

    }

    public class BaseObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string changed { get; set; }
    }

    public class URLObject : BaseObject
    {
        public string wikiURL { get; set; }
        public string infoURL { get; set; }
        public string[] infoURLs { get; set; }
    }
}