using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PxWebComparer.Model
{
    public class MetaTable
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("variables")]
        public MetaVariable[] Variables { get; set; }
    }

   
}
