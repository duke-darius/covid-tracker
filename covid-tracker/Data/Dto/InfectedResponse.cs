using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid_tracker.Data.Dto
{
    public class InfectedResponse
    {
        [JsonProperty("center")]
        public InfectedPoint Center { get; set; }
        [JsonProperty("points")]
        public List<InfectedPoint> Points { get; set; }
    }
}
