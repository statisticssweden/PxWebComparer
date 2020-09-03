using Newtonsoft.Json;
using System;

namespace PxWebComparer.Model
{
    public class QuerySelection
    {
        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("values")]
        public string[] Values { get; set; }

    }
}