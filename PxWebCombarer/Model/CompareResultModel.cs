using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Mime;
using System.Xml;
using Newtonsoft.Json;
using PxWebComparer.Model.Enums;

namespace PxWebComparer.Model
{
    public class CompareResultModel
    {
        
        public UniqueId SavedQuery { get; set; }
        //public string SavedQuery { get; set; }
        public bool px { get; set; }
        public bool xlsx { get; set; }
        public bool xlsx_doublecolumn { get; set; }
        public bool csv { get; set; }
        public bool csv_tab { get; set; }
        public bool csv_tabhead { get; set; }
        public bool csv_comma { get; set; }
        public bool csv_commahead { get; set; }
        public bool csv_space { get; set; }
        public bool csv_spacehead { get; set; }
        public bool csv_semicolon { get; set; }
        public bool csv_semicololhead { get; set; }
        public bool json_stat { get; set; }
        public bool relational_table { get; set; }
        public bool html5_table { get; set; }
        public bool json { get; set; }

        public void UpdateModel(Enum outputFormat, bool result)
        {
            switch (outputFormat)
            {
                case OutputFormat.csv:
                    csv = result;
                    break;
                case OutputFormat.px:
                    px = result;
                    break;
                case OutputFormat.xlsx:
                    xlsx = result;
                    break;
                case OutputFormat.xlsx_doublecolumn:
                    xlsx_doublecolumn = result;
                    break;
                case OutputFormat.csv_tab:
                    csv_tab = result;
                    break;
                case OutputFormat.csv_tabhead:
                    csv_tabhead = result;
                    break;
                case OutputFormat.csv_comma:
                    csv_comma = result;
                    break;
                case OutputFormat.csv_commahead:
                    csv_commahead = result;
                    break;
                case OutputFormat.csv_space:
                    csv_space = result;
                    break;
                case OutputFormat.csv_spacehead:
                    csv_spacehead = result;
                    break;
                case OutputFormat.csv_semicolon:
                    csv_semicolon = result;
                    break;
                case OutputFormat.csv_semicololhead:
                    csv_semicololhead = result;
                    break;
                case OutputFormat.json:
                    json = result;
                    break;
                case OutputFormat.json_stat:
                    json_stat = result;
                    break;
                case OutputFormat.html5_table:
                    html5_table = result;
                    break;
                case OutputFormat.relational_table:
                    relational_table = result;
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}",
                SavedQuery, px, xlsx, xlsx_doublecolumn, csv, csv_tab, csv_tabhead, csv_comma, csv_commahead, 
                csv_space,csv_spacehead, csv_semicolon, csv_semicololhead, json_stat, relational_table, html5_table, json );


        //public bool csv_tab { get; set; }
        //public bool csv_tabhead { get; set; }
        //public bool csv_comma { get; set; }
        //public bool csv_commahead { get; set; }
        //public bool csv_space { get; set; }
        //public bool csv_spacehead { get; set; }
        //public bool csv_semicolon { get; set; }
        //public bool csv_semicololhead { get; set; }
        //public bool json_stat { get; set; }
        //public bool relational_table { get; set; }
        //public bool html5_table { get; set; }
        //public bool json { get; set; }

    }

}
    
}                   
