using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace ShipManagerPlugin
{
	public partial class PluginUi : UserControl
	{
		private readonly CraftHandler _craftFileHandler = new CraftHandler();

		public PluginUi()
		{
			InitializeComponent();
			
			cbDefaultSave.DataSource = _craftFileHandler.Saves;		// Binds the saves list to the save selection
			cbListView.SelectedIndex = 0;   // Sets the view selection comboBox to the tile view option

			// Get the ship thumbnail to show as the image for the CraftName column
			olvcShipName.ImageGetter += rowObject => ((CraftInfo) rowObject).ThumbName;

			// Create drag and drop source and sink
			olvCraftList.DragSource = new SimpleDragSource(true);
			olvCraftList.DropSink = new SimpleDropSink
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
		private void PluginUI_Load(object sender, EventArgs e)
		{

			// Create hanger directories if they don't exist
			if (!Directory.Exists(Util.HangarDir)) Directory.CreateDirectory(Util.HangarDir);
			if (!Directory.Exists(Util.HangarSubDir)) Directory.CreateDirectory(Util.HangarSubDir);
			if (!Directory.Exists(Path.Combine(Util.HangarDir, "VAB"))) Directory.CreateDirectory(Path.Combine(Util.HangarDir, "VAB"));
			if (!Directory.Exists(Path.Combine(Util.HangarDir, "SPH"))) Directory.CreateDirectory(Path.Combine(Util.HangarDir, "SPH"));

			olvCraftList.SmallImageList = _craftFileHandler.SmallImageList;
			olvCraftList.LargeImageList = _craftFileHandler.LargeImageList;
			olvCraftList.SetObjects(_craftFileHandler.Crafts);
			olvCraftList.BuildList();
		}

		

		/// <summary>
		/// Updates the ObjectListView's object set and tells it to redraw.
		/// </summary>
		private void UpdateList()
		{
			olvCraftList.BuildList();
		}


		#region Events
		private void cbListView_SelectedIndexChanged(object sender, EventArgs e)
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
			if (button == rbBuildingSubs && button.Checked)
				TimedFilter(olvCraftList, "None");
		}

		private void tbFilter_TextChanged(object sender, EventArgs e)
		{
			TimedFilter(olvCraftList, tbFilter.Text);
		}

		private void rbFileAction_CheckedChanged(object sender, EventArgs e)
		{
			_craftFileHandler.OverwriteFiles = (sender as RadioButton).Checked;
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			_craftFileHandler.Reload();
			UpdateList();
		}

		private void btnTransfer_Click(object sender, EventArgs e)
		{
			_craftFileHandler.CopyCraftToSave(_craftFileHandler.GetCraftInfosFromSave("Hangar"), SaveType.Save, cbDefaultSave.Text);
			UpdateList();
		}

		/// <summary>
		/// Sets right click menu when clicking on a list item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void olvCraftList_CellRightClick(object sender, CellRightClickEventArgs e)
		{
			if (e.Model != null)
				e.MenuStrip = cmsShip;
			else
				e.MenuStrip = cmsList;
		}
		#endregion Events


		#region Context Menu Events
		private void copyToHangarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (olvCraftList.SelectedObjects.Count == 0) return;
			_craftFileHandler.CopyCraftToSave(olvCraftList.SelectedObjects as List<CraftInfo>, SaveType.Hangar);
			UpdateList();
		}

		private void copyToSaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (olvCraftList.SelectedObjects.Count == 0) return;
			_craftFileHandler.CopyCraftToSave(olvCraftList.SelectedObjects as List<CraftInfo>, SaveType.Hangar, cbDefaultSave.Text);
			UpdateList();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (olvCraftList.SelectedObjects.Count == 0) return;

			if (MessageBox.Show("Delete all selected ships?\n\nThis cannot be undone!", "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				_craftFileHandler.DeleteCraft(olvCraftList.SelectedObjects);
			}
			UpdateList();
		}
		
		private void collapseAllGroupsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (var olvGroup in olvCraftList.OLVGroups)
				olvGroup.Collapsed = true;
		}

		private void expandAllGroupsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (var olvGroup in olvCraftList.OLVGroups)
				olvGroup.Collapsed = false;
		}
		#endregion Context Menu Events


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

		/// <summary>
		/// Handles dropping items from the list view on other items in the list view
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void olvCraftList_ModelDropped(object sender, ModelDropEventArgs e)
		{
			if (e.TargetModel == null) return;

			_craftFileHandler.CopyCraftToSave(e.SourceModels as List<CraftInfo>, SaveType.Save, (e.TargetModel as CraftInfo).SaveName);
			UpdateList();
		}

		/// <summary>
		/// Shows when an object can and cannot be dropped in the list view
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void olvCraftList_CanDrop(object sender, OlvDropEventArgs e)
		{
			// If object is a file, allow copy
			if (e.DragEventArgs.Data.GetDataPresent(DataFormats.FileDrop, false))
				e.Effect = DragDropEffects.Copy;
		}

		/// <summary>
		/// Handles when external files are dropped into the list view
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void olvCraftList_Dropped(object sender, OlvDropEventArgs e)
		{
			if (!e.DragEventArgs.Data.GetDataPresent(DataFormats.FileDrop, false)) return;

			// File system list of paths of files dropped into the list view
			var files = ((string[])e.DragEventArgs.Data.GetData(DataFormats.FileDrop)).ToList();

			_craftFileHandler.CopyNewCraftToSave(files, cbDefaultSave.Text);
			UpdateList();
		}
		#endregion Drop Events


		#region Group Events
		private void olvCraftList_GroupTaskClicked(object sender, GroupTaskClickedEventArgs e)
		{

		}

		private void olvCraftList_GroupStateChanged(object sender, GroupStateChangedEventArgs e)
		{

		}

		private void olvCraftList_GroupExpandingCollapsing(object sender, GroupExpandingCollapsingEventArgs e)
		{
			
		}
		#endregion Group Events


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
	}
}
