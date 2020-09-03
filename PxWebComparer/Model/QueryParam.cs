using Newtonsoft.Json;

namespace PxWebComparer.Model
{
    public class QueryParam
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        public QueryParam CreateCopy()
        {
            QueryParam newObject;
            newObject = (QueryParam)this.MemberwiseClone();

            return newObject;
        }
    }
}
