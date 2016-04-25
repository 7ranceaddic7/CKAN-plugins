using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Windows.Forms;
using CKAN;

namespace PartsPrunerPlugin
{
	public partial class PartPrunerUi : UserControl
	{
		#region Consts

		private readonly string _prunerDirectory = Path.Combine(Main.Instance.CurrentInstance.GameDir(), "PRNLs");

		#endregion Consts


		public PartPrunerUi()
		{
			InitializeComponent();
		}

		private void PartPrunerUI_Load(object sender, EventArgs e)
		{
			if (!Directory.Exists(_prunerDirectory))
				LogWarning("No 'PRNLs' folder was not found!");

			//PopulateFileList();
			InitializeFileWatcher();
		}


		#region Console Logging

		delegate void SetTextCallback(string text);

		private void Log(String line)
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

		private void LogWarning(String line)
		{
			LogAddLine("Warning:");
			LogAddLine("\t" + line);
			LogAddLine(Environment.NewLine);
		}

		private void LogError(String line)
		{
			LogAddLine("Error:");
			LogAddLine("\t" + line);
			LogAddLine(Environment.NewLine);
		}

		private void LogNewEntry()
		{
			LogAddLine(Environment.NewLine);
			LogAddLine("==================================================");
			LogAddLine(Environment.NewLine);
			LogAddLine(Environment.NewLine);
		}

		private void LogAddLine(String line)
		{
			tbLog.AppendText(line);
		}

		#endregion Console Logging


		#region Pruner - Left Side

			/// <summary>
			/// Get and list all files from the PRNLs directory
			/// </summary>
			private void PopulateFileList()
			{
				if (!Directory.Exists(_prunerDirectory)) return;

				var files = Directory.GetFiles(_prunerDirectory, "*.prnl");

				foreach (var file in files)
					prunerLbFileList.Items.Add(Path.GetFileNameWithoutExtension(file));
			}

			/// <summary>
			/// Returns a list of file paths to the selected pruner files
			/// </summary>
			/// <returns></returns>
			private IEnumerable<string> GetSelectedFiles()
			{
				var itemsList = prunerLbFileList.SelectedItems.Cast<string>().ToList();
				var dirFileList = Directory.GetFiles(_prunerDirectory);

				if (itemsList.Count == 0)
					Log("No files selected.");

				return dirFileList.Where(file => itemsList.Contains(Path.GetFileNameWithoutExtension(file))).ToArray();
			}

			/// <summary>
			/// Returns a full file path as relative to GameData directory
			/// </summary>
			/// <param name="path">Full file path to reduce</param>
			/// <returns></returns>
			private String GetGameDataPath(String path)
			{
				var splits = new string[] {@"GameData" + Path.DirectorySeparatorChar};
				var parts = path.Split(splits, StringSplitOptions.None);
				return @"GameData\" + parts[1];
			}


			#region Pruner

			/// <summary>
			/// Takes a list of file and directory paths and adds the .prune extension to all contained files
			/// </summary>
			/// <param name="filesList">List of file and directory paths</param>
			private void PruneFiles(IEnumerable<string> filesList)
			{
				foreach (var file in filesList)
				{
					var pathsInFile = new List<string>();

					using (var r = new StreamReader(file))
					{
						string line;
						while ((line = r.ReadLine()) != null)
							pathsInFile.Add(line);
					}

					foreach (var filePath in pathsInFile)
					{
						if ((filePath[0] == '#') || (string.IsNullOrEmpty(filePath)))
							continue;

						var path = Path.Combine(Main.Instance.CurrentInstance.GameData(), filePath);


						if (File.Exists(path))
							PruneFile(path);

						else if (Directory.Exists(path))
							PruneDirectory(path);

						else
							LogWarning("\"" + GetGameDataPath(path) + "\" is not a file or a directory.");

					}
				}
			}

			private void PruneDirectory(string path)
			{
				try
				{
					Log("Pruning files from " + GetGameDataPath(path));
					var files = Directory.GetFiles(path).ToList();
					files.AddRange(Directory.GetDirectories(path));

					foreach (var file in files)
					{
						if (File.Exists(file))
							PruneFile(file);
						else if (Directory.Exists(file))
							PruneDirectory(file);
					}
				}
				catch (IOException ex)
				{
					LogError(ex.ToString());
				}

			}

			private void PruneFile(string file)
			{
				try
				{
					File.Move(file, file + ".prune");
					Log("Pruned: " + GetGameDataPath(file));
				}
				catch (IOException ex)
				{
					LogError(ex.ToString());
				}
			}

			#endregion Pruner


			#region Unpruner

