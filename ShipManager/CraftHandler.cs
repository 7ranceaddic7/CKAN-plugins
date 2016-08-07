using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CKAN;

namespace ShipManagerPlugin
{
	public enum SaveType
	{
		Save,
		Hangar,
		Stock
	}

	class CraftHandler
	{
		public List<CraftInfo> Crafts { get; } = new List<CraftInfo> ();

		public List<string> Saves { get; } = new List<string>();

		public ImageList SmallImageList;
		public ImageList LargeImageList;

		public bool OverwriteFiles = false;



		public CraftHandler()
		{
			SmallImageList = new ImageList
			{
				ImageSize = new Size(64, 64),
				ColorDepth = ColorDepth.Depth32Bit,
				TransparentColor = Color.Transparent
			};

			LargeImageList = new ImageList
			{
				ImageSize = new Size(128, 128),
				ColorDepth = ColorDepth.Depth32Bit,
				TransparentColor = Color.Transparent
			};

			GetAllCraftFromSaves();
			GetAllCraftFromHangar();
		}

		/// <summary>
		/// Copies a list of Craft Info to a folder. SaveType determes the folder, where Hangar is the defined plugin Hangar folder
		/// and Save is the save file passed in by the optional parameter.
		/// </summary>
		/// <param name="craftsToCopy">List of CraftInfo to copy</param>
		/// <param name="saveType">Type of save being copied into</param>
		/// <param name="save">Optional name of a save to copy into</param>
		public void CopyCraftToSave(List<CraftInfo> craftsToCopy, SaveType saveType, string save = null)
		{
			if (saveType == SaveType.Hangar)
			{
				foreach (CraftInfo craft in craftsToCopy)
					CopyExistingCraft(Util.FolderNameHangar, craft);
			}
			else if (saveType == SaveType.Save && save != null)
			{
				foreach (CraftInfo craft in craftsToCopy)
					CopyExistingCraft(save, craft);
			}	
		}

		/// <summary>
		/// Takes a list of file paths and turns them into craft infos and copies them into the given save
		/// </summary>
		/// <param name="filePaths">List of paths to files</param>
		/// <param name="save">Save folder name to copy files to</param>
		public void CopyNewCraftToSave(List<string> filePaths, string save)
		{
			foreach (var path in filePaths)
				CopyNewCraft(save, path);
		}

		/// <summary>
		///  Deletes a craft info and its file system file
		/// </summary>
		/// <param name="craftsInfos">List of craft info to delete</param>
		public void DeleteCraft(IList craftsInfos)
		{
			List<CraftInfo> toDelete = new List<CraftInfo>();
			foreach (var craft in craftsInfos)
			{
				toDelete.Add(craft as CraftInfo);
				File.Delete((craft as CraftInfo).FilePath);
			}

			foreach (var craftInfo in toDelete)
			{
				RemoveCraft(craftInfo);
			}
		}

		/// <summary>
		/// Returns a list of CraftInfo from the given save
		/// </summary>
		/// <param name="saveName"></param>
		/// <returns></returns>
		public List<CraftInfo> GetCraftInfosFromSave(string saveName)
		{
			return Crafts.Where(craft => craft.SaveName.Equals(saveName)).ToList();
		}

		/// <summary>
		/// Clears all lists and reloads files from the disk
		/// </summary>
		public void Reload()
		{
			Crafts.Clear();
			Saves.Clear();
			GetAllCraftFromSaves();
			GetAllCraftFromHangar();
		}


		/// <summary>
		/// Loads all craft from the saves folders.
		/// </summary>
		private void GetAllCraftFromSaves()
		{
			foreach (var saveFolder in Directory.GetDirectories(Util.SaveDir, "*", SearchOption.TopDirectoryOnly))
			{
				string[] craftFiles;
				bool loaded = false;

				var subassembliesFolder = Path.Combine(saveFolder, "Subassemblies");
				if (Directory.Exists(subassembliesFolder))
				{
					craftFiles = Directory.GetFiles(subassembliesFolder, "*.craft", SearchOption.AllDirectories);
					GetCraftInFolder(craftFiles);
					loaded = true;
				}

				var shipFolder = Path.Combine(saveFolder, "Ships");
				if (Directory.Exists(shipFolder))
				{
					craftFiles = Directory.GetFiles(shipFolder, "*.craft", SearchOption.AllDirectories);
					GetCraftInFolder(craftFiles);
					loaded = true;
				}

				if (loaded) Saves.Add(Path.GetFileNameWithoutExtension(saveFolder));
			}
		}

