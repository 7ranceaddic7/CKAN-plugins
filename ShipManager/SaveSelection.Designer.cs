namespace ShipManagerPlugin
{
	partial class SaveSelection
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tlpContents = new System.Windows.Forms.TableLayoutPanel();
			this.tlpCenterer = new System.Windows.Forms.TableLayoutPanel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tlpContents.SuspendLayout();
			this.tlpCenterer.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(3, 33);
			this.comboBox1.MaxDropDownItems = 20;
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(249, 21);
			this.comboBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(48, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(159, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select a save to add the craft to";
			// 
			// tlpContents
			// 
			this.tlpContents.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tlpContents.ColumnCount = 1;
			this.tlpCenterer.SetColumnSpan(this.tlpContents, 2);
			this.tlpContents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpContents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpContents.Controls.Add(this.label1, 0, 0);
			this.tlpContents.Controls.Add(this.comboBox1, 0, 1);
			this.tlpContents.Location = new System.Drawing.Point(64, 12);
			this.tlpContents.Name = "tlpContents";
			this.tlpContents.RowCount = 2;
			this.tlpContents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpContents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpContents.Size = new System.Drawing.Size(256, 58);
			this.tlpContents.TabIndex = 2;
			// 
			// tlpCenterer
			// 
			this.tlpCenterer.ColumnCount = 2;
			this.tlpCenterer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpCenterer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tlpCenterer.Controls.Add(this.tlpContents, 0, 0);
			this.tlpCenterer.Controls.Add(this.btnCancel, 0, 1);
			this.tlpCenterer.Controls.Add(this.btnOK, 1, 1);
			this.tlpCenterer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpCenterer.Location = new System.Drawing.Point(0, 0);
			this.tlpCenterer.Name = "tlpCenterer";
			this.tlpCenterer.RowCount = 2;
			this.tlpCenterer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpCenterer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpCenterer.Size = new System.Drawing.Size(384, 112);
			this.tlpCenterer.TabIndex = 3;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnCancel.Location = new System.Drawing.Point(206, 85);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnOK.Location = new System.Drawing.Point(306, 85);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// SaveSelection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 112);
			this.Controls.Add(this.tlpCenterer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SaveSelection";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.tlpContents.ResumeLayout(false);
			this.tlpContents.PerformLayout();
			this.tlpCenterer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tlpContents;
		private System.Windows.Forms.TableLayoutPanel tlpCenterer;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
	}
}