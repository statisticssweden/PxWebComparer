using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.EMMA;
using PxWebComparer.Model;

namespace PxWebComparerTest
{
    public class TestFactory
    {
        public TableQuery GetTableQuery()
        {
            TableQuery tableQuery = new TableQuery();

            var queryList = new Query[]
            {
                new Query()
                {
                    Code = "Redskap",
                    Selection = new QuerySelection()
                    {
                        Filter = "item",
                        Values = new string[] {"23", "21", "22" }
                    }
                },
                new Query()
                {
                    Code = "Omrade2",
                    Selection = new QuerySelection()
                    {
                        Filter = "item",
                        Values = new string[] {"12", "10", "11"}
                    },
                },
                new Query()
                {
                    Code = "Fiskefongst",
                    Selection = new QuerySelection()
                    {
                        Filter = "item",
                        Values = new string[] {"20",
                            "10",
                            "15",
                            "9",
                            "16",
                            "5",
                            "14",
                            "13",
                            "11",
                            "1",
                            "2",
                            "3",
                            "8",
                            "7",
                            "6",
                            "4",
                            "12",
                            "17"}
                    },
                },
                new Query()
                {
                    Code = "ContentsCode",
                    Selection = new QuerySelection()
                    {
                        Filter = "item",
                        Values = new string[] {"000003QE",
                                                "000003QF"}
                    },
                },
                new Query()
                {
                    Code = "Tid",
                    Selection = new QuerySelection()
                    {
                        Filter = "item",
                        Values = new string[] { 
                            "2013",
                            "2014",
                            "2015",
                            "2016",
                            "2017",
                            "2018",
                            "2019"

                        }
                    },
                },
            };
            tableQuery.Query = queryList;

            QueryResponse response = new QueryResponse();

            response.Format = "px";

            tableQuery.Response = response;

            return tableQuery;

        }

        public MetaTable GetMetaTable()
        {
            MetaTable metaTable = new MetaTable();
            
            metaTable.Title = "Fritidsfiskets fångster efter redskap, område, fångst, tabellinnehåll och år";

            var variableList = new MetaVariable[]
            {
                new MetaVariable()
                {
                    Code = "Redskap",
                    Text = "redskap",
                    Values = new string[]
                    {
                        "23",
                        "21",
                        "22"
                    },
                    ValueTexts = new string[]
                    {
                        "Alla redskap",
                        "Handredskap",
                        "Passiva redskap"
                    }
                },
                new MetaVariable()
                {
                    Code = "Omrade2",
                    Text = "omrade",
                    Values = new string[]
                    {
                        "12",
                        "10",
                        "11"
                    },
                    ValueTexts = new string[]
                    {
                        "Totalt (i och kring Sverige)",
                        "Inlandsfiske",
                        "Havs- och kustfiske"
                    }
                },
                new MetaVariable()
                {
                    Code = "Fiskefongst",
                    Text = "fångst",
                    Values = new string[]
                    {
                        "20",
                        "10",
                        "15",
                        "9",
                        "16",
                        "5",
                        "14",
                        "13",
                        "11",
                        "1",
                        "2",
                        "3",
                        "8",
                        "7",
                        "6",
                        "4",
                        "12",
                        "17"
                    },
                    ValueTexts = new string[]
                    {
                        "Samtliga fisksorter",
                        "Makrill",
                        "Torsk",
                        "Lax",
                        "Öring",
                        "Havsöring",
                        "Sill/Strömming",
                        "Sik",
                        "Plattfisk",
                        "Abborre",
                        "Gädda",
                        "Gös",
                        "Kräfta",
                        "Krabba",
                        "Hummer",
                        "Harr",
                        "Röding",
                        "Övriga arter"
                    }
                },
                new MetaVariable()
                {
                    Code = "ContentsCode",
                    Text = "tabellinnehåll",
                    Values = new string[]
                    {
                        "000003QE",
                        "000003QF"
                    },
                    ValueTexts = new string[]
                    {
                        "Antal ton",
                        "Felmarginal, antal ton"
                    }
                },
                new MetaVariable()
                {
                    Code = "Tid",
                    Text = "år",
                    Values = new string[]
                    {
                        "2013",
                        "2014",
                        "2015",
                        "2016",
                        "2017",
                        "2018",
                        "2019"
                    },
                    ValueTexts = new string[]
                    {
                        "2013",
                        "2014",
                        "2015",
                        "2016",
                        "2017",
                        "2018",
                        "2019"
                    },
                    Time = true
                }
            };

            metaTable.Variables = variableList;

           return metaTable;

        }

        public List<MenuItem> GetMenuItemList()
        {
            var menuItems = new List<MenuItem>
            {
                new MenuItem()
                {
                    Text = "Första",
                    Id = "1",
                    Type = "Content"
                },
                new MenuItem()
                {
                    Text = "Andra",
                    Id = "2",
                    Type = "Content"
                },
                new MenuItem()
                {
                    Text = "Tredje",
                    Id = "3",
                    Type = "Content"
                },
                new MenuItem()
                {
                    Text = "Fjärde",
                    Id = "4",
                    Type = "Content"
                },
                new MenuItem()
                {
                    Text = "Femte",
                    Id = "5",
                    Type = "Content"
                },
            };
            return menuItems;
        }

        public List<MenuItem> GetMenuItemListOne()
        {
            var menuItems = new List<MenuItem>
            {
                new MenuItem()
                {
                    Text = "Första",
                    Id = "1",
                    Type = "Content"
                }
            };
            return menuItems;
        }

    }
}
