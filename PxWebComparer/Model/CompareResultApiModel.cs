using System;
using PxWebComparer.Model.Enums;

namespace PxWebComparer.Model
{
    public class CompareResultApiModel
    {
        public string TableId { get; set; }
        public bool? px { get; set; }
        public bool? xlsx { get; set; }
        public bool? csv { get; set; }
        public bool? json { get; set; }
        public bool? json_stat { get; set; }
        public bool? json_stat2 { get; set; }
        public bool? sdmx { get; set; }
        public void UpdateModel(Enum outputFormat, bool? result)
        {
            switch (outputFormat)
            {
                case OutputFormatApi.csv:
                    csv = result;
                    break;
                case OutputFormatApi.px:
                    px = result;
                    break;
                case OutputFormatApi.xlsx:
                    xlsx = result;
                    break;
                case OutputFormatApi.json:
                    json = result;
                    break;
                case OutputFormatApi.json_stat:
                    json_stat = result;
                    break;
                case OutputFormatApi.json_stat2:
                    json_stat2 = result;
                    break;
                case OutputFormatApi.sdmx:
                    sdmx = result;
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                TableId, px, xlsx, csv, json, json_stat, json_stat2, sdmx );
        }
    }
}