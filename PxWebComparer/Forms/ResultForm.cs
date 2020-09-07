using System;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using PxWebComparer.Business;
using PxWebComparer.Model.Enums;
using TextBox = System.Windows.Forms.TextBox;
using View = System.Windows.Forms.View;

namespace PxWebComparer.Forms
{
    public partial class ResultForm : Form
    {
        private readonly CompareHandler _compareHandler;

        public ResultForm()
        {
            InitializeComponent();
            _compareHandler = new CompareHandler();
            radioButtonFile.Checked = true;
            FillForms();
            tabControl.SelectedIndex = 0;
        }

        private void FillForms()
        {
            LoadData();
            LoadSavedQueryData();
            LoadApiData();
        }


        private void LoadData()
        {
            listViewResult.Clear();
            var results = _compareHandler.GetResults();

            if (results == null)
                return;

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
                lvi.SubItems.Add(result.json_stat2.ToString());
                lvi.SubItems.Add(result.html5_table.ToString());
                lvi.SubItems.Add(result.relational_table.ToString());
                lvi.SubItems.Add(result.json.ToString());
                
                listViewResult.Items.Add(lvi);
            }
        }
        
        private void LoadApiData()
        {
            listViewApiResult.Clear();
            var results = _compareHandler.GetApiResults();

            if (results == null)
                return;


            listViewApiResult.View = View.Details;
            _ = listViewApiResult.Columns.Add("SQ id", 400, HorizontalAlignment.Left);

            var outputFormats = Enum.GetValues(typeof(OutputFormatApi)).Cast<OutputFormatApi>();
            foreach (var output in outputFormats)
            {
                //_ = listViewApiResult.Columns.Add(output.ToString(), (output.ToString().Length * 7) + 25, HorizontalAlignment.Left);
                _ = listViewApiResult.Columns.Add(output.ToString(), 75, HorizontalAlignment.Left);
            }

            foreach (var result in results)
            {
                var lvi = new ListViewItem();
                lvi.Text = result.TableId;
                lvi.SubItems.Add(result.px.ToString());
                lvi.SubItems.Add(result.xlsx.ToString());
                lvi.SubItems.Add(result.csv.ToString());
                lvi.SubItems.Add(result.json.ToString());
                lvi.SubItems.Add(result.json_stat.ToString());
                lvi.SubItems.Add(result.json_stat2.ToString());
                lvi.SubItems.Add(result.sdmx.ToString());



                listViewApiResult.Items.Add(lvi);
            }
        }


        private void LoadSavedQueryData()
        {
            listViewQueryResult.Clear();
            
            var results = _compareHandler.GetSavedQueryResults();

            if (results == null)
                return;


            listViewQueryResult.View = View.Details;
            
            listViewQueryResult.View = View.Details;
            _ = listViewQueryResult.Columns.Add("Id", 400, HorizontalAlignment.Left);

            _ = listViewQueryResult.Columns.Add("Result", 200, HorizontalAlignment.Left);

            foreach (var result in results)
            {
                var lvi = new ListViewItem();
                lvi.Text = result.Id;
                lvi.SubItems.Add(result.Result.ToString());
                listViewQueryResult.Items.Add(lvi);
            }
        }

        private void buttonCompareMeta_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            if (radioButtonFile.Checked) 
                _compareHandler.CompareSavedQueryMetaPxsq();
            else
                _compareHandler.CompareSavedQueryMetaDatabase();
            
            LoadSavedQueryData();
            
            Cursor.Current = Cursors.Default;
        }

        private void buttonResults_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            _compareHandler.Compare();
            LoadData();
            
            Cursor.Current = Cursors.Default;

        }

        private void buttonAPI_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (string.IsNullOrEmpty(textBoxDatabase.Text) || string.IsNullOrEmpty(textBoxLanguage.Text))
            {
                MessageBox.Show("Language and database must be provided");
                return;
            }

            _compareHandler.CompareApi(textBoxLanguage.Text, textBoxDatabase.Text);
            LoadApiData();
            Cursor.Current = Cursors.Default;
        }
   }
}
