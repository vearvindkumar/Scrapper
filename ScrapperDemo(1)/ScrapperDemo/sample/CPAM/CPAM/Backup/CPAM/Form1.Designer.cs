namespace CPAM
{
	partial class Form1
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.buttonSort = new System.Windows.Forms.Button();
			this.checkboxSortDescending = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.labelAvgRating = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.labelAvgPopularity = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.labelArticleCount = new System.Windows.Forms.Label();
			this.checkNewInfo = new System.Windows.Forms.CheckBox();
			this.checkShowIcons = new System.Windows.Forms.CheckBox();
			this.checkAutoRefresh = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textboxUserID = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.labelArticlesDisplayed = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoSize = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.webBrowser1);
			this.panel1.Location = new System.Drawing.Point(12, 159);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1197, 511);
			this.panel1.TabIndex = 20;
			// 
			// webBrowser1
			// 
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.Location = new System.Drawing.Point(0, 0);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(1193, 507);
			this.webBrowser1.TabIndex = 19;
			this.webBrowser1.WebBrowserShortcutsEnabled = false;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Bookmarked",
            "Changed",
            "Last Updated",
            "Page Views",
            "Popularity",
            "Rating",
            "Title",
            "Votes"});
			this.comboBox1.Location = new System.Drawing.Point(26, 23);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(183, 23);
			this.comboBox1.TabIndex = 0;
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Location = new System.Drawing.Point(222, 88);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(190, 23);
			this.buttonRefresh.TabIndex = 8;
			this.buttonRefresh.Text = "Refresh From CodeProject";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
			// 
			// buttonSort
			// 
			this.buttonSort.Location = new System.Drawing.Point(221, 23);
			this.buttonSort.Name = "buttonSort";
			this.buttonSort.Size = new System.Drawing.Size(75, 23);
			this.buttonSort.TabIndex = 1;
			this.buttonSort.Text = "Sort";
			this.buttonSort.UseVisualStyleBackColor = true;
			this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
			// 
			// checkboxSortDescending
			// 
			this.checkboxSortDescending.AutoSize = true;
			this.checkboxSortDescending.Location = new System.Drawing.Point(26, 52);
			this.checkboxSortDescending.Name = "checkboxSortDescending";
			this.checkboxSortDescending.Size = new System.Drawing.Size(103, 17);
			this.checkboxSortDescending.TabIndex = 2;
			this.checkboxSortDescending.Text = "Sort descending";
			this.checkboxSortDescending.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(640, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 16);
			this.label1.TabIndex = 14;
			this.label1.Text = "Average Rating:";
			// 
			// labelAvgRating
			// 
			this.labelAvgRating.AutoSize = true;
			this.labelAvgRating.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAvgRating.Location = new System.Drawing.Point(779, 25);
			this.labelAvgRating.Name = "labelAvgRating";
			this.labelAvgRating.Size = new System.Drawing.Size(15, 16);
			this.labelAvgRating.TabIndex = 15;
			this.labelAvgRating.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(640, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(134, 16);
			this.label3.TabIndex = 16;
			this.label3.Text = "Average Popularity:";
			// 
			// labelAvgPopularity
			// 
			this.labelAvgPopularity.AutoSize = true;
			this.labelAvgPopularity.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAvgPopularity.Location = new System.Drawing.Point(779, 48);
			this.labelAvgPopularity.Name = "labelAvgPopularity";
			this.labelAvgPopularity.Size = new System.Drawing.Size(15, 16);
			this.labelAvgPopularity.TabIndex = 17;
			this.labelAvgPopularity.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(452, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "Article Count:";
			// 
			// labelArticleCount
			// 
			this.labelArticleCount.AutoSize = true;
			this.labelArticleCount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelArticleCount.Location = new System.Drawing.Point(583, 25);
			this.labelArticleCount.Name = "labelArticleCount";
			this.labelArticleCount.Size = new System.Drawing.Size(15, 16);
			this.labelArticleCount.TabIndex = 11;
			this.labelArticleCount.Text = "0";
			// 
			// checkNewInfo
			// 
			this.checkNewInfo.AutoSize = true;
			this.checkNewInfo.Location = new System.Drawing.Point(26, 74);
			this.checkNewInfo.Name = "checkNewInfo";
			this.checkNewInfo.Size = new System.Drawing.Size(118, 17);
			this.checkNewInfo.TabIndex = 3;
			this.checkNewInfo.Text = "Show new info only";
			this.checkNewInfo.UseVisualStyleBackColor = true;
			// 
			// checkShowIcons
			// 
			this.checkShowIcons.AutoSize = true;
			this.checkShowIcons.Location = new System.Drawing.Point(26, 98);
			this.checkShowIcons.Name = "checkShowIcons";
			this.checkShowIcons.Size = new System.Drawing.Size(81, 17);
			this.checkShowIcons.TabIndex = 4;
			this.checkShowIcons.Text = "Show icons";
			this.checkShowIcons.UseVisualStyleBackColor = true;
			// 
			// checkAutoRefresh
			// 
			this.checkAutoRefresh.AutoSize = true;
			this.checkAutoRefresh.Location = new System.Drawing.Point(26, 121);
			this.checkAutoRefresh.Name = "checkAutoRefresh";
			this.checkAutoRefresh.Size = new System.Drawing.Size(183, 17);
			this.checkAutoRefresh.TabIndex = 5;
			this.checkAutoRefresh.Text = "Automatic refresh (once per hour)";
			this.checkAutoRefresh.UseVisualStyleBackColor = true;
			this.checkAutoRefresh.CheckedChanged += new System.EventHandler(this.checkAutoRefresh_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(221, 66);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "User ID";
			// 
			// textboxUserID
			// 
			this.textboxUserID.Location = new System.Drawing.Point(271, 62);
			this.textboxUserID.Name = "textboxUserID";
			this.textboxUserID.Size = new System.Drawing.Size(140, 20);
			this.textboxUserID.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(452, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(125, 16);
			this.label5.TabIndex = 12;
			this.label5.Text = "Articles Displayed:";
			// 
			// labelArticlesDisplayed
			// 
			this.labelArticlesDisplayed.AutoSize = true;
			this.labelArticlesDisplayed.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelArticlesDisplayed.Location = new System.Drawing.Point(583, 48);
			this.labelArticlesDisplayed.Name = "labelArticlesDisplayed";
			this.labelArticlesDisplayed.Size = new System.Drawing.Size(15, 16);
			this.labelArticlesDisplayed.TabIndex = 13;
			this.labelArticlesDisplayed.Text = "0";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(12, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(416, 145);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Location = new System.Drawing.Point(435, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(774, 145);
			this.groupBox2.TabIndex = 18;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Statistics";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1221, 682);
			this.Controls.Add(this.labelArticlesDisplayed);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textboxUserID);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.checkAutoRefresh);
			this.Controls.Add(this.checkShowIcons);
			this.Controls.Add(this.checkNewInfo);
			this.Controls.Add(this.labelArticleCount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.labelAvgPopularity);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labelAvgRating);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkboxSortDescending);
			this.Controls.Add(this.buttonSort);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "CodeProject Article Scraper";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button buttonSort;
		private System.Windows.Forms.CheckBox checkboxSortDescending;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelAvgRating;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelAvgPopularity;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelArticleCount;
		private System.Windows.Forms.CheckBox checkNewInfo;
		private System.Windows.Forms.CheckBox checkShowIcons;
		private System.Windows.Forms.CheckBox checkAutoRefresh;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textboxUserID;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelArticlesDisplayed;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;

	}
}

