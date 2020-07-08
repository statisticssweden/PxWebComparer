using Newtonsoft.Json;
using PxWebComparer.Model;

public class Query
{
    [JsonProperty("code")]
    public string Code { get; set; }

    /// <summary>
    /// Lägg till variabltyp i JSON formatet T(ime)/C(ontents)/G(eograpical)/N(ormal)
    /// </summary>
    [JsonProperty("variableType")]
    public string VariableType { get; set; }

    [JsonProperty("selection")]
    public QuerySelection Selection { get; set; }

    public Query CreateCopy()
    {
        Query newObject;
        newObject = (Query)this.MemberwiseClone();

        newObject.Selection = this.Selection.CreateCopy();

        return newObject;
    }
}