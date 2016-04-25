using CueForms;

namespace ShipManagerPlugin
{
	partial class PluginUI
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.olvCraftList = new BrightIdeasSoftware.ObjectListView();
			this.olvcShipName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvcThumb = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvcBuilding = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvcVersion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvcPartCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvcDescription = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvcSaveName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
			this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnTransfer = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.tbFilter = new CueForms.CueTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbBuildingAll = new System.Windows.Forms.RadioButton();
			this.rbBuildingSPH = new System.Windows.Forms.RadioButton();
			this.rbBuildingVAB = new System.Windows.Forms.RadioButton();
			this.cbListView = new System.Windows.Forms.ComboBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnRefresh = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.olvCraftList)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// olvCraftList
			// 
			this.olvCraftList.AllColumns.Add(this.olvcShipName);
			this.olvCraftList.AllColumns.Add(this.olvcThumb);
			this.olvCraftList.AllColumns.Add(this.olvcBuilding);
			this.olvCraftList.AllColumns.Add(this.olvcVersion);
			this.olvCraftList.AllColumns.Add(this.olvcPartCount);
			this.olvCraftList.AllColumns.Add(this.olvcDescription);
			this.olvCraftList.AllColumns.Add(this.olvcSaveName);
			this.olvCraftList.AllowDrop = true;
			this.olvCraftList.CellEditUseWholeCell = false;
			this.olvCraftList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcShipName,
            this.olvcBuilding,
            this.olvcVersion,
            this.olvcPartCount,
            this.olvcDescription,
            this.olvcSaveName});
			this.olvCraftList.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvCraftList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.olvCraftList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.olvCraftList.HighlightBackgroundColor = System.Drawing.Color.Empty;
			this.olvCraftList.HighlightForegroundColor = System.Drawing.Color.Empty;
			this.olvCraftList.IsSimpleDragSource = true;
			this.olvCraftList.IsSimpleDropSink = true;
			this.olvCraftList.LargeImageList = this.imageListLarge;
			this.olvCraftList.Location = new System.Drawing.Point(3, 63);
			this.olvCraftList.Name = "olvCraftList";
			this.olvCraftList.ShowItemCountOnGroups = true;
			this.olvCraftList.Size = new System.Drawing.Size(857, 501);
			this.olvCraftList.SmallImageList = this.imageListSmall;
			this.olvCraftList.TabIndex = 0;
			this.olvCraftList.TileSize = new System.Drawing.Size(264, 132);
			this.olvCraftList.UseCompatibleStateImageBehavior = false;
			this.olvCraftList.UseFiltering = true;
			this.olvCraftList.UseHotItem = true;
			this.olvCraftList.View = System.Windows.Forms.View.Tile;
			this.olvCraftList.CanDrop += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.olvCraftList_CanDrop);
			this.olvCraftList.Dropped += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.olvCraftList_Dropped);
			this.olvCraftList.ModelCanDrop += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.olvCraftList_ModelCanDrop);
			this.olvCraftList.ModelDropped += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.olvCraftList_ModelDropped);
			// 
			// olvcShipName
			// 
			this.olvcShipName.AspectName = "CraftName";
			this.olvcShipName.IsTileViewColumn = true;
			this.olvcShipName.Sortable = false;
			this.olvcShipName.Text = "Craft CraftName";
			this.olvcShipName.Width = 250;
			// 
			// olvcThumb
			// 
			this.olvcThumb.AspectName = "";
			this.olvcThumb.DisplayIndex = 2;
			this.olvcThumb.ImageAspectName = "Thumb";
			this.olvcThumb.IsVisible = false;
			this.olvcThumb.Text = "Thumbnail";
			// 
			// olvcBuilding
			// 
			this.olvcBuilding.AspectName = "Building";
			this.olvcBuilding.IsTileViewColumn = true;
			this.olvcBuilding.Sortable = false;
			this.olvcBuilding.Text = "Building";
			this.olvcBuilding.Width = 100;
			// 
			// olvcVersion
			// 
			this.olvcVersion.AspectName = "Version";
			this.olvcVersion.AspectToStringFormat = "Version: {0}";
			this.olvcVersion.IsTileViewColumn = true;
			this.olvcVersion.Sortable = false;
			this.olvcVersion.Text = "Game Version";
			// 
			// olvcPartCount
			// 
			this.olvcPartCount.AspectName = "PartCount";
			this.olvcPartCount.AspectToStringFormat = "Parts: {0}";
			this.olvcPartCount.DisplayIndex = 5;
			this.olvcPartCount.IsTileViewColumn = true;
			this.olvcPartCount.Sortable = false;
			this.olvcPartCount.Text = "Part Count";
			// 
			// olvcDescription
			// 
			this.olvcDescription.AspectName = "Description";
			this.olvcDescription.AspectToStringFormat = "Description: {0}";
			this.olvcDescription.DisplayIndex = 3;
			this.olvcDescription.IsTileViewColumn = true;
			this.olvcDescription.Sortable = false;
			this.olvcDescription.Text = "Description";
			// 
			// olvcSaveName
			// 
			this.olvcSaveName.AspectName = "SaveName";
			this.olvcSaveName.AspectToStringFormat = "Save: {0}";
			this.olvcSaveName.DisplayIndex = 4;
			this.olvcSaveName.ImageAspectName = "";
			this.olvcSaveName.Text = "Save";
			this.olvcSaveName.Width = 180;
			// 
			// imageListLarge
			// 
			this.imageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageListLarge.ImageSize = new System.Drawing.Size(128, 128);
			this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// imageListSmall
			// 
			this.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageListSmall.ImageSize = new System.Drawing.Size(64, 64);
			this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.olvCraftList, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(863, 567);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnRefresh);
			this.panel1.Controls.Add(this.btnTransfer);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.tbFilter);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.cbListView);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(863, 60);
			this.panel1.TabIndex = 1;
			// 
			// btnTransfer
			// 
			this.btnTransfer.Location = new System.Drawing.Point(216, 9);
			this.btnTransfer.Name = "btnTransfer";
			this.btnTransfer.Size = new System.Drawing.Size(75, 45);
			this.btnTransfer.TabIndex = 6;
			this.btnTransfer.Text = "Transfer from Hangar";
			this.btnTransfer.UseVisualStyleBackColor = true;
			this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Location = new System.Drawing.Point(757, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(103, 54);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "File Exists Action";
			this.toolTip1.SetToolTip(this.groupBox2, "Filter the entire list by building.");
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(6, 31);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(65, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Rename";
			this.toolTip1.SetToolTip(this.radioButton2, "Shows only SPH craft.");
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(6, 14);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(70, 17);
			this.radioButton3.TabIndex = 0;
			this.radioButton3.Text = "Overwrite";
			this.toolTip1.SetToolTip(this.radioButton3, "Shows only VAB craft.");
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// tbFilter
			// 
			this.tbFilter.CueText = "Filter";
			this.tbFilter.Location = new System.Drawing.Point(110, 9);
			this.tbFilter.Name = "tbFilter";
			this.tbFilter.Size = new System.Drawing.Size(100, 20);
			this.tbFilter.TabIndex = 5;
			this.toolTip1.SetToolTip(this.tbFilter, "Type to filter craft by name.");
			this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbBuildingAll);
			this.groupBox1.Controls.Add(this.rbBuildingSPH);
			this.groupBox1.Controls.Add(this.rbBuildingVAB);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(100, 54);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Building";
			this.toolTip1.SetToolTip(this.groupBox1, "Filter the entire list by building.");
			// 
			// rbBuildingAll
			// 
			this.rbBuildingAll.AutoSize = true;
			this.rbBuildingAll.Checked = true;
			this.rbBuildingAll.Location = new System.Drawing.Point(58, 14);
			this.rbBuildingAll.Name = "rbBuildingAll";
			this.rbBuildingAll.Size = new System.Drawing.Size(36, 17);
			this.rbBuildingAll.TabIndex = 2;
			this.rbBuildingAll.TabStop = true;
			this.rbBuildingAll.Text = "All";
			this.toolTip1.SetToolTip(this.rbBuildingAll, "Shows all craft.");
			this.rbBuildingAll.UseVisualStyleBackColor = true;
			this.rbBuildingAll.CheckedChanged += new System.EventHandler(this.rbBuilding_CheckedChanged);
			// 
			// rbBuildingSPH
			// 
			this.rbBuildingSPH.AutoSize = true;
			this.rbBuildingSPH.Location = new System.Drawing.Point(6, 31);
			this.rbBuildingSPH.Name = "rbBuildingSPH";
			this.rbBuildingSPH.Size = new System.Drawing.Size(47, 17);
			this.rbBuildingSPH.TabIndex = 1;
			this.rbBuildingSPH.Text = "SPH";
			this.toolTip1.SetToolTip(this.rbBuildingSPH, "Shows only SPH craft.");
			this.rbBuildingSPH.UseVisualStyleBackColor = true;
			this.rbBuildingSPH.CheckedChanged += new System.EventHandler(this.rbBuilding_CheckedChanged);
			// 
			// rbBuildingVAB
			// 
			this.rbBuildingVAB.AutoSize = true;
			this.rbBuildingVAB.Location = new System.Drawing.Point(6, 14);
			this.rbBuildingVAB.Name = "rbBuildingVAB";
			this.rbBuildingVAB.Size = new System.Drawing.Size(46, 17);
			this.rbBuildingVAB.TabIndex = 0;
			this.rbBuildingVAB.Text = "VAB";
			this.toolTip1.SetToolTip(this.rbBuildingVAB, "Shows only VAB craft.");
			this.rbBuildingVAB.UseVisualStyleBackColor = true;
			this.rbBuildingVAB.CheckedChanged += new System.EventHandler(this.rbBuilding_CheckedChanged);
			// 
			// cbListView
			// 
			this.cbListView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbListView.FormattingEnabled = true;
			this.cbListView.Items.AddRange(new object[] {
            "Tile",
            "Details"});
			this.cbListView.Location = new System.Drawing.Point(110, 33);
			this.cbListView.Name = "cbListView";
			this.cbListView.Size = new System.Drawing.Size(100, 21);
			this.cbListView.TabIndex = 0;
			this.cbListView.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(394, 8);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(75, 45);
			this.btnRefresh.TabIndex = 7;
			this.btnRefresh.Text = "Refresh List";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// PluginUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "PluginUI";
			this.Size = new System.Drawing.Size(863, 567);
			this.Load += new System.EventHandler(this.PluginUI_Load);
			((System.ComponentModel.ISupportInitialize)(this.olvCraftList)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private BrightIdeasSoftware.ObjectListView olvCraftList;
		private BrightIdeasSoftware.OLVColumn olvcSaveName;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox cbListView;
		private BrightIdeasSoftware.OLVColumn olvcThumb;
		private System.Windows.Forms.ImageList imageListLarge;
		private System.Windows.Forms.ImageList imageListSmall;
		private BrightIdeasSoftware.OLVColumn olvcShipName;
		private BrightIdeasSoftware.OLVColumn olvcBuilding;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbBuildingAll;
		private System.Windows.Forms.RadioButton rbBuildingSPH;
		private System.Windows.Forms.RadioButton rbBuildingVAB;
		private BrightIdeasSoftware.OLVColumn olvcVersion;
		private BrightIdeasSoftware.OLVColumn olvcDescription;
		private BrightIdeasSoftware.OLVColumn olvcPartCount;
		private CueTextBox tbFilter;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Button btnTransfer;
		private System.Windows.Forms.Button btnRefresh;
	}
}
