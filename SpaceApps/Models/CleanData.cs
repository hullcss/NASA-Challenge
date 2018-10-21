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

    public class MainLaunch
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime net { get; set; }
        public DateTime WindowStart { get; set; }
        public DateTime WindowEnd { get; set; }
        public LaunchStatus LaunchStatus { get; set; }
        public int WsStamp { get; set; } //unix time
        public int WeStamp { get; set; } //unix time
        public int NetStamp { get; set; } //unix time
        public string InfoURL { get; set; }
        public string VidURL { get; set; }
        public string[] InfoURLS { get; set; }
        public string[] VidURLS { get; set; }
        public string HoldReason { get; set; }
        public string FailReason { get; set; }
        public string HashTag { get; set; }
        public Agency Agency { get; set; }
        public Location Location { get; set; }
        public Rocket Rocket { get; set; }
        public List<Mission> Missions { get; set; }

        public MainLaunch(SpaceApps.Models.RawData.Launch DirtyLaunch)
        {
            id = DirtyLaunch.id;
            name = DirtyLaunch.name;
            net = DateTime.Parse(DirtyLaunch.net.TrimEnd(new char[] { 'U', 'T', 'C' }));
            WeStamp = DirtyLaunch.westamp;
            WsStamp = DirtyLaunch.wsstamp;
            NetStamp = DirtyLaunch.netstamp;
            InfoURL = DirtyLaunch.infoURL;
            VidURL = DirtyLaunch.vidURL;
            InfoURLS = DirtyLaunch.infoURLs;
            VidURLS = DirtyLaunch.vidURLs;
            HoldReason = DirtyLaunch.holdreason;
            FailReason = DirtyLaunch.failreason;
            HashTag = DirtyLaunch.hashtag;
            Agency = new Agency(DirtyLaunch.lsp);
            Location = new Location(DirtyLaunch.location);
            Rocket = new Rocket(DirtyLaunch.rocket);
            Missions = new List<Mission>();

            if (DirtyLaunch.missions != null)
                foreach (var item in DirtyLaunch.missions)
                    Missions.Add(new Mission(item));
        }
    }

    public class Agency : URLObject
    {
        public string Abbreviation { get; set; }
        public int Type { get; set; }
        public string CountryCode { get; set; }

        public Agency(SpaceApps.Models.RawData.Agency DirtyAgency)
        {
            if (DirtyAgency != null)
            {
                Abbreviation = DirtyAgency.abbrev;
                Type = DirtyAgency.type;
                CountryCode = DirtyAgency.countyCode;
                id = DirtyAgency.id;
                name = DirtyAgency.name;
                InfoURL = DirtyAgency.infoURL;
                WikiURL = DirtyAgency.wikiURL;
                InfoURLs = (DirtyAgency?.infoURLs == null) ? new string[0] : DirtyAgency.infoURLs;
            }
        }
    }

    public class Mission : URLObject
    {
        public string Description { get; set; }
        public int Launch { get; set; }
        public int Type { get; set; }
        public string TypeName { get; set; }
        public List<Agency> Agencies { get; set; }
        public List<PayLoad> PayLoads { get; set; }
        public List<MissionEvent> MissionEvents { get; set; }

        public Mission(SpaceApps.Models.RawData.Mission DirtyMission)
        {
            Description = DirtyMission.description;
            Launch = DirtyMission.launch;
            Type = DirtyMission.type;
            TypeName = DirtyMission.typeName;

            Agencies = new List<Agency>();
            if (DirtyMission.agencies != null)
                foreach (var item in DirtyMission.agencies)
                    Agencies.Add(new Agency(item));

            PayLoads = new List<PayLoad>();
            if (DirtyMission.payloads != null)
                foreach (var item in DirtyMission.payloads)
                PayLoads.Add(new PayLoad(item));

            MissionEvents = new List<MissionEvent>();
            if (DirtyMission?.events != null)
                foreach (var item in DirtyMission.events)
                    MissionEvents.Add(new MissionEvent(item));
        }
    }

    public class MissionEvent : BaseObject
    {
        public int RelativeTime { get; set; }
        public int Type { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public int ParentID { get; set; }

        public MissionEvent(SpaceApps.Models.RawData.MissionEvent DirtyMissionEvent)
        {
            RelativeTime = DirtyMissionEvent.relativeTime;
            Type = DirtyMissionEvent.type;
            Duration = DirtyMissionEvent.duration;
            Description = DirtyMissionEvent.description;
            ParentID = DirtyMissionEvent.parentid;
            name = DirtyMissionEvent.name;
            id = DirtyMissionEvent.id;
        }
    }

    public class Rocket : URLObject
    {
        public string DefaultPads { get; set; }
        public RocketFamily Family { get; set; }
        public string ImageURL { get; set; }
        public int[] ImageSizes { get; set; }

        public Rocket(SpaceApps.Models.RawData.Rocket DirtyRocket)
        {
            DefaultPads = DirtyRocket.defualtpads;
            Family = new RocketFamily(DirtyRocket.family);
            ImageURL = DirtyRocket.imageURL;
            ImageSizes = DirtyRocket.imageSizes;
            name = DirtyRocket.name;
            id = DirtyRocket.id;
            InfoURL = DirtyRocket.infoURL;
            WikiURL = DirtyRocket.wikiURL;
            InfoURLs = DirtyRocket.infoURLs;
        }
    }

    public class RocketFamily : BaseObject
    {
        public List<Agency> agencies { get; set; }

        public RocketFamily(SpaceApps.Models.RawData.RocketFamily DirtyRocketfamily)
        {
            if (DirtyRocketfamily == null)
            {

            }
            else
            {
                name = DirtyRocketfamily.name;
                id = DirtyRocketfamily.id;
                for (int i = 0; i < DirtyRocketfamily.agencies.Length; i++)
                    agencies.Add(new Agency(DirtyRocketfamily.agencies[i]));
            }
        }
    }

    public class Location : URLObject
    {
        public string CountryCode { get; set; }
        public List<Pad> Pads { get; set; }

        public Location(SpaceApps.Models.RawData.Location DirtyLocation)
        {
            CountryCode = DirtyLocation.countrycode;

            Pads = new List<Pad>();
            foreach (var item in DirtyLocation.pads)
                Pads.Add(new CleanData.Pad(item));

            name = DirtyLocation.name;
            id = DirtyLocation.id;
            InfoURL = DirtyLocation.infoURL;
            WikiURL = DirtyLocation.wikiURL;
            InfoURLs = DirtyLocation.infoURLs;
        }
    }

    public enum PadType
    {
        Launch,
        Landing,
    };

    public class PayLoad : BaseObject
    {
        public string CountryCodes { get; set; }
        public string Description { get; set; }
        //public int type { get; set; }
        //public string Dimensions { get; set; }
        //public string Weight { get; set; }
        //public int Total { get; set; }
        //public string MissionID { get; set; }

        public PayLoad(SpaceApps.Models.RawData.Payload DirtyPayLoad)
        {
            CountryCodes = DirtyPayLoad.countyCodes;
            Description = DirtyPayLoad.description;
            name = DirtyPayLoad.name;
            id = DirtyPayLoad.id;
        }
    }

    public class Pad : URLObject
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string MapURL { get; set; }
        public string Retired { get; set; }
        public int LocationId { get; set; }
        public List<Agency> Agencies { get; set; }

        public Pad(Models.RawData.Pad dirtyPad) : base()
        {
            Latitude = double.Parse(dirtyPad.latitude.ToString());
            Longitude = double.Parse(dirtyPad.longitude.ToString());
            MapURL = dirtyPad.mapURL;
            Retired = dirtyPad.retired.ToString();
            LocationId = dirtyPad.locationid;

            Agencies = new List<Agency>();
            if (dirtyPad.agencies != null)
                foreach (var item in dirtyPad.agencies)
                    Agencies.Add(new Agency(item));
        }
    }

    public class BaseObject
    {
        public int id;
        public string name;
    }

    public class URLObject : BaseObject
    {
        public string WikiURL { get; set; }
        public string InfoURL { get; set; }
        public string[] InfoURLs { get; set; }
    }
}