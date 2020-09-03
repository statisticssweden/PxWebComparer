using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PxWebComparer.Model
{
    public class SavedQuery
    {
        [JsonProperty("sources", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<TableSource> Sources { get; set; }
        [JsonProperty("workflow", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<WorkStep> Workflow { get; set; }
        [JsonProperty("output", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Output Output { get; set; }
        [JsonProperty("stats", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public QueryStats Stats { get; set; }
        [JsonProperty("safe", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Safe { get; set; }
        [JsonProperty("timeDependent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool TimeDependent { get; set; }
        public string LoadedQueryName { get; set; }

        public SavedQuery()
        {
            Sources = new List<TableSource>();
            Workflow = new List<WorkStep>();
            this.Output = new Output();
            Stats = new QueryStats();
            Safe = false;
            TimeDependent = false;
        }
    }



}
