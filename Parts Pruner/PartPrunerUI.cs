using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CKAN;
using PartsPruner;

namespace PartsPrunerPlugin
{
	public partial class PartPrunerUi : UserControl
	{
		#region Consts

		private readonly string _prunerDirectory = Path.Combine(Main.Instance.CurrentInstance.GameDir(), "PRNLs");

		#endregion Consts

		public static PartPrunerUi Instance;

		private FilePruner _filePruner;


		public PartPrunerUi()
		{
			InitializeComponent();
			Instance = this;
		}

		private void PartPrunerUI_Load(object sender, EventArgs e)
		{
			if (!Directory.Exists(_prunerDirectory))
			{
				Main.Instance.AddLogMessage("Creating PRNL folder.");
				Directory.CreateDirectory(_prunerDirectory);
			}

			_filePruner = new FilePruner();

			//PopulateFileList();
			InitializeFileWatcher();

			//foreach (DataGridViewRow row in prunerDgvFileList.Rows)
			//{
				//var check = _filePruner.CheckPruned(((PruneItem) row.DataBoundItem).FilePath);

				//var box = (DataGridViewCheckBoxCell) row.Cells[0];
				//var tval = box.TrueValue;
				//var fval = box.FalseValue;
				//var val = box.Value;

				//try { 
				//box.Value = box.TrueValue;
				//}
				//catch (Exception ex)
				//{ Log(ex.Message + "\n" + ex.StackTrace);}
				//row.Cells[0].Value = check;

				//if (check == 0)
				//	gridViewCell.Value = gridViewCell.FalseValue;
				//else if (check == 1)
				//	gridViewCell.Value = gridViewCell.TrueValue;
				//else
				//	gridViewCell.Value = gridViewCell.IndeterminateValue;

			//}
		}

		/// <summary>
		/// Returns a full file path as relative to GameData directory
		/// </summary>
		/// <param name="path">Full file path to reduce</param>
		/// <returns></returns>
		internal static string GetGameDataPath(String path)
		{
			var splits = new string[] { @"GameData" + Path.DirectorySeparatorChar };
			var parts = path.Split(splits, StringSplitOptions.None);
			return @"GameData\" + parts[1];
		}


		#region Console Logging

		delegate void SetTextCallback(string text);

		public void Log(String line)
		{
			if (this.tbLog.InvokeRequired)
			{
				var d = new SetTextCallback(LogAddLine);
				this.Invoke(d, new object[] {line + Environment.NewLine});
			}
			else
			{
				LogAddLine(line);
				LogAddLine(Environment.NewLine);
			}

		}

		public void LogWarning(String line)
		{
			LogAddLine("Warning:");
			LogAddLine("\t" + line);
			LogAddLine(Environment.NewLine);
		}

		public void LogError(String line)
		{
			LogAddLine("Error:");
			LogAddLine("\t" + line);
			LogAddLine(Environment.NewLine);
		}

		public void LogNewEntry()
		{
			LogAddLine(Environment.NewLine);
			LogAddLine("==================================================");
			LogAddLine(Environment.NewLine);
			LogAddLine(Environment.NewLine);
		}

		public void LogAddLine(String line)
		{
			tbLog.AppendText(line);
		}

		#endregion Console Logging


		#region Pruner - Left Side

		/// <summary>
		/// Returns a list of file paths to the selected pruner files
		/// </summary>
		/// <returns></returns>
		private IEnumerable<string> GetSelectedFiles()
		{
			var itemsList = new List<string>();
			foreach (DataGridViewRow selectedRow in prunerDgvFileList.SelectedRows)
			{
				itemsList.Add(((PruneItem)selectedRow.DataBoundItem).FilePath);
			}

			if (itemsList.Count == 0)
				Log("No files selected.");

			return itemsList;
		}

		#region prunerDgvFileList Events
		private void prunerDgvFileList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (prunerDgvFileList.IsCurrentCellDirty)
			{
				prunerDgvFileList.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void prunerDgvFileList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;
			if (e.ColumnIndex < 0) return;

			var grid = sender as DataGridView;
			var row = grid.Rows[e.RowIndex];
			var columnIndex = e.ColumnIndex;

			if (columnIndex != 1) return;

			var gridViewCell = row.Cells[columnIndex] as DataGridViewCheckBoxCell;
				
			if (gridViewCell.Value.ToString() == "False")
			{
				LogNewEntry();
				_filePruner.UnpruneFiles(GetSelectedFiles());
			}
			else
			{
				LogNewEntry();
				_filePruner.PruneFiles(GetSelectedFiles());
			}
		}

		private void prunerDgvFileList_KeyUp(object sender, KeyEventArgs e)
		{
			var grid = sender as DataGridView;
			var checkBoxes = new List<DataGridViewCheckBoxCell>();
			foreach (DataGridViewRow selectedRow in grid.SelectedRows)
				checkBoxes.Add(selectedRow.Cells[1] as DataGridViewCheckBoxCell);

			switch (e.KeyCode)
			{
				case Keys.Space:
					foreach (var box in checkBoxes)
						box.Value = box.Value == box.FalseValue ? box.TrueValue : box.FalseValue;
					break;
			}
		}

		private void prunerDgvFileList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1 && e.ColumnIndex > -1)
			{
				var pruneObj = prunerDgvFileList.Rows[e.RowIndex].DataBoundItem as PruneItem;
				try
				{
					using (var sr = new StreamReader(pruneObj.FilePath))
					{
						createLbFiles.Items.Clear();
						var line = "";
						while ((line = sr.ReadLine()) != null)
							createLbFiles.Items.Add(line);
					}
				}
				catch (Exception ex)
				{
					LogError("Could not open " + GetGameDataPath(pruneObj.FilePath));
				}
			}
		}
		#endregion prunerDgvFileList Events

		#endregion Pruner - Left Side


		#region Creator - Right Side

		#region ListBox
		private void listBox_DragDrop(object sender, DragEventArgs e)
			{
				// transfer the filenames to a string array
				// (yes, everything to the left of the "=" can be put in the 
				// foreach loop in place of "files", but this is easier to understand.)
				var files = (string[]) e.Data.GetData(DataFormats.FileDrop);

				// loop through the string array, adding each filename to the ListBox
				foreach (var file in files)
				{
					var splits = new string[] {@"GameData" + Path.DirectorySeparatorChar};
					var parts = file.Split(splits, StringSplitOptions.None);
					if (!createLbFiles.Items.Contains(parts[1]))
						createLbFiles.Items.Add(parts[1]);
				}
			}

		private void listBox_DragEnter(object sender, DragEventArgs e)
		{
			// make sure they're actually dropping files (not text or anything else)
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
				// allow them to continue
				// (without this, the cursor stays a "NO" symbol
				e.Effect = DragDropEffects.All;
		}

		private void listBox_MouseDown(object sender, MouseEventArgs e)
		{
			// Only do this if the right mouse button is clicked on the control
			if (e.Button != MouseButtons.Right) return;

			// Get the index of the item clicked upon from the mouse position
			var index = ((ListBox) sender).IndexFromPoint((e.Location));

			// If the index is not a valid item in the list, remove the context menu
			// so it doesn't show up on an empty space, then return
			if (index == ListBox.NoMatches)
			{
				((ListBox) sender).ContextMenuStrip = null;
				return;
			}

			// The index clicked upon was valid, so we need to add the context menu
			// back to the form so that it returns the proper owner later.
			((ListBox) sender).ContextMenuStrip = createContextMenu;

			// Go ahead and add the currently moused over index to the selected items
			((ListBox) sender).SelectedIndices.Add(index);

			// Show the context menu where the mouse cursor is positioned (why is this not default?)
			createContextMenu.Show(Cursor.Position);
		}

		private void listBox_KeyDown(object sender, KeyEventArgs e)
		{
			var selected = ((ListBox) sender).SelectedItems;
			switch (e.KeyCode)
			{
				case Keys.Delete:
					if (selected.Count > 0)
						while (selected.Count > 0)
							((ListBox) sender).Items.Remove(selected[0]);

					break;
			}
		}
		#endregion Listbox
		#region Buttons
		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(_prunerDirectory))
				Directory.CreateDirectory(_prunerDirectory);

			saveFileDialog1.Filter = "Pruner File|*.prnl";
			saveFileDialog1.InitialDirectory = _prunerDirectory;
			saveFileDialog1.FileName = Path.GetFileName(saveFileDialog1.FileName);
			saveFileDialog1.ShowDialog();
		}

		private void buttonClear_Click(object sender, EventArgs e)
		{
			createLbFiles.Items.Clear();
		}

		private void saveFileDialog1_FileOK(object sender, CancelEventArgs e)
		{
			var listItems = createLbFiles.Items.Cast<String>().ToList();

			using (var sw = new StreamWriter(saveFileDialog1.FileName, false))
			{
				foreach (var listItem in listItems)
					sw.Write(listItem + Environment.NewLine);
			}
		}
		#endregion Buttons

		private void ContextMenuListBox_Delete_Click(object sender, EventArgs e)
		{
			// Try to cast the sender to a ToolStripItem
			var menuItem = sender as ToolStripItem;

			// Retrieve the ContextMenuStrip that owns this ToolStripItem
			var owner = menuItem?.Owner as ContextMenuStrip;

			// Get the control that is displaying this context menu
			Control sourceControl = owner?.SourceControl as ListBox;

			if (sourceControl == null) return;
			while (createLbFiles.SelectedItems.Count > 0)
				createLbFiles.Items.Remove(createLbFiles.SelectedItems[0]);
		}

		#endregion Creator - Right Side
		

		#region File System Watcher
		readonly BindingList<PruneItem> _files = new BindingList<PruneItem>();

		private void InitializeFileWatcher()
		{
			fileSystemWatcher1.Path = _prunerDirectory;

			foreach (string file in Directory.GetFiles(fileSystemWatcher1.Path, "*.prnl"))
				_files.Add(new PruneItem(file, _filePruner.CheckPruned(file)));

			prunerDgvFileList.DataSource = _files;
		}

		private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
		{
			var name = e.Name;
			var oldname = e.OldName;

			foreach (var pruneItem in _files)
			{
				if (!pruneItem.FilePath.Equals(oldname)) continue;
				pruneItem.FilePath = name;
				break;
			}
		}

		private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
		{
			for (int index = 0; index < _files.Count; index++)
			{
				var pruneItem = _files[index];
				if (!pruneItem.FilePath.Equals(e.FullPath)) continue;
				_files.Remove(pruneItem);
				break;
			}
		}

		private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
		{
			_files.Add(new PruneItem(e.FullPath));
		}
		#endregion File System Watcher
	}


	class PruneItem
	{
		public string Name => Path.GetFileNameWithoutExtension(FilePath);
		
		public string Active { get; set; }

		public string FilePath;

		public PruneItem(string path, bool active = false)
		{
			FilePath = path;
			Active = active.ToString();
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
