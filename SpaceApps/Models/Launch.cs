using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApps.Models.RawData
{
    public class Launches
    {
        public List<Launch> launches { get; set; }
    }

    public class Launch
    {
        public int id { get; set; }
        public string name { get; set; }
        public string net { get; set; } //Month, dd, yyyy hh24:mi:ss UTC) 
        public int tbddate { get; set; }
        public int tbdtime { get; set; }
        public int status { get; set; } //todo change to enum  
        public int inhold { get; set; }
        public string windowstart { get; set; } //Month, dd, yyyy hh24:mi:ss UTC)
        public string windowend { get; set; } //Month, dd, yyyy hh24:mi:ss UTC
        public string isostart { get; set; }
        public string isoend { get; set; }
        public string isonet { get; set; }
        public int wsstamp { get; set; }
        public int westamp { get; set; }
        public int netstamp { get; set; }
        public string infoURL { get; set; }
        public string vidURL { get; set; }
        public string[] infoURLs { get; set; }
        public string[] vidURLs { get; set; }
        public string holdreason { get; set; }
        public string failreason { get; set; }
        public int probability { get; set; }
        public string hashtag { get; set; }
        public lsp lsp { get; set; }
        public string changed { get; set; }
        public Location location { get; set; }
        public Rocket rocket { get; set; }
        public List<Mission> missions { get; set; }
    }
}