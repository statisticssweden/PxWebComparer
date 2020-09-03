using System;
using Newtonsoft.Json;

namespace PxWebComparer.Model
{
    public class QueryStats
    {
        [JsonProperty("creator", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Creator { get; set; }
        [JsonProperty("removeable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Removeable { get; set; }
        [JsonProperty("runs", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long RunCounter { get; set; }
        [JsonProperty("fails", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long FailCounter { get; set; }
        [JsonProperty("lastrunned", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime LastExecuted { get; set; }

        public QueryStats()
        {
            Removeable = true;
        }
    }
}
