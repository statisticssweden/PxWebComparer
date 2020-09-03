using Newtonsoft.Json;

namespace PxWebComparer.Model
{
    public class QueryResponse
    {
        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("params")]
        public QueryParam[] Params { get; set; }

        //public QueryParam GetParam(string key)
        //{
        //    if (Params != null)
        //        return Params.SingleOrDefault(p => p.Key.ToLower() == key);
        //    return null;
        //}

        //public string GetParamString(string key)
        //{
        //    QueryParam param = GetParam(key);
        //    if (param != null)
        //        return param.Value;
        //    return null;
        //}

        //public int? GetParamInt(string key)
        //{
        //    int iOut;
        //    if (int.TryParse(GetParamString(key), out iOut))
        //        return iOut;
        //    return null;
        //}
        //public QueryResponse CreateCopy()
        //{
        //    QueryResponse newObject;
        //    newObject = (QueryResponse)this.MemberwiseClone();

        //    if (this.Params != null)
        //    {
        //        newObject.Params = new QueryParam[this.Params.Length];

        //        for (int i = 0; i < this.Params.Length; i++)
        //        {
        //            if (this.Params[i] != null)
        //            {
        //                newObject.Params[i] = this.Params[i].CreateCopy();
        //            }
        //        }
        //    }
        //    return newObject;
        //}
    }

}
