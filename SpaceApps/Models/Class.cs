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
        public string countrycode {get; set;}
        public string wikiURL {get; set;}
        public string infoURL {get; set;}
        public string[] infoURLs {get; set;}
        public string changed {get; set;}
    }

    //public class 
}
