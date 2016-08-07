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
			this.tbLog = new System.Windows.Forms.TextBox();
			this.grpFiles = new System.Windows.Forms.GroupBox();
			this.prunerDgvFileList = new System.Windows.Forms.DataGridView();
			this.dgvColCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dgvColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
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
			this.grpFiles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.prunerDgvFileList)).BeginInit();
			this.grpCreate.SuspendLayout();
			this.createTlpButtons.SuspendLayout();
			this.panelTlp.SuspendLayout();
			this.createContextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.SuspendLayout();
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
			// grpFiles
			// 
			this.grpFiles.Controls.Add(this.prunerDgvFileList);
			this.grpFiles.Controls.Add(this.checkedListBox1);
			this.grpFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpFiles.Location = new System.Drawing.Point(3, 3);
			this.grpFiles.Name = "grpFiles";
			this.grpFiles.Size = new System.Drawing.Size(433, 392);
			this.grpFiles.TabIndex = 1;
			this.grpFiles.TabStop = false;
			this.grpFiles.Text = "Pruner Files";
			// 
			// prunerDgvFileList
			// 
			this.prunerDgvFileList.AllowUserToAddRows = false;
			this.prunerDgvFileList.AllowUserToDeleteRows = false;
			this.prunerDgvFileList.AllowUserToResizeRows = false;
			this.prunerDgvFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.prunerDgvFileList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.prunerDgvFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.prunerDgvFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColCheck,
            this.dgvColName});
			this.prunerDgvFileList.Location = new System.Drawing.Point(6, 19);
			this.prunerDgvFileList.Name = "prunerDgvFileList";
			this.prunerDgvFileList.RowHeadersVisible = false;
			this.prunerDgvFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.prunerDgvFileList.Size = new System.Drawing.Size(421, 367);
			this.prunerDgvFileList.TabIndex = 3;
			this.prunerDgvFileList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.prunerDgvFileList_CellDoubleClick);
			this.prunerDgvFileList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.prunerDgvFileList_CellValueChanged);
			this.prunerDgvFileList.CurrentCellDirtyStateChanged += new System.EventHandler(this.prunerDgvFileList_CurrentCellDirtyStateChanged);
			this.prunerDgvFileList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.prunerDgvFileList_KeyUp);
			// 
			// dgvColCheck
			// 
			this.dgvColCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.dgvColCheck.DataPropertyName = "Active";
			this.dgvColCheck.FalseValue = "False";
			this.dgvColCheck.HeaderText = "Pruned";
			this.dgvColCheck.IndeterminateValue = "";
			this.dgvColCheck.Name = "dgvColCheck";
			this.dgvColCheck.TrueValue = "True";
			this.dgvColCheck.Width = 47;
			// 
			// dgvColName
			// 
			this.dgvColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dgvColName.DataPropertyName = "Name";
			this.dgvColName.HeaderText = "Name";
			this.dgvColName.Name = "dgvColName";
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(6, 19);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(284, 364);
			this.checkedListBox1.TabIndex = 4;
			this.checkedListBox1.Visible = false;
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
			this.grpFiles.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.prunerDgvFileList)).EndInit();
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
		private System.Windows.Forms.TextBox tbLog;
		private System.Windows.Forms.TableLayoutPanel panelTlp;
		private System.Windows.Forms.GroupBox grpFiles;
		private System.Windows.Forms.GroupBox grpCreate;
		private System.Windows.Forms.TableLayoutPanel createTlpButtons;
		private System.Windows.Forms.Button createBtnSave;
		private System.Windows.Forms.Button createBtnClear;
		private System.Windows.Forms.Label createLblDescription;
		private System.Windows.Forms.ListBox createLbFiles;
		private System.Windows.Forms.ContextMenuStrip createContextMenu;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.IO.FileSystemWatcher fileSystemWatcher1;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.DataGridView prunerDgvFileList;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dgvColCheck;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvColName;
	}
}
