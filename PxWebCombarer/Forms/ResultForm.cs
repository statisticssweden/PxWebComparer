using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PxWebComparer.Business;

namespace PxWebComparer.Forms
{
    public partial class ResultForm : Form
    {
        private readonly CompareHandler _compareHandler;

        public ResultForm()
        {
            InitializeComponent();
            _compareHandler = new CompareHandler();
        }

        private void ResultForm_Enter(object sender, EventArgs e)
        {
             
            
          //  var results = _compareHandler.


             //foreach (Book b in Program.ListBooks)
             //{
             //    ListViewItem lvi = new ListViewItem();
             //    lvi.Text = b.IdBook.ToString();
             //    lvi.SubItems.Add(b.Author);
             //    lvi.SubItems.Add(b.Title);
             //    lvi.SubItems.Add(b.Year.ToString());
             //    listViewBooks.Items.Add(lvi);
             //}


        }
    }
}
