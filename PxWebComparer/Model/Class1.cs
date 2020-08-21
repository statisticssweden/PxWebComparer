﻿using System;
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

    public class MetaVariable
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("values")]
        public string[] Values { get; set; }

        [JsonProperty("valueTexts")]
        public string[] ValueTexts { get; set; }

        [JsonProperty("elimination", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Elimination { get; set; }

        [JsonProperty("time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Time { get; set; }

        [JsonProperty("map", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Map { get; set; }

    }
}