			/// <summary>
			/// Takes a list of file and directory paths and removes the .prune extension from all contained files
			/// </summary>
			/// <param name="filesList">List of file and directory paths</param>
			private void UnpruneFiles(IEnumerable<string> filesList)
			{
				foreach (var file in filesList)
				{
					var pathsInFile = new List<string>();

					using (var r = new StreamReader(file))
					{
						string line;
						while ((line = r.ReadLine()) != null)
							pathsInFile.Add(line);
					}

					foreach (var filePath in pathsInFile)
					{
						var prunefile = Path.Combine(Main.Instance.CurrentInstance.GameData(), filePath + ".prune");
						var path = Path.Combine(Main.Instance.CurrentInstance.GameData(), filePath);

						if (File.Exists((prunefile)))
							path += ".prune";

						if (File.Exists(path))
							UnpruneFile(path);

						else if (Directory.Exists(path))
							UnpruneDirectory(path);

						else
							LogWarning("\"" + GetGameDataPath(path) + "\" is not a file or a directory.");

					}
				}
			}

			private void UnpruneDirectory(string path)
			{
				try
				{
					Log("Unpruning files from " + GetGameDataPath(path));
					var files = Directory.GetFiles(path).ToList();
					files.AddRange(Directory.GetDirectories(path));

					foreach (var file in files)
					{
						if (File.Exists(file))
							UnpruneFile(file);
						else if (Directory.Exists(file))
							UnpruneDirectory(file);
					}
				}
				catch (IOException ex)
				{
					LogError(ex.ToString());
				}

			}

			private void UnpruneFile(string file)
			{
				try
				{
					var newFile = file.Replace(".prune", "");
					File.Move(file, newFile);
					Log("Unpruned: " + GetGameDataPath(file));
				}
				catch (IOException ex)
				{
					LogError(ex.ToString());
				}
			}

			#endregion Unpruner


			#region Buttons

			private void pruneBtnPruneAll_Click(object sender, EventArgs e)
			{
				LogNewEntry();
				var filesList = Directory.GetFiles(_prunerDirectory);
				PruneFiles(filesList);
			}

			private void pruneBtnPruneSelected_Click(object sender, EventArgs e)
			{
				LogNewEntry();
				PruneFiles(GetSelectedFiles());
			}

			private void pruneBtnUnpruneAll_Click(object sender, EventArgs e)
			{
				LogNewEntry();
				var filesList = Directory.GetFiles(_prunerDirectory);
				UnpruneFiles(filesList);
			}

			private void pruneBtnUnpruneSelected_Click(object sender, EventArgs e)
			{
				LogNewEntry();
				UnpruneFiles(GetSelectedFiles());
			}

			private void pruneBtnRescanFolder_Click(object sender, EventArgs e)
			{
				prunerLbFileList.Items.Clear();
				PopulateFileList();
			}

			private void pruneBtnEdit_Click(object sender, EventArgs e)
			{
				var path = Path.Combine(_prunerDirectory, prunerLbFileList.SelectedItem.ToString() + ".prnl");
				try
				{
					using (var sr = new StreamReader(path))
					{
						createLbFiles.Items.Clear();
						var line = "";
						while ((line = sr.ReadLine()) != null)
							createLbFiles.Items.Add(line);
					}
				}
				catch (Exception ex)
				{
					LogError("Could not open " + GetGameDataPath(path));
				}
			}

			#endregion Buttons


			private void prunerLbFileList_KeyDown(object sender, KeyEventArgs e)
			{
				// Select all items on Ctrl+A
				if (e.KeyData == (Keys.A | Keys.Control))
					for (int i = 0; i < prunerLbFileList.Items.Count; i++)
						prunerLbFileList.SetSelected(i, true);

			}

			private void prunerLbFileList_Click(object sender, EventArgs e)
		{
			prunerBtnEdit.Enabled = false;
			if (prunerLbFileList.SelectedItems.Count == 1)
				prunerBtnEdit.Enabled = true;
		}

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

				using (var sw = new StreamWriter(saveFileDialog1.FileName, true))
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

		readonly BindingList<string> _files = new BindingList<string>();

		private void InitializeFileWatcher()
		{
			fileSystemWatcher1.Path = _prunerDirectory;

			foreach (string file in Directory.GetFiles(fileSystemWatcher1.Path, "*.prnl"))
				_files.Add(Path.GetFileNameWithoutExtension(file));

			prunerLbFileList.DataSource = _files;
		}

		private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
		{
			var name = Path.GetFileNameWithoutExtension(e.Name);
			var oldname = Path.GetFileNameWithoutExtension(e.OldName);
            _files[_files.IndexOf(oldname)] = name;
		}

		private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
		{
			var name = Path.GetFileNameWithoutExtension(e.Name);
			_files.Remove(name);
		}

		private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
		{
			var name = Path.GetFileNameWithoutExtension(e.Name);
			_files.Add(name);
		}

		#endregion File System Watcher


	}
}
