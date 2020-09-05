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
            this.tabPageStart = new System.Windows.Forms.TabPage();
            this.buttonAPI = new System.Windows.Forms.Button();
            this.buttonResults = new System.Windows.Forms.Button();
            this.radioButtonDatabase = new System.Windows.Forms.RadioButton();
            this.radioButtonFile = new System.Windows.Forms.RadioButton();
            this.buttonCompareMeta = new System.Windows.Forms.Button();
            this.tabPageSavedQueryMeta = new System.Windows.Forms.TabPage();
            this.listViewQueryResult = new System.Windows.Forms.ListView();
            this.tabPageSavedQueryResult = new System.Windows.Forms.TabPage();
            this.tabPageApi = new System.Windows.Forms.TabPage();
            this.listViewApiResult = new System.Windows.Forms.ListView();
            this.tabControl.SuspendLayout();
            this.tabPageStart.SuspendLayout();
            this.tabPageSavedQueryMeta.SuspendLayout();
            this.tabPageSavedQueryResult.SuspendLayout();
            this.tabPageApi.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewResult
            // 
            this.listViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResult.HideSelection = false;
            this.listViewResult.Location = new System.Drawing.Point(3, 3);
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(1089, 492);
            this.listViewResult.TabIndex = 0;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageStart);
            this.tabControl.Controls.Add(this.tabPageSavedQueryMeta);
            this.tabControl.Controls.Add(this.tabPageSavedQueryResult);
            this.tabControl.Controls.Add(this.tabPageApi);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 2;
            this.tabControl.Size = new System.Drawing.Size(1103, 531);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageStart
            // 
            this.tabPageStart.Controls.Add(this.buttonAPI);
            this.tabPageStart.Controls.Add(this.buttonResults);
            this.tabPageStart.Controls.Add(this.radioButtonDatabase);
            this.tabPageStart.Controls.Add(this.radioButtonFile);
            this.tabPageStart.Controls.Add(this.buttonCompareMeta);
            this.tabPageStart.Location = new System.Drawing.Point(4, 29);
            this.tabPageStart.Name = "tabPageStart";
            this.tabPageStart.Size = new System.Drawing.Size(1095, 498);
            this.tabPageStart.TabIndex = 2;
            this.tabPageStart.Text = "Start";
            // 
            // buttonAPI
            // 
            this.buttonAPI.Location = new System.Drawing.Point(23, 292);
            this.buttonAPI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAPI.Name = "buttonAPI";
            this.buttonAPI.Size = new System.Drawing.Size(200, 31);
            this.buttonAPI.TabIndex = 4;
            this.buttonAPI.Text = "Compare APIs";
            this.buttonAPI.UseVisualStyleBackColor = true;
            this.buttonAPI.Click += new System.EventHandler(this.buttonAPI_Click);
            // 
            // buttonResults
            // 
            this.buttonResults.Location = new System.Drawing.Point(23, 188);
            this.buttonResults.Name = "buttonResults";
            this.buttonResults.Size = new System.Drawing.Size(200, 29);
            this.buttonResults.TabIndex = 3;
            this.buttonResults.Text = "Compare results";
            this.buttonResults.UseVisualStyleBackColor = true;
            this.buttonResults.Click += new System.EventHandler(this.buttonResults_Click);
            // 
            // radioButtonDatabase
            // 
            this.radioButtonDatabase.AutoSize = true;
            this.radioButtonDatabase.Location = new System.Drawing.Point(106, 28);
            this.radioButtonDatabase.Name = "radioButtonDatabase";
            this.radioButtonDatabase.Size = new System.Drawing.Size(93, 24);
            this.radioButtonDatabase.TabIndex = 2;
            this.radioButtonDatabase.TabStop = true;
            this.radioButtonDatabase.Text = "Database";
            this.radioButtonDatabase.UseVisualStyleBackColor = true;
            // 
            // radioButtonFile
            // 
            this.radioButtonFile.AutoSize = true;
            this.radioButtonFile.Location = new System.Drawing.Point(23, 28);
            this.radioButtonFile.Name = "radioButtonFile";
            this.radioButtonFile.Size = new System.Drawing.Size(53, 24);
            this.radioButtonFile.TabIndex = 1;
            this.radioButtonFile.TabStop = true;
            this.radioButtonFile.Text = "File";
            this.radioButtonFile.UseVisualStyleBackColor = true;
            // 
            // buttonCompareMeta
            // 
            this.buttonCompareMeta.Location = new System.Drawing.Point(23, 69);
            this.buttonCompareMeta.Name = "buttonCompareMeta";
            this.buttonCompareMeta.Size = new System.Drawing.Size(200, 29);
            this.buttonCompareMeta.TabIndex = 0;
            this.buttonCompareMeta.Text = "Compare SQ meta";
            this.buttonCompareMeta.UseVisualStyleBackColor = true;
            this.buttonCompareMeta.Click += new System.EventHandler(this.buttonCompareMeta_Click);
            // 
            // tabPageSavedQueryMeta
            // 
            this.tabPageSavedQueryMeta.Controls.Add(this.listViewQueryResult);
            this.tabPageSavedQueryMeta.Location = new System.Drawing.Point(4, 29);
            this.tabPageSavedQueryMeta.Name = "tabPageSavedQueryMeta";
            this.tabPageSavedQueryMeta.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSavedQueryMeta.Size = new System.Drawing.Size(1095, 498);
            this.tabPageSavedQueryMeta.TabIndex = 1;
            this.tabPageSavedQueryMeta.Text = "Saved query meta ";
            this.tabPageSavedQueryMeta.UseVisualStyleBackColor = true;
            // 
            // listViewQueryResult
            // 
            this.listViewQueryResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewQueryResult.HideSelection = false;
            this.listViewQueryResult.Location = new System.Drawing.Point(3, 3);
            this.listViewQueryResult.Name = "listViewQueryResult";
            this.listViewQueryResult.Size = new System.Drawing.Size(1089, 492);
            this.listViewQueryResult.TabIndex = 0;
            this.listViewQueryResult.UseCompatibleStateImageBehavior = false;
            // 
            // tabPageSavedQueryResult
            // 
            this.tabPageSavedQueryResult.Controls.Add(this.listViewResult);
            this.tabPageSavedQueryResult.Location = new System.Drawing.Point(4, 29);
            this.tabPageSavedQueryResult.Name = "tabPageSavedQueryResult";
            this.tabPageSavedQueryResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSavedQueryResult.Size = new System.Drawing.Size(1095, 498);
            this.tabPageSavedQueryResult.TabIndex = 0;
            this.tabPageSavedQueryResult.Text = "Saved query result";
            this.tabPageSavedQueryResult.UseVisualStyleBackColor = true;
            // 
            // tabPageApi
            // 
            this.tabPageApi.Controls.Add(this.listViewApiResult);
            this.tabPageApi.Location = new System.Drawing.Point(4, 29);
            this.tabPageApi.Name = "tabPageApi";
            this.tabPageApi.Size = new System.Drawing.Size(1095, 498);
            this.tabPageApi.TabIndex = 3;
            this.tabPageApi.Text = "Api result";
            // 
            // listViewApiResult
            // 
            this.listViewApiResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewApiResult.HideSelection = false;
            this.listViewApiResult.Location = new System.Drawing.Point(0, 0);
            this.listViewApiResult.Name = "listViewApiResult";
            this.listViewApiResult.Size = new System.Drawing.Size(1095, 498);
            this.listViewApiResult.TabIndex = 0;
            this.listViewApiResult.UseCompatibleStateImageBehavior = false;
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
            this.tabPageStart.ResumeLayout(false);
            this.tabPageStart.PerformLayout();
            this.tabPageSavedQueryMeta.ResumeLayout(false);
            this.tabPageSavedQueryResult.ResumeLayout(false);
            this.tabPageApi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSavedQueryResult;
        private System.Windows.Forms.TabPage tabPageSavedQueryMeta;
        private System.Windows.Forms.ListView listViewQueryResult;
        private System.Windows.Forms.TabPage tabPageStart;
        private System.Windows.Forms.Button buttonResults;
        private System.Windows.Forms.RadioButton radioButtonDatabase;
        private System.Windows.Forms.RadioButton radioButtonFile;
        private System.Windows.Forms.Button buttonCompareMeta;
        private System.Windows.Forms.Button buttonAPI;
        private System.Windows.Forms.TabPage tabPageApi;
        private System.Windows.Forms.ListView listViewApiResult;
    }
}