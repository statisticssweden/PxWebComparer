using System.Collections.Generic;
using Newtonsoft.Json;

namespace PxWebComparer.Model
{
    public class Output
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("params", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dictionary<string, string> Params { get; private set; }

        public Output()
        {
            Params = new Dictionary<string, string>();
        }
    }

}
