using CueForms;

namespace ShipManagerPlugin
{
	partial class PluginUi
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
			this.olvFileName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
			this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblDefaultSave = new System.Windows.Forms.Label();
			this.cbDefaultSave = new System.Windows.Forms.ComboBox();
			this.btnTransfer = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.gbFileAction = new System.Windows.Forms.GroupBox();
			this.rbFileActionRename = new System.Windows.Forms.RadioButton();
			this.rbFileActionOverwrite = new System.Windows.Forms.RadioButton();
			this.tbFilter = new CueForms.CueTextBox();
			this.gbBuilding = new System.Windows.Forms.GroupBox();
			this.rbBuildingSubs = new System.Windows.Forms.RadioButton();
			this.rbBuildingAll = new System.Windows.Forms.RadioButton();
			this.rbBuildingSPH = new System.Windows.Forms.RadioButton();
			this.rbBuildingVAB = new System.Windows.Forms.RadioButton();
			this.cbListView = new System.Windows.Forms.ComboBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cmsShip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyToHangarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsList = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.collapseAllGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.expandAllGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.olvCraftList)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.gbFileAction.SuspendLayout();
			this.gbBuilding.SuspendLayout();
			this.cmsShip.SuspendLayout();
			this.cmsList.SuspendLayout();
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
			this.olvCraftList.AllColumns.Add(this.olvFileName);
			this.olvCraftList.AllowDrop = true;
			this.olvCraftList.CellEditUseWholeCell = false;
			this.olvCraftList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcShipName,
            this.olvcBuilding,
            this.olvcVersion,
            this.olvcPartCount,
            this.olvcDescription,
            this.olvcSaveName,
            this.olvFileName});
			this.olvCraftList.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvCraftList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.olvCraftList.FullRowSelect = true;
			this.olvCraftList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.olvCraftList.HeaderWordWrap = true;
			this.olvCraftList.HideSelection = false;
			this.olvCraftList.HighlightBackgroundColor = System.Drawing.Color.Empty;
			this.olvCraftList.HighlightForegroundColor = System.Drawing.Color.Empty;
			this.olvCraftList.IsSimpleDragSource = true;
			this.olvCraftList.IsSimpleDropSink = true;
			this.olvCraftList.LargeImageList = this.imageListLarge;
			this.olvCraftList.Location = new System.Drawing.Point(3, 63);
			this.olvCraftList.Name = "olvCraftList";
			this.olvCraftList.ShowItemCountOnGroups = true;
			this.olvCraftList.ShowItemToolTips = true;
			this.olvCraftList.Size = new System.Drawing.Size(848, 501);
			this.olvCraftList.SmallImageList = this.imageListSmall;
			this.olvCraftList.TabIndex = 0;
			this.olvCraftList.TileSize = new System.Drawing.Size(400, 150);
			this.olvCraftList.UseCompatibleStateImageBehavior = false;
			this.olvCraftList.UseFiltering = true;
			this.olvCraftList.UseHotItem = true;
			this.olvCraftList.UseTranslucentSelection = true;
			this.olvCraftList.View = System.Windows.Forms.View.Tile;
			this.olvCraftList.CanDrop += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.olvCraftList_CanDrop);
			this.olvCraftList.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olvCraftList_CellRightClick);
			this.olvCraftList.Dropped += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.olvCraftList_Dropped);
			this.olvCraftList.GroupExpandingCollapsing += new System.EventHandler<BrightIdeasSoftware.GroupExpandingCollapsingEventArgs>(this.olvCraftList_GroupExpandingCollapsing);
			this.olvCraftList.GroupStateChanged += new System.EventHandler<BrightIdeasSoftware.GroupStateChangedEventArgs>(this.olvCraftList_GroupStateChanged);
			this.olvCraftList.GroupTaskClicked += new System.EventHandler<BrightIdeasSoftware.GroupTaskClickedEventArgs>(this.olvCraftList_GroupTaskClicked);
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
			this.olvcThumb.Sortable = false;
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
			this.olvcDescription.WordWrap = true;
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
			// olvFileName
			// 
			this.olvFileName.AspectName = "FileName";
			this.olvFileName.AspectToStringFormat = "File Name: {0}";
			this.olvFileName.IsTileViewColumn = true;
			this.olvFileName.Sortable = false;
			this.olvFileName.Text = "File Name";
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
			this.tableLayoutPanel1.Size = new System.Drawing.Size(854, 567);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblDefaultSave);
			this.panel1.Controls.Add(this.cbDefaultSave);
			this.panel1.Controls.Add(this.btnTransfer);
			this.panel1.Controls.Add(this.btnRefresh);
			this.panel1.Controls.Add(this.gbFileAction);
			this.panel1.Controls.Add(this.tbFilter);
			this.panel1.Controls.Add(this.gbBuilding);
			this.panel1.Controls.Add(this.cbListView);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(854, 60);
			this.panel1.TabIndex = 1;
			// 
			// lblDefaultSave
			// 
			this.lblDefaultSave.AutoSize = true;
			this.lblDefaultSave.Location = new System.Drawing.Point(301, 17);
			this.lblDefaultSave.Name = "lblDefaultSave";
			this.lblDefaultSave.Size = new System.Drawing.Size(69, 13);
			this.lblDefaultSave.TabIndex = 11;
			this.lblDefaultSave.Text = "Default Save";
			// 
			// cbDefaultSave
			// 
			this.cbDefaultSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDefaultSave.FormattingEnabled = true;
			this.cbDefaultSave.Location = new System.Drawing.Point(301, 33);
			this.cbDefaultSave.Name = "cbDefaultSave";
			this.cbDefaultSave.Size = new System.Drawing.Size(148, 21);
			this.cbDefaultSave.TabIndex = 10;
			this.toolTip1.SetToolTip(this.cbDefaultSave, "Select a save to add craft to. This applies to Transfer from Hangar and craft dro" +
        "pped from Explorer.");
			// 
			// btnTransfer
			// 
			this.btnTransfer.Location = new System.Drawing.Point(220, 9);
			this.btnTransfer.Name = "btnTransfer";
			this.btnTransfer.Size = new System.Drawing.Size(75, 48);
			this.btnTransfer.TabIndex = 6;
			this.btnTransfer.Text = "Transfer from Hangar";
			this.toolTip1.SetToolTip(this.btnTransfer, "Transfer craft from the Hangar to the save selected to the right.");
			this.btnTransfer.UseVisualStyleBackColor = true;
			this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Location = new System.Drawing.Point(667, 9);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(75, 45);
			this.btnRefresh.TabIndex = 7;
			this.btnRefresh.Text = "Refresh List";
			this.toolTip1.SetToolTip(this.btnRefresh, "Reload the entire craft list.");
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// gbFileAction
			// 
			this.gbFileAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gbFileAction.Controls.Add(this.rbFileActionRename);
			this.gbFileAction.Controls.Add(this.rbFileActionOverwrite);
			this.gbFileAction.Location = new System.Drawing.Point(748, 3);
			this.gbFileAction.Name = "gbFileAction";
			this.gbFileAction.Size = new System.Drawing.Size(103, 54);
			this.gbFileAction.TabIndex = 3;
			this.gbFileAction.TabStop = false;
			this.gbFileAction.Text = "File Exists Action";
			this.toolTip1.SetToolTip(this.gbFileAction, "Select an action to take when a filename already exists.");
			// 
			// rbFileActionRename
			// 
			this.rbFileActionRename.AutoSize = true;
			this.rbFileActionRename.Checked = true;
			this.rbFileActionRename.Location = new System.Drawing.Point(6, 31);
			this.rbFileActionRename.Name = "rbFileActionRename";
			this.rbFileActionRename.Size = new System.Drawing.Size(65, 17);
			this.rbFileActionRename.TabIndex = 1;
			this.rbFileActionRename.TabStop = true;
			this.rbFileActionRename.Text = "Rename";
			this.toolTip1.SetToolTip(this.rbFileActionRename, "Will append a number to identically named craft.");
			this.rbFileActionRename.UseVisualStyleBackColor = true;
			// 
			// rbFileActionOverwrite
			// 
			this.rbFileActionOverwrite.AutoSize = true;
			this.rbFileActionOverwrite.Location = new System.Drawing.Point(6, 14);
			this.rbFileActionOverwrite.Name = "rbFileActionOverwrite";
			this.rbFileActionOverwrite.Size = new System.Drawing.Size(70, 17);
			this.rbFileActionOverwrite.TabIndex = 0;
			this.rbFileActionOverwrite.Text = "Overwrite";
			this.toolTip1.SetToolTip(this.rbFileActionOverwrite, "Will overwrite an existing craft with a the new one. NO QUESTIONS!");
			this.rbFileActionOverwrite.UseVisualStyleBackColor = true;
			this.rbFileActionOverwrite.CheckedChanged += new System.EventHandler(this.rbFileAction_CheckedChanged);
			// 
			// tbFilter
			// 
			this.tbFilter.CueText = "Filter";
			this.tbFilter.Location = new System.Drawing.Point(114, 9);
			this.tbFilter.Name = "tbFilter";
			this.tbFilter.Size = new System.Drawing.Size(100, 20);
			this.tbFilter.TabIndex = 5;
			this.toolTip1.SetToolTip(this.tbFilter, "Type to filter craft by any column value.");
			this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
			// 
			// gbBuilding
			// 
			this.gbBuilding.Controls.Add(this.rbBuildingSubs);
			this.gbBuilding.Controls.Add(this.rbBuildingAll);
			this.gbBuilding.Controls.Add(this.rbBuildingSPH);
			this.gbBuilding.Controls.Add(this.rbBuildingVAB);
			this.gbBuilding.Location = new System.Drawing.Point(3, 3);
			this.gbBuilding.Name = "gbBuilding";
			this.gbBuilding.Size = new System.Drawing.Size(105, 54);
			this.gbBuilding.TabIndex = 2;
			this.gbBuilding.TabStop = false;
			this.gbBuilding.Text = "Building";
			this.toolTip1.SetToolTip(this.gbBuilding, "Filter the entire list by building.");
			// 
			// rbBuildingSubs
			// 
			this.rbBuildingSubs.AutoSize = true;
			this.rbBuildingSubs.Location = new System.Drawing.Point(58, 31);
			this.rbBuildingSubs.Name = "rbBuildingSubs";
			this.rbBuildingSubs.Size = new System.Drawing.Size(44, 17);
			this.rbBuildingSubs.TabIndex = 3;
			this.rbBuildingSubs.TabStop = true;
			this.rbBuildingSubs.Text = "Sub";
			this.toolTip1.SetToolTip(this.rbBuildingSubs, "Shows craft subassemblies");
			this.rbBuildingSubs.UseVisualStyleBackColor = true;
			this.rbBuildingSubs.CheckedChanged += new System.EventHandler(this.rbBuilding_CheckedChanged);
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
			this.cbListView.Location = new System.Drawing.Point(114, 33);
			this.cbListView.Name = "cbListView";
			this.cbListView.Size = new System.Drawing.Size(100, 21);
			this.cbListView.TabIndex = 0;
			this.toolTip1.SetToolTip(this.cbListView, "Change the layout of the list.");
			this.cbListView.SelectedIndexChanged += new System.EventHandler(this.cbListView_SelectedIndexChanged);
			// 
			// cmsShip
			// 
			this.cmsShip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToHangarToolStripMenuItem,
            this.copyToSaveToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.cmsShip.Name = "cmsShip";
			this.cmsShip.Size = new System.Drawing.Size(185, 70);
			// 
			// copyToHangarToolStripMenuItem
			// 
			this.copyToHangarToolStripMenuItem.Name = "copyToHangarToolStripMenuItem";
			this.copyToHangarToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.copyToHangarToolStripMenuItem.Text = "Copy to Hangar";
			this.copyToHangarToolStripMenuItem.Click += new System.EventHandler(this.copyToHangarToolStripMenuItem_Click);
			// 
			// copyToSaveToolStripMenuItem
			// 
			this.copyToSaveToolStripMenuItem.Name = "copyToSaveToolStripMenuItem";
			this.copyToSaveToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.copyToSaveToolStripMenuItem.Text = "Copy to Default Save";
			this.copyToSaveToolStripMenuItem.Click += new System.EventHandler(this.copyToSaveToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// cmsList
			// 
			this.cmsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collapseAllGroupsToolStripMenuItem,
            this.expandAllGroupsToolStripMenuItem});
			this.cmsList.Name = "cmsList";
			this.cmsList.Size = new System.Drawing.Size(178, 48);
			// 
			// collapseAllGroupsToolStripMenuItem
			// 
			this.collapseAllGroupsToolStripMenuItem.Name = "collapseAllGroupsToolStripMenuItem";
			this.collapseAllGroupsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.collapseAllGroupsToolStripMenuItem.Text = "Collapse All Groups";
			this.collapseAllGroupsToolStripMenuItem.Click += new System.EventHandler(this.collapseAllGroupsToolStripMenuItem_Click);
			// 
			// expandAllGroupsToolStripMenuItem
			// 
			this.expandAllGroupsToolStripMenuItem.Name = "expandAllGroupsToolStripMenuItem";
			this.expandAllGroupsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.expandAllGroupsToolStripMenuItem.Text = "Expand All Groups";
			this.expandAllGroupsToolStripMenuItem.Click += new System.EventHandler(this.expandAllGroupsToolStripMenuItem_Click);
			// 
			// PluginUi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "PluginUi";
			this.Size = new System.Drawing.Size(854, 567);
			this.Load += new System.EventHandler(this.PluginUI_Load);
			((System.ComponentModel.ISupportInitialize)(this.olvCraftList)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.gbFileAction.ResumeLayout(false);
			this.gbFileAction.PerformLayout();
			this.gbBuilding.ResumeLayout(false);
			this.gbBuilding.PerformLayout();
			this.cmsShip.ResumeLayout(false);
			this.cmsList.ResumeLayout(false);
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
		private System.Windows.Forms.GroupBox gbBuilding;
		private System.Windows.Forms.RadioButton rbBuildingAll;
		private System.Windows.Forms.RadioButton rbBuildingSPH;
		private System.Windows.Forms.RadioButton rbBuildingVAB;
		private BrightIdeasSoftware.OLVColumn olvcVersion;
		private BrightIdeasSoftware.OLVColumn olvcDescription;
		private BrightIdeasSoftware.OLVColumn olvcPartCount;
		private CueTextBox tbFilter;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox gbFileAction;
		private System.Windows.Forms.RadioButton rbFileActionRename;
		private System.Windows.Forms.RadioButton rbFileActionOverwrite;
		private System.Windows.Forms.Button btnTransfer;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.ContextMenuStrip cmsShip;
		private System.Windows.Forms.ToolStripMenuItem copyToHangarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToSaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ComboBox cbDefaultSave;
		private System.Windows.Forms.ContextMenuStrip cmsList;
		private System.Windows.Forms.ToolStripMenuItem collapseAllGroupsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem expandAllGroupsToolStripMenuItem;
		private System.Windows.Forms.RadioButton rbBuildingSubs;
		private System.Windows.Forms.Label lblDefaultSave;
		private BrightIdeasSoftware.OLVColumn olvFileName;
	}
}
