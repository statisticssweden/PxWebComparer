namespace PxWebComparer.Forms
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewResult = new System.Windows.Forms.ListView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSavedQueryResult = new System.Windows.Forms.TabPage();
            this.tabPageSavedQueryMeta = new System.Windows.Forms.TabPage();
            this.listViewQueryResult = new System.Windows.Forms.ListView();
            this.tabControl.SuspendLayout();
            this.tabPageSavedQueryResult.SuspendLayout();
            this.tabPageSavedQueryMeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewResult
            // 
            this.listViewResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewResult.HideSelection = false;
            this.listViewResult.Location = new System.Drawing.Point(3, 90);
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(1089, 405);
            this.listViewResult.TabIndex = 0;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSavedQueryResult);
            this.tabControl.Controls.Add(this.tabPageSavedQueryMeta);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 1;
            this.tabControl.Size = new System.Drawing.Size(1103, 531);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageSavedQueryResult
            // 
            this.tabPageSavedQueryResult.Controls.Add(this.listViewResult);
            this.tabPageSavedQueryResult.Location = new System.Drawing.Point(4, 29);
            this.tabPageSavedQueryResult.Name = "tabPageSavedQueryResult";
            this.tabPageSavedQueryResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSavedQueryResult.Size = new System.Drawing.Size(1095, 498);
            this.tabPageSavedQueryResult.TabIndex = 0;
            this.tabPageSavedQueryResult.Text = "tabPage1";
            this.tabPageSavedQueryResult.UseVisualStyleBackColor = true;
            // 
            // tabPageSavedQueryMeta
            // 
            this.tabPageSavedQueryMeta.Controls.Add(this.listViewQueryResult);
            this.tabPageSavedQueryMeta.Location = new System.Drawing.Point(4, 29);
            this.tabPageSavedQueryMeta.Name = "tabPageSavedQueryMeta";
            this.tabPageSavedQueryMeta.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSavedQueryMeta.Size = new System.Drawing.Size(1095, 498);
            this.tabPageSavedQueryMeta.TabIndex = 1;
            this.tabPageSavedQueryMeta.Text = "tabPage2";
            this.tabPageSavedQueryMeta.UseVisualStyleBackColor = true;
            // 
            // listViewQueryResult
            // 
            this.listViewQueryResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewQueryResult.HideSelection = false;
            this.listViewQueryResult.Location = new System.Drawing.Point(3, 61);
            this.listViewQueryResult.Name = "listViewQueryResult";
            this.listViewQueryResult.Size = new System.Drawing.Size(1089, 434);
            this.listViewQueryResult.TabIndex = 0;
            this.listViewQueryResult.UseCompatibleStateImageBehavior = false;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 531);
            this.Controls.Add(this.tabControl);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl.ResumeLayout(false);
            this.tabPageSavedQueryResult.ResumeLayout(false);
            this.tabPageSavedQueryMeta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSavedQueryResult;
        private System.Windows.Forms.TabPage tabPageSavedQueryMeta;
        private System.Windows.Forms.ListView listViewQueryResult;
    }
}