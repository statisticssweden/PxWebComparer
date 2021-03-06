﻿using Newtonsoft.Json;

namespace PxWebComparer.Model
{
   public class TableQuery
        {
            [JsonProperty("query")]
            public Query[] Query { get; set; }

            [JsonProperty("response")]
            public QueryResponse Response { get; set; }

            /// <summary>
            /// Default constructor
            /// </summary>
            //public TableQuery()
            //{   
            //}

            ///// <summary>
            ///// Constructor
            ///// Creates a TableQuery from the Paxiom model object
            ///// </summary>
            ///// <param name="model">Paxiom model</param>
            ///// <param name="selection">Limit the Paxiom model to the specified selection</param>
            //public TableQuery(PXModel model, Selection[] selections)
            //{
            //    List<Query> queryLst = new List<Query>();

            //    foreach (Variable var in model.Meta.Variables)
            //    {
            //        Selection sel = selections.SingleOrDefault(x => x.VariableCode == var.Code);
            //        Query query = new Query();

            //        query.Code = sel.VariableCode;

            //        // If all values are selected it can be skipped
            //        if ((var.Values.Count == sel.ValueCodes.Count) && (!var.Elimination) && var.CurrentGrouping == null && var.CurrentValueSet == null)
            //        {
            //            continue;
            //        }

            //        if (sel.ValueCodes.Count == 0 && var.CurrentGrouping == null && var.CurrentValueSet == null)
            //        {
            //            continue;
            //        }

            //        query.Selection = new QuerySelection();

            //        if (var.CurrentGrouping != null)
            //        {
            //            string aggType = QueryHelper.GetAggregationTypeFilterString(var.CurrentGrouping.GroupPres);

            //            //switch (var.CurrentGrouping.GroupPres)
            //            //{
            //            //    case GroupingIncludesType.AggregatedValues:
            //            //        aggType = "agg:";
            //            //        break;
            //            //    case GroupingIncludesType.SingleValues:
            //            //        aggType = "agg_single:";
            //            //        break;
            //            //    case GroupingIncludesType.All:
            //            //        aggType = "agg_all:";
            //            //        break;
            //            //    default:
            //            //        aggType = "agg:";
            //            //        break;
            //            //}

            //            if (var.CurrentGrouping.ID != null)
            //            {
            //                query.Selection.Filter = aggType + var.CurrentGrouping.ID;
            //            }
            //            else
            //            {
            //                query.Selection.Filter = aggType + var.CurrentGrouping.Name;
            //            }
            //        }
            //        else if (var.CurrentValueSet != null)
            //        {
            //            query.Selection.Filter = "vs:" + var.CurrentValueSet.ID;
            //        }
            //        else
            //        {
            //            query.Selection.Filter = "item";
            //        }

            //        query.Selection.Values = new string[sel.ValueCodes.Count];
            //        sel.ValueCodes.CopyTo(query.Selection.Values, 0);

            //        queryLst.Add(query);
            //    }

            //    this.Query = queryLst.ToArray();

            //    // PX-file is the default response format
            //    this.Response = new QueryResponse();
            //    this.Response.Format = "px";
            //}
           
        }


        //public class Query
        //{
        //    [JsonProperty("code")]
        //    public string Code { get; set; }

        //    /// <summary>
        //    /// Lägg till variabltyp i JSON formatet T(ime)/C(ontents)/G(eograpical)/N(ormal)
        //    /// </summary>
        //    [JsonProperty("variableType")]
        //    public string VariableType { get; set; }

        //    [JsonProperty("selection")]
        //    public QuerySelection Selection { get; set; }

           
        //}

       

       

    

}
