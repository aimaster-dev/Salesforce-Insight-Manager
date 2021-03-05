namespace SalesforceWindowsForms
{
	partial class FMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.bLogin = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.listQuery = new System.Windows.Forms.ListBox();
            this.Indications = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.privateParams = new System.Windows.Forms.TextBox();
            this.publicParams = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FolderShare = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bLogin
            // 
            this.bLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLogin.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bLogin.Location = new System.Drawing.Point(30, 96);
            this.bLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(84, 37);
            this.bLogin.TabIndex = 0;
            this.bLogin.Text = "Go";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(14, 374);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(860, 173);
            this.dgv.TabIndex = 1;
            // 
            // listQuery
            // 
            this.listQuery.Font = new System.Drawing.Font("Microsoft YaHei", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listQuery.FormattingEnabled = true;
            this.listQuery.ItemHeight = 22;
            this.listQuery.Items.AddRange(new object[] {
            "1a - Inactive Employees (Retired, withdrawn)",
            "1b - Inactive Employees (but not Retired, Withdrawn)",
            " 2 - Inactive MMS users - last login is >180 days",
            " 3 - Active MMS Users - Reports not run in more than 180 days",
            " 4 - Public Reports not run in more than 90 Days",
            " 5 - Public and private Dashboard"});
            this.listQuery.Location = new System.Drawing.Point(146, 131);
            this.listQuery.Name = "listQuery";
            this.listQuery.Size = new System.Drawing.Size(701, 70);
            this.listQuery.TabIndex = 2;
            // 
            // Indications
            // 
            this.Indications.AutoSize = true;
            this.Indications.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Indications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Indications.Location = new System.Drawing.Point(151, 104);
            this.Indications.Name = "Indications";
            this.Indications.Size = new System.Drawing.Size(584, 20);
            this.Indications.TabIndex = 3;
            this.Indications.Text = "Please choose one of the item below and lick \"GO\", \"Export\" or \"Delete\"";
            // 
            // Export
            // 
            this.Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Export.Location = new System.Drawing.Point(30, 158);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(84, 43);
            this.Export.TabIndex = 4;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Location = new System.Drawing.Point(30, 220);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(84, 40);
            this.Delete.TabIndex = 5;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Please choose the number of days to track old Reports";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Private Reports";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(483, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Public Reports";
            // 
            // privateParams
            // 
            this.privateParams.Location = new System.Drawing.Point(155, 269);
            this.privateParams.Name = "privateParams";
            this.privateParams.Size = new System.Drawing.Size(100, 26);
            this.privateParams.TabIndex = 11;
            // 
            // publicParams
            // 
            this.publicParams.Location = new System.Drawing.Point(488, 269);
            this.publicParams.Name = "publicParams";
            this.publicParams.Size = new System.Drawing.Size(100, 26);
            this.publicParams.TabIndex = 12;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(146, 344);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RightToLeftLayout = true;
            this.progressBar1.Size = new System.Drawing.Size(322, 23);
            this.progressBar1.TabIndex = 13;
            this.progressBar1.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(150, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 29);
            this.label4.TabIndex = 14;
            this.label4.Text = "Progress Bar";
            this.label4.Click += new System.EventHandler(this.barra);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SalesforceWindowsForms.Properties.Resources.MMS;
            this.pictureBox1.Location = new System.Drawing.Point(30, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(817, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // FolderShare
            // 
            this.FolderShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.FolderShare, "This button will bring the PG and Users sharing in each Folder.");
            this.FolderShare.Location = new System.Drawing.Point(30, 281);
            this.FolderShare.Name = "FolderShare";
            this.helpProvider1.SetShowHelp(this.FolderShare, true);
            this.FolderShare.Size = new System.Drawing.Size(96, 86);
            this.FolderShare.TabIndex = 16;
            this.FolderShare.Text = "Folder Share";
            this.FolderShare.UseVisualStyleBackColor = true;
            this.FolderShare.Click += new System.EventHandler(this.FolderShare_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button1.Location = new System.Drawing.Point(715, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 68);
            this.button1.TabIndex = 17;
            this.button1.Text = "Upload ID´s to Ignore";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(678, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "File Uploaded: No";
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FolderShare);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.publicParams);
            this.Controls.Add(this.privateParams);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.Indications);
            this.Controls.Add(this.listQuery);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.bLogin);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FMain";
            this.Text = "Reporting Tool";
            this.TransparencyKey = System.Drawing.Color.MediumBlue;
            this.Load += new System.EventHandler(this.FMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bLogin;
		private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ListBox listQuery;
        private System.Windows.Forms.Label Indications;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox privateParams;
        private System.Windows.Forms.TextBox publicParams;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button FolderShare;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}

