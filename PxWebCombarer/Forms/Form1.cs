using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using PxWebComparer.Business;
using PxWebComparer.Repo;

namespace PxWebComparer.Forms
{
    public partial class Form1 : Form
    {
        private readonly string compareResultFile;

        public Form1()
        {
            InitializeComponent();

            var helper = new AppSettingsHandler();
            
            compareResultFile = helper.ReadSetting("CompareResultFile");
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            var fileRepo = new FileCompareRepo();

            var result = fileRepo.ReadFromFile(compareResultFile);
            
            listBoxResult.DataSource = result;
        }

        //private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if ()
        //    {
                
        //    }
        //}
    }
}
