using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid_tracker.Data.Dto
{
    public class InfectedPoint
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("long")]
        public double Longitude { get; set; }
    }
}
