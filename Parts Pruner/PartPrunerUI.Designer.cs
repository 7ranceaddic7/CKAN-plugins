namespace PartsPrunerPlugin
{
	partial class PartPrunerUi
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
			this.prunerLbFileList = new System.Windows.Forms.ListBox();
			this.tbLog = new System.Windows.Forms.TextBox();
			this.prunerTlpButtonList = new System.Windows.Forms.TableLayoutPanel();
			this.prunerBtnEdit = new System.Windows.Forms.Button();
			this.prunerBtnRescan = new System.Windows.Forms.Button();
			this.prunerBtnUnpruneSelected = new System.Windows.Forms.Button();
			this.prunerBtnPruneSelected = new System.Windows.Forms.Button();
			this.prunerBtnUnpruneAll = new System.Windows.Forms.Button();
			this.prunerBtnPruneAll = new System.Windows.Forms.Button();
			this.grpFiles = new System.Windows.Forms.GroupBox();
			this.grpCreate = new System.Windows.Forms.GroupBox();
			this.createTlpButtons = new System.Windows.Forms.TableLayoutPanel();
			this.createBtnSave = new System.Windows.Forms.Button();
			this.createBtnClear = new System.Windows.Forms.Button();
			this.createLbFiles = new System.Windows.Forms.ListBox();
			this.createLblDescription = new System.Windows.Forms.Label();
			this.panelTlp = new System.Windows.Forms.TableLayoutPanel();
			this.createContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			this.prunerTlpButtonList.SuspendLayout();
			this.grpFiles.SuspendLayout();
			this.grpCreate.SuspendLayout();
			this.createTlpButtons.SuspendLayout();
			this.panelTlp.SuspendLayout();
			this.createContextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.SuspendLayout();
			// 
			// prunerLbFileList
			// 
			this.prunerLbFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.prunerLbFileList.FormattingEnabled = true;
			this.prunerLbFileList.Location = new System.Drawing.Point(6, 19);
			this.prunerLbFileList.Name = "prunerLbFileList";
			this.prunerLbFileList.ScrollAlwaysVisible = true;
			this.prunerLbFileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.prunerLbFileList.Size = new System.Drawing.Size(284, 342);
			this.prunerLbFileList.Sorted = true;
			this.prunerLbFileList.TabIndex = 0;
			this.prunerLbFileList.Click += new System.EventHandler(this.prunerLbFileList_Click);
			this.prunerLbFileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.prunerLbFileList_KeyDown);
			// 
			// tbLog
			// 
			this.tbLog.BackColor = System.Drawing.SystemColors.Control;
			this.panelTlp.SetColumnSpan(this.tbLog, 2);
			this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbLog.Location = new System.Drawing.Point(3, 401);
			this.tbLog.Multiline = true;
			this.tbLog.Name = "tbLog";
			this.tbLog.ReadOnly = true;
			this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbLog.Size = new System.Drawing.Size(872, 260);
			this.tbLog.TabIndex = 1;
			// 
			// prunerTlpButtonList
			// 
			this.prunerTlpButtonList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.prunerTlpButtonList.AutoSize = true;
			this.prunerTlpButtonList.ColumnCount = 1;
			this.prunerTlpButtonList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.prunerTlpButtonList.Controls.Add(this.prunerBtnEdit, 0, 5);
			this.prunerTlpButtonList.Controls.Add(this.prunerBtnRescan, 0, 4);
			this.prunerTlpButtonList.Controls.Add(this.prunerBtnUnpruneSelected, 0, 3);
			this.prunerTlpButtonList.Controls.Add(this.prunerBtnPruneSelected, 0, 2);
			this.prunerTlpButtonList.Controls.Add(this.prunerBtnUnpruneAll, 0, 1);
			this.prunerTlpButtonList.Controls.Add(this.prunerBtnPruneAll, 0, 0);
			this.prunerTlpButtonList.Location = new System.Drawing.Point(296, 19);
			this.prunerTlpButtonList.Name = "prunerTlpButtonList";
			this.prunerTlpButtonList.RowCount = 6;
			this.prunerTlpButtonList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.prunerTlpButtonList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.prunerTlpButtonList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.prunerTlpButtonList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.prunerTlpButtonList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.prunerTlpButtonList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.prunerTlpButtonList.Size = new System.Drawing.Size(131, 174);
			this.prunerTlpButtonList.TabIndex = 2;
			// 
			// prunerBtnEdit
			// 
			this.prunerBtnEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.prunerBtnEdit.Enabled = false;
			this.prunerBtnEdit.Location = new System.Drawing.Point(3, 145);
			this.prunerBtnEdit.Name = "prunerBtnEdit";
			this.prunerBtnEdit.Size = new System.Drawing.Size(125, 23);
			this.prunerBtnEdit.TabIndex = 5;
			this.prunerBtnEdit.Text = "Edit";
			this.prunerBtnEdit.UseVisualStyleBackColor = true;
			this.prunerBtnEdit.Click += new System.EventHandler(this.pruneBtnEdit_Click);
			// 
			// prunerBtnRescan
			// 
			this.prunerBtnRescan.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.prunerBtnRescan.Location = new System.Drawing.Point(3, 115);
			this.prunerBtnRescan.Name = "prunerBtnRescan";
			this.prunerBtnRescan.Size = new System.Drawing.Size(125, 22);
			this.prunerBtnRescan.TabIndex = 4;
			this.prunerBtnRescan.Text = "Rescan Folder";
			this.prunerBtnRescan.UseVisualStyleBackColor = true;
			this.prunerBtnRescan.Click += new System.EventHandler(this.pruneBtnRescanFolder_Click);
			// 
			// prunerBtnUnpruneSelected
			// 
			this.prunerBtnUnpruneSelected.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.prunerBtnUnpruneSelected.Location = new System.Drawing.Point(3, 87);
			this.prunerBtnUnpruneSelected.Name = "prunerBtnUnpruneSelected";
			this.prunerBtnUnpruneSelected.Size = new System.Drawing.Size(125, 22);
			this.prunerBtnUnpruneSelected.TabIndex = 3;
			this.prunerBtnUnpruneSelected.Text = "Unprune Selected";
			this.prunerBtnUnpruneSelected.UseVisualStyleBackColor = true;
			this.prunerBtnUnpruneSelected.Click += new System.EventHandler(this.pruneBtnUnpruneSelected_Click);
			// 
			// prunerBtnPruneSelected
			// 
			this.prunerBtnPruneSelected.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.prunerBtnPruneSelected.Location = new System.Drawing.Point(3, 59);
			this.prunerBtnPruneSelected.Name = "prunerBtnPruneSelected";
			this.prunerBtnPruneSelected.Size = new System.Drawing.Size(125, 22);
			this.prunerBtnPruneSelected.TabIndex = 2;
			this.prunerBtnPruneSelected.Text = "Prune Selected";
			this.prunerBtnPruneSelected.UseVisualStyleBackColor = true;
			this.prunerBtnPruneSelected.Click += new System.EventHandler(this.pruneBtnPruneSelected_Click);
			// 
			// prunerBtnUnpruneAll
			// 
			this.prunerBtnUnpruneAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.prunerBtnUnpruneAll.Location = new System.Drawing.Point(3, 31);
			this.prunerBtnUnpruneAll.Name = "prunerBtnUnpruneAll";
			this.prunerBtnUnpruneAll.Size = new System.Drawing.Size(125, 22);
			this.prunerBtnUnpruneAll.TabIndex = 1;
			this.prunerBtnUnpruneAll.Text = "Unprune All";
			this.prunerBtnUnpruneAll.UseVisualStyleBackColor = true;
			this.prunerBtnUnpruneAll.Click += new System.EventHandler(this.pruneBtnUnpruneAll_Click);
			// 
			// prunerBtnPruneAll
			// 
			this.prunerBtnPruneAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.prunerBtnPruneAll.Location = new System.Drawing.Point(3, 3);
			this.prunerBtnPruneAll.Name = "prunerBtnPruneAll";
			this.prunerBtnPruneAll.Size = new System.Drawing.Size(125, 22);
			this.prunerBtnPruneAll.TabIndex = 0;
			this.prunerBtnPruneAll.Text = "Prune All";
			this.prunerBtnPruneAll.UseVisualStyleBackColor = true;
			this.prunerBtnPruneAll.Click += new System.EventHandler(this.pruneBtnPruneAll_Click);
			// 
			// grpFiles
			// 
			this.grpFiles.Controls.Add(this.prunerLbFileList);
			this.grpFiles.Controls.Add(this.prunerTlpButtonList);
			this.grpFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpFiles.Location = new System.Drawing.Point(3, 3);
			this.grpFiles.Name = "grpFiles";
			this.grpFiles.Size = new System.Drawing.Size(433, 392);
			this.grpFiles.TabIndex = 1;
			this.grpFiles.TabStop = false;
			this.grpFiles.Text = "Pruner Files";
			// 
			// grpCreate
			// 
			this.grpCreate.Controls.Add(this.createTlpButtons);
			this.grpCreate.Controls.Add(this.createLbFiles);
			this.grpCreate.Controls.Add(this.createLblDescription);
			this.grpCreate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpCreate.Location = new System.Drawing.Point(442, 3);
			this.grpCreate.Name = "grpCreate";
			this.grpCreate.Size = new System.Drawing.Size(433, 392);
			this.grpCreate.TabIndex = 2;
			this.grpCreate.TabStop = false;
			this.grpCreate.Text = "Create Pruner";
			// 
			// createTlpButtons
			// 
			this.createTlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.createTlpButtons.ColumnCount = 2;
			this.createTlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.createTlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.createTlpButtons.Controls.Add(this.createBtnSave, 0, 0);
			this.createTlpButtons.Controls.Add(this.createBtnClear, 1, 0);
			this.createTlpButtons.Location = new System.Drawing.Point(6, 357);
			this.createTlpButtons.Name = "createTlpButtons";
			this.createTlpButtons.RowCount = 1;
			this.createTlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.createTlpButtons.Size = new System.Drawing.Size(421, 29);
			this.createTlpButtons.TabIndex = 1;
			// 
			// createBtnSave
			// 
			this.createBtnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.createBtnSave.Location = new System.Drawing.Point(67, 3);
			this.createBtnSave.Name = "createBtnSave";
			this.createBtnSave.Size = new System.Drawing.Size(75, 23);
			this.createBtnSave.TabIndex = 1;
			this.createBtnSave.Text = "Save";
			this.createBtnSave.UseVisualStyleBackColor = true;
			this.createBtnSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// createBtnClear
			// 
			this.createBtnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.createBtnClear.Location = new System.Drawing.Point(278, 3);
			this.createBtnClear.Name = "createBtnClear";
			this.createBtnClear.Size = new System.Drawing.Size(75, 23);
			this.createBtnClear.TabIndex = 4;
			this.createBtnClear.Text = "Clear";
			this.createBtnClear.UseVisualStyleBackColor = true;
			this.createBtnClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// createLbFiles
			// 
			this.createLbFiles.AllowDrop = true;
			this.createLbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.createLbFiles.FormattingEnabled = true;
			this.createLbFiles.Location = new System.Drawing.Point(6, 74);
			this.createLbFiles.Name = "createLbFiles";
			this.createLbFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.createLbFiles.Size = new System.Drawing.Size(421, 277);
			this.createLbFiles.TabIndex = 2;
			this.createLbFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
			this.createLbFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
			this.createLbFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_KeyDown);
			this.createLbFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
			// 
			// createLblDescription
			// 
			this.createLblDescription.AutoSize = true;
			this.createLblDescription.Location = new System.Drawing.Point(6, 16);
			this.createLblDescription.Name = "createLblDescription";
			this.createLblDescription.Size = new System.Drawing.Size(315, 39);
			this.createLblDescription.TabIndex = 0;
			this.createLblDescription.Text = "Select a file in the list to the left and click \'Edit\' to open it below.\r\n\r\nDrag " +
    "and drop folders and files from GameData into the list below.";
			// 
			// panelTlp
			// 
			this.panelTlp.ColumnCount = 2;
			this.panelTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.panelTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.panelTlp.Controls.Add(this.tbLog, 0, 1);
			this.panelTlp.Controls.Add(this.grpFiles, 0, 0);
			this.panelTlp.Controls.Add(this.grpCreate, 1, 0);
			this.panelTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTlp.Location = new System.Drawing.Point(0, 0);
			this.panelTlp.Name = "panelTlp";
			this.panelTlp.RowCount = 2;
			this.panelTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.panelTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.panelTlp.Size = new System.Drawing.Size(878, 664);
			this.panelTlp.TabIndex = 3;
			// 
			// createContextMenu
			// 
			this.createContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
			this.createContextMenu.Name = "createContextMenu";
			this.createContextMenu.Size = new System.Drawing.Size(108, 26);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.ContextMenuListBox_Delete_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOK);
			// 
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.Filter = "*.prnl";
			this.fileSystemWatcher1.SynchronizingObject = this;
			this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
			this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Deleted);
			this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
			// 
			// PartPrunerUi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelTlp);
			this.Name = "PartPrunerUi";
			this.Size = new System.Drawing.Size(878, 664);
			this.Load += new System.EventHandler(this.PartPrunerUI_Load);
			this.prunerTlpButtonList.ResumeLayout(false);
			this.grpFiles.ResumeLayout(false);
			this.grpFiles.PerformLayout();
			this.grpCreate.ResumeLayout(false);
			this.grpCreate.PerformLayout();
			this.createTlpButtons.ResumeLayout(false);
			this.panelTlp.ResumeLayout(false);
			this.panelTlp.PerformLayout();
			this.createContextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListBox prunerLbFileList;
		private System.Windows.Forms.TextBox tbLog;
		private System.Windows.Forms.TableLayoutPanel prunerTlpButtonList;
		private System.Windows.Forms.Button prunerBtnRescan;
		private System.Windows.Forms.Button prunerBtnUnpruneSelected;
		private System.Windows.Forms.Button prunerBtnPruneSelected;
		private System.Windows.Forms.Button prunerBtnUnpruneAll;
		private System.Windows.Forms.Button prunerBtnPruneAll;
		private System.Windows.Forms.TableLayoutPanel panelTlp;
		private System.Windows.Forms.GroupBox grpFiles;
		private System.Windows.Forms.GroupBox grpCreate;
		private System.Windows.Forms.TableLayoutPanel createTlpButtons;
		private System.Windows.Forms.Button createBtnSave;
		private System.Windows.Forms.Button createBtnClear;
		private System.Windows.Forms.Label createLblDescription;
		private System.Windows.Forms.Button prunerBtnEdit;
		private System.Windows.Forms.ListBox createLbFiles;
		private System.Windows.Forms.ContextMenuStrip createContextMenu;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.IO.FileSystemWatcher fileSystemWatcher1;
	}
}
