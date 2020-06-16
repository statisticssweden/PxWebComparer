namespace PxWebComparer.Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFiles = new System.Windows.Forms.TabPage();
            this.tabPageDatabase = new System.Windows.Forms.TabPage();
            this.tabPageResultat = new System.Windows.Forms.TabPage();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.tabPageFiles.SuspendLayout();
            this.tabPageResultat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageFiles);
            this.tabControl1.Controls.Add(this.tabPageDatabase);
            this.tabControl1.Controls.Add(this.tabPageResultat);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 107);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 2;
            this.tabControl1.Size = new System.Drawing.Size(800, 343);
            this.tabControl1.TabIndex = 0;
         //   this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Enter += new System.EventHandler(this.tabControl1_Enter);
            // 
            // tabPageFiles
            // 
            this.tabPageFiles.Controls.Add(this.checkedListBox1);
            this.tabPageFiles.Location = new System.Drawing.Point(4, 29);
            this.tabPageFiles.Name = "tabPageFiles";
            this.tabPageFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFiles.Size = new System.Drawing.Size(792, 310);
            this.tabPageFiles.TabIndex = 0;
            this.tabPageFiles.Text = "Från fil";
            this.tabPageFiles.UseVisualStyleBackColor = true;
            // 
            // tabPageDatabase
            // 
            this.tabPageDatabase.Location = new System.Drawing.Point(4, 29);
            this.tabPageDatabase.Name = "tabPageDatabase";
            this.tabPageDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDatabase.Size = new System.Drawing.Size(792, 310);
            this.tabPageDatabase.TabIndex = 1;
            this.tabPageDatabase.Text = "Från databas";
            this.tabPageDatabase.UseVisualStyleBackColor = true;
            // 
            // tabPageResultat
            // 
            this.tabPageResultat.Controls.Add(this.listBoxResult);
            this.tabPageResultat.Location = new System.Drawing.Point(4, 29);
            this.tabPageResultat.Name = "tabPageResultat";
            this.tabPageResultat.Size = new System.Drawing.Size(792, 310);
            this.tabPageResultat.TabIndex = 2;
            this.tabPageResultat.Text = "Resultat";
            // 
            // listBoxResult
            // 
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.ItemHeight = 20;
            this.listBoxResult.Location = new System.Drawing.Point(36, 30);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.Size = new System.Drawing.Size(638, 244);
            this.listBoxResult.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(29, 24);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(420, 268);
            this.checkedListBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPageFiles.ResumeLayout(false);
            this.tabPageResultat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFiles;
        private System.Windows.Forms.TabPage tabPageDatabase;
        private System.Windows.Forms.TabPage tabPageResultat;
        private System.Windows.Forms.ListBox listBoxResult;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }

}

