using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PxWebComparer.Business;
using PxWebComparer.Model.Enums;

namespace PxWebComparer.Forms
{
    public partial class ResultForm : Form
    {
        private readonly CompareHandler _compareHandler;

        public ResultForm()
        {
            InitializeComponent();
            _compareHandler = new CompareHandler();
            LoadData();
        }

        //private void ResultForm_Enter(object sender, EventArgs e)
        //{


        //    var results = _compareHandler.GetResults();

        //    foreach (var result in results)
        //    {
        //        var lvi = new ListViewItem();
        //        lvi.Text = result.SavedQuery.ToString();
        //        lvi.SubItems.Add(result.csv.ToString());

        //    }

        //    //foreach (Book b in Program.ListBooks)
        //    //{
        //    //    ListViewItem lvi = new ListViewItem();
        //    //    lvi.Text = b.IdBook.ToString();
        //    //    lvi.SubItems.Add(b.Author);
        //    //    lvi.SubItems.Add(b.Title);
        //    //    lvi.SubItems.Add(b.Year.ToString());
        //    //    listViewBooks.Items.Add(lvi);
        //    //}


        //}

        private void LoadData()
        {


            var results = _compareHandler.GetResults();
            listViewResult.View = View.Details;
            _ = listViewResult.Columns.Add("SQ id", 400, HorizontalAlignment.Left);

            var outputFormats = Enum.GetValues(typeof(OutputFormat)).Cast<OutputFormat>();
            foreach (var output in outputFormats)
            {
                _ = listViewResult.Columns.Add(output.ToString(), (output.ToString().Length * 7) + 25,
                    HorizontalAlignment.Left);
            }

            foreach (var result in results)
            {
                var lvi = new ListViewItem();
                lvi.Text = result.SavedQuery.ToString();
                lvi.SubItems.Add(result.px.ToString());
                lvi.SubItems.Add(result.xlsx.ToString());
                lvi.SubItems.Add(result.xlsx_doublecolumn.ToString());
                lvi.SubItems.Add(result.csv.ToString());
                lvi.SubItems.Add(result.csv_tab.ToString());
                lvi.SubItems.Add(result.csv_tabhead.ToString());
                lvi.SubItems.Add(result.csv_comma.ToString());
                lvi.SubItems.Add(result.csv_commahead.ToString());
                lvi.SubItems.Add(result.csv_space.ToString());
                lvi.SubItems.Add(result.csv_spacehead.ToString());
                lvi.SubItems.Add(result.csv_semicolon.ToString());
                lvi.SubItems.Add(result.csv_semicolonhead.ToString());
                lvi.SubItems.Add(result.json_stat.ToString());
                lvi.SubItems.Add(result.html5_table.ToString());
                lvi.SubItems.Add(result.relational_table.ToString());
                lvi.SubItems.Add(result.json.ToString());

                //px
                //    ,xlsx
                //    ,xlsx_doublecolumn
                //    ,csv
                //    ,csv_tab
                //    ,csv_tabhead
                //    ,csv_comma
                //    ,csv_commahead
                //    ,csv_space
                //    ,csv_spacehead
                //    ,csv_semicolon
                //    ,csv_semicololhead
                //    ,json_stat
                //    ,html5_table
                //    ,relational_table
                //    ,json
                //lvi.SubItems.Add(result.csv_space.ToString());
                //lvi.SubItems.Add(result.csv_semicololhead.ToString());
                //lvi.SubItems.Add(result.csv_tab.ToString());
                listViewResult.Items.Add(lvi);
            }



        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPageSavedQueryResult.Focused)
            {
                LoadData();
            }
            if (tabPageSavedQueryMeta.Focused)
            {
                LoadData();
            }


        }
    }
}