		/// <summary>
		/// Loads all the craft stored in the Hangar folder.
		/// </summary>
		private void GetAllCraftFromHangar()
		{
			Saves.Add(Util.FolderNameHangar);
			var craftFiles = Directory.GetFiles(Util.HangarDir, "*.craft", SearchOption.AllDirectories);
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
		/// Adds thumbnail images for each craft to the imageLists and adds the craft to the crafts list.
		/// </summary>
		/// <param name="craft"></param>
		private void AddCraft(CraftInfo craft)
		{
			Crafts.Add(craft);
			SmallImageList.Images.Add(craft.ThumbName, craft.Thumb);
			LargeImageList.Images.Add(craft.ThumbName, craft.Thumb);
		}

		/// <summary>
		/// Removes a craft and its related info
		/// </summary>
		/// <param name="craft"></param>
		private void RemoveCraft(CraftInfo craft)
		{
			Crafts.Remove(craft);
			//olvCraftList.SmallImageList.Images.Remove(craft.Thumb);
			//olvCraftList.LargeImageList.Images.Remove(craft.Thumb);
		}

		/// <summary>
		/// Copies an existing craft file from one folder to another, checking if the file exists and
		/// overwriting or renaming as necessary depending on settings. Copies and renames thumbnail to match new craft.
		/// </summary>
		/// <param name="targetSave">Folder name of the save to copy into.</param>
		/// <param name="sourceCraft">CraftInfo of the craft file to be copied.</param>
		private void CopyExistingCraft(string targetSave, CraftInfo sourceCraft)
		{
			// In the event that multiple files are selected from multiple saves, ensure that
			// files from the current save aren't copied into themselves.
			if (sourceCraft.SaveName.Equals(targetSave)) return;

			try
			{
				// If the target save is the Hangar, build the correct folder path, otherwise build from the craftInfo
				var destinationFolder = Path.Combine(Util.GetPathToShipsFolder(targetSave), sourceCraft.Building);

				var destinationPath = CopyCraftCheck(sourceCraft, destinationFolder);

				// Create new craft model for the new location
				var ci = new CraftInfo(destinationPath);

				// Copy the existing thumbnail and rename it for the new save
				var thumbOld = Path.Combine(Util.ThumbsDir, sourceCraft.ThumbName);
				var thumbNew = Path.Combine(Util.ThumbsDir, ci.ThumbName);
				if (!File.Exists(thumbNew) && File.Exists(thumbOld))
				{
					File.Copy(thumbOld, thumbNew);
				}

				AddCraft(ci);
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
				CKAN.Main.Instance.AddLogMessage(ex.Message);
			}
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
				CraftInfo craftData = new CraftInfo(sourceCraftPath);
				CraftInfo.GetCraftInfo(craftData, sourceCraftPath);

				// If the target save is the Hangar, build the correct folder path, otherwise build from the craftInfo
				var destinationFolder = Path.Combine(Util.GetPathToShipsFolder(targetSave), craftData.Building);

				var destinationPath = CopyCraftCheck(craftData, destinationFolder);

				var ci = new CraftInfo(destinationPath);
				AddCraft(ci);
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
				CKAN.Main.Instance.AddLogMessage(ex.Message);
			}
		}

		/// <summary>
		/// Copies a source file to a destination file, checking overwrite rules and renaming as necessary
		/// </summary>
		/// <param name="sourceCraft">CraftInfo of source craft.</param>
		/// <param name="destinationFolder">Folder path of destination save.</param>
		private string CopyCraftCheck(CraftInfo sourceCraft, string destinationFolder)
		{
			// If allowed to overwrite, job is easy
			if (OverwriteFiles)
			{
				var destination = Path.Combine(destinationFolder, sourceCraft.FileName);
				File.Copy(sourceCraft.FilePath, destination, true);
				return destination;
			}

			// Get the base filename of the craft, its extension, and the new full path of destination.
			// While new full path exists, append count value to path and check again.
			// When filename doesn't exist, rename file
			int count = 1;
			string fileNameOnly = Path.GetFileNameWithoutExtension(sourceCraft.FileName);
			string extension = Path.GetExtension(sourceCraft.FileName);
			string newFullPath = Path.Combine(destinationFolder, sourceCraft.FileName);

			while (File.Exists(newFullPath))
			{
				string tempFileName = string.Format("{0}_{1}", fileNameOnly, count++);
				newFullPath = Path.Combine(destinationFolder, tempFileName + extension);
			}
			File.Copy(sourceCraft.FilePath, newFullPath, false);
			return newFullPath;
		}


	}
}
