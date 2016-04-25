using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using CKAN;

namespace ShipManagerPlugin
{
	public partial class PluginUI : UserControl
	{
		private List<CraftInfo> _crafts = new List<CraftInfo>();

		private readonly List<string> _saves = new List<string>();

		private readonly string _saveDir = Path.Combine(Main.Instance.CurrentInstance.GameDir(), "saves");

		private readonly string _thumbsDir = Path.Combine(Main.Instance.CurrentInstance.GameDir(), "thumbs");

		private readonly string _hangarDir = Path.Combine(Main.Instance.CurrentInstance.CkanDir(), "ShipManager");

		private readonly string _hangerThumbsDir = Path.Combine(Main.Instance.CurrentInstance.CkanDir(), "ShipManager",
			"thumbs");


		public PluginUI()
		{
			InitializeComponent();

			// Create hanger directories if they don't exist
			if (!Directory.Exists(_hangarDir))
			{
				Directory.CreateDirectory(_hangarDir);
				Directory.CreateDirectory(_hangerThumbsDir);
				Directory.CreateDirectory(Path.Combine(_hangarDir, "Hangar", "Ships", "VAB"));
				Directory.CreateDirectory(Path.Combine(_hangarDir, "Hangar", "Ships", "SPH"));
			}

			// Sets the view selection comboBox to the tile view option
			cbListView.SelectedIndex = 0;

			// Get the ship thumbnail to show as the image for the CraftName column
			olvcShipName.ImageGetter += rowObject => ((CraftInfo) rowObject).ThumbName;

			// Override the default renderer so we don't get highlighted text
			olvCraftList.DefaultRenderer = new HighlightTextRenderer
			{
				FillBrush = null,
				FramePen = null
			};

			// Create drag and drop source and sink
			olvCraftList.DragSource = new SimpleDragSource(true);
			olvCraftList.DropSink = new SimpleDropSink()
			{
				CanDropOnItem = true,
				FeedbackColor = Color.DarkOliveGreen,
				AcceptExternal = false,
				CanDropOnBackground = true
			};

			// Force sort by SaveName, but allow the vessel CraftName to be the primary value
			olvCraftList.SortGroupItemsByPrimaryColumn = false;
			olvCraftList.LastSortColumn = olvcSaveName;
		}

		/// <summary>
		/// Runs when user control loads for the first time, fetches data from folders and populates UI
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PluginUI_Load(object sender, System.EventArgs e)
		{
			GetAllCraftFromSaves();
			GetAllCraftFromHangar();
			olvCraftList.SetObjects(_crafts);
		}


		/// <summary>
		/// Loads all craft from the saves folders.
		/// </summary>
		private void GetAllCraftFromSaves()
		{
			foreach (var saveFolder in Directory.GetDirectories(_saveDir, "*", SearchOption.TopDirectoryOnly))
			{
				var shipFolder = Path.Combine(saveFolder, "Ships");
				if (!Directory.Exists(shipFolder)) continue;

				// Get all the craft file from a save
				var craftFiles = Directory.GetFiles(shipFolder, "*.craft", SearchOption.AllDirectories);

				_saves.Add(Path.GetFileNameWithoutExtension(saveFolder));
				GetCraftInFolder(craftFiles);
				// G:\Games\Kerbal Space Program\Kerbal Space Program\saves\SaveName\Ships\*
			}
		}

		/// <summary>
		/// Loads all the craft stored in the Hangar folder.
		/// </summary>
		private void GetAllCraftFromHangar()
		{
			_saves.Add("Hangar");
			var craftFiles = Directory.GetFiles(_hangarDir, "*.craft", SearchOption.AllDirectories);
			GetCraftInFolder(craftFiles);
			// G:\Games\Kerbal Space Program\Kerbal Space Program\CKAN\ShipManager\*
		}

		/// <summary>
		/// Loads all craft files from a specific folder and adds them to the list view.
		/// </summary>
		/// <param name="craftFiles">Array of paths to craft files from a save.</param>		
		private void GetCraftInFolder(string[] craftFiles)
		{
			foreach (var craft in craftFiles)
			{
				CraftInfo ci = new CraftInfo(craft);
				AddCraft(ci);
			}
		}
		/// <summary>
		/// Copies an existing craft file from one save to another, copying the thumbnail if one exits.
		/// </summary>
		/// <param name="targetCraft">The drop target and destination of the copy.</param>
		/// <param name="sourceCraft">Craft to be copied.</param>
		private void CopyExistingCraft(CraftInfo targetCraft, CraftInfo sourceCraft)
		{
			// In the event that multiple files are selected from multiple saves, ensure that
			// files from the current save aren't copied into themselves.
			if (sourceCraft.SaveName.Equals(targetCraft.SaveName)) return;

			try
			{
				// Get the path where the file needs to be copied, putting together the target save name, the craft's building, and the source file name.
				var destinationPath = Path.Combine(GetPathToShipsFolder(targetCraft.SaveName), sourceCraft.Building, sourceCraft.FileName);
				File.Copy(sourceCraft.FilePath, destinationPath);

				// Create new craft model for the new location
				var ci = new CraftInfo(destinationPath);

				// Copy the existing thumbnail and rename it for the new save
				var thumbOld = Path.Combine(_thumbsDir, sourceCraft.ThumbName);
				var thumbNew = Path.Combine(_thumbsDir, ci.ThumbName);
				if (!File.Exists(thumbNew))
					File.Copy(thumbOld, thumbNew);

				AddCraft(ci);
			}
			catch (IOException ex)
			{ Console.WriteLine(ex.Message); }
		}

		/// <summary>
		/// Copies a craft file from a non-KSP folder into a given save folder.
		/// </summary>
		/// <param name="targetSave"></param>
		/// <param name="sourceCraftPath"></param>
		private void CopyNewCraft(string targetSave, string sourceCraftPath)
		{
			try
			{
				CraftInfo craftData = new CraftInfo();
				CraftInfo.GetCraftInfo(craftData, sourceCraftPath);

				var destinationPath = Path.Combine(GetPathToShipsFolder(targetSave), craftData.Building, craftData.FileName);
				File.Copy(destinationPath, sourceCraftPath);

				var ci = new CraftInfo(destinationPath);
				AddCraft(ci);
			}
			catch (IOException ex)
			{ Console.WriteLine(ex.Message); }
		}

		/// <summary>
		/// Adds thumbnail images for each craft to the imageLists and adds the craft to the crafts list.
		/// </summary>
		/// <param name="craft"></param>
		private void AddCraft(CraftInfo craft)
		{
			_crafts.Add(craft);
			olvCraftList.SmallImageList.Images.Add(craft.ThumbName, craft.Thumb);
			olvCraftList.LargeImageList.Images.Add(craft.ThumbName, craft.Thumb);
		}

		/// <summary>
		/// Takes a save name and returns a path to that save's 'Ships' folder.
		/// </summary>
		/// <param name="saveName"></param>
		/// <returns></returns>
		private string GetPathToShipsFolder(string saveName)
		{
			return Path.Combine(_saveDir, saveName, "ships");
		}

		/// <summary>
		/// Updates the ObjectListView's object set and tells it to redraw.
		/// </summary>
		private void UpdateList()
		{
			olvCraftList.SetObjects(_crafts);
			olvCraftList.Refresh();
		}


		private string ShowSavesSelectionDialog()
		{
			var dialog = new SaveSelection(_saves);
			dialog.ShowDialog(this);
			var saveTo = dialog.Value;
			dialog.Close();
			return saveTo;
		}


		#region Events
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbListView.SelectedIndex == 0) olvCraftList.View = View.Tile;
			else if (cbListView.SelectedIndex == 1) olvCraftList.View = View.Details;
		}

		private void rbBuilding_CheckedChanged(object sender, EventArgs e)
		{
			var button = (RadioButton) sender;

			if (button == rbBuildingAll && button.Checked)
				TimedFilter(olvCraftList, "");
			if (button == rbBuildingSPH && button.Checked)
				TimedFilter(olvCraftList, "SPH");
			if (button == rbBuildingVAB && button.Checked)
				TimedFilter(olvCraftList, "VAB");
		}

		private void tbFilter_TextChanged(object sender, EventArgs e)
		{
			TimedFilter(olvCraftList, tbFilter.Text);
		}
		#endregion Events


		#region Drop Events
		private void olvCraftList_ModelCanDrop(object sender, ModelDropEventArgs e)
		{
			CraftInfo craft = e.TargetModel as CraftInfo;

			if (craft == null)
				e.Effect = DragDropEffects.None;
			else
			{
				var count = e.SourceModels.Cast<object>().Count(model => craft.SaveName.Equals(((CraftInfo)model).SaveName));

				if (count > 0)
				{
					e.Effect = DragDropEffects.None;
					e.InfoMessage = "One or more of the selected craft are already in this group.";
				}
				else
					e.Effect = DragDropEffects.Move;
			}
		}

		private void olvCraftList_ModelDropped(object sender, ModelDropEventArgs e)
		{
			if (e.TargetModel == null)
				return;

			foreach (CraftInfo sourceModel in e.SourceModels)
				CopyExistingCraft(e.TargetModel as CraftInfo, sourceModel);
			UpdateList();
		}

		private void olvCraftList_CanDrop(object sender, OlvDropEventArgs e)
		{
			// If object is a file, allow copy
			if (e.DragEventArgs.Data.GetDataPresent(DataFormats.FileDrop, false))
				e.Effect = DragDropEffects.Copy;
		}

		private void olvCraftList_Dropped(object sender, OlvDropEventArgs e)
		{
			if (!e.DragEventArgs.Data.GetDataPresent(DataFormats.FileDrop, false))
				return;

			var saveTo = ShowSavesSelectionDialog();

			var files = (string[])e.DragEventArgs.Data.GetData(DataFormats.FileDrop);

			foreach (var file in files)
				CopyNewCraft(saveTo, file);
			UpdateList();
		}
		#endregion Drop Events


		#region ObjectListView Helpers
		// Code taken from ObjectListView Demo application
		public void TimedFilter(ObjectListView olv, string txt)
		{
			TimedFilter(olv, txt, 0);
		}

		public void TimedFilter(ObjectListView olv, string txt, int matchKind)
		{
			TextMatchFilter filter = null;
			if (!String.IsNullOrEmpty(txt))
			{
				switch (matchKind)
				{
					case 0:
					default:
						filter = TextMatchFilter.Contains(olv, txt);
						break;
					case 1:
						filter = TextMatchFilter.Prefix(olv, txt);
						break;
					case 2:
						filter = TextMatchFilter.Regex(olv, txt);
						break;
				}
			}

			olv.AdditionalFilter = filter;
		}
		#endregion ObjectListView Helpers

		private void btnTransfer_Click(object sender, EventArgs e)
		{
			var saveTo = ShowSavesSelectionDialog();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			_crafts = new List<CraftInfo>();
			GetAllCraftFromSaves();
			GetAllCraftFromHangar();
			olvCraftList.SetObjects(_crafts);
		}
	}
}
