using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CKAN;
using KerbalParser;
using Newtonsoft.Json;
using PartEditorPlugin.KerbalParser;

/* 
A list of mods and the parts contained in that mod. Select a part to edit and open the edit tab.
User edits the file however they like, and clicks save (validate file at this point?).
	Save a copy of the original unedited file into a backup location, then save the changes to the original file
	Save a copy of the modified file to a separate backup location.

When a mod is updated, the file in GameData is overwritten. During the update event, the new file is compared to the edited file.
	If the files are different, then possibly propogate those changes into the new file, compare as nodes (config files are essentially json)
	and update the node values only. Flag changed files with a colored background to alert the user to which files have been modified so they
	can verify changes.
	Verified files will have their new versions saved and then be modified, same as first edit.


Extras:
	Generate MM config files for edits instead of editing the files directly. This is probably the better approach in the long run but will require more work

	Module Manager view of how files look to the game instead of just how they look in the folder. Lots of mods modify a lot of parts at start
	which leads to some changes possibly overriding the user changes made without that knowledge.

	Totally unrelated but want it written. A viewer for the tech tree with all parts listed for each node. Preferably draw it like the game
	does. Allow parts to be dragged and dropped between nodes to rearrange, creating a MM config to modify them all. Be aware of tech tree
	mods, at least the MM compatible ones.
*/

namespace PartEditorPlugin
{
	public partial class PartEditorUi : UserControl
	{
		private const string ConfigPath = "PartEditor/PartEditor.json";

		private readonly Dictionary<string, KerbalConfig> _mDisabledParts = new Dictionary<string, KerbalConfig>();

		private readonly Dictionary<string, Dictionary<string, KerbalConfig>> _allMods =
		new Dictionary<string, Dictionary<string, KerbalConfig>>();

		private readonly Dictionary<string, KerbalConfig> _allParts =
		new Dictionary<string, KerbalConfig>();



		public PartEditorUi()
		{
			InitializeComponent();
		}


		private void LoadConfig()
		{
			var fullPath = Path.Combine(Main.Instance.CurrentInstance.CkanDir(), ConfigPath);
			if (!File.Exists(fullPath))
				return;

			var partEditorPath = Path.Combine(Main.Instance.CurrentInstance.CkanDir(), "PartEditor");
			if (!Directory.Exists(partEditorPath))
				Directory.CreateDirectory(partEditorPath);

			var cachePath = Path.Combine(partEditorPath, "cache");
			if (!Directory.Exists(cachePath))
				Directory.CreateDirectory(cachePath);

			var json = File.ReadAllText(fullPath);
			var config = JsonConvert.DeserializeObject<PartEditorConfig>(json);
			//foreach (var item in config.EditedParts)
				//_mDisabledParts.Add(item.Key, ConfigNodeReader.FileToConfigNode(Path.Combine(cachePath, item.Key)));
		}


		public void OnModChanged(CkanModule module, GUIModChangeType changeType)
		{
			if (changeType == GUIModChangeType.Update || changeType == GUIModChangeType.Install)
			{
				// Todo: logic that will handle an updated mod, check all of its part files against the modified versions and propogate the changes if it can or alert the user if it can't.
			}
		}


		/// <summary>
		/// Gets a list of all mod folders in GameData, then loads each .cfg file
		/// and parses it.
		/// </summary>
		private void RefreshInstalledModsList()
		{
			// Get GameData Directory
			var gameData = new DirectoryInfo(Main.Instance.CurrentInstance.GameData());

			var parser = new Parser(false, true);
			
			// Go through each folder in GameData
			foreach (var mod in gameData.GetDirectories("*", SearchOption.TopDirectoryOnly))
			{
				var parts = new Dictionary<string, KerbalConfig>();

				// Get all of the .cfg files from this folder
				foreach (var part in mod.GetFiles("*.cfg", SearchOption.AllDirectories))
				{
					try
					{
						// Create a hash of the file name, unique storage in dictionary
						// Add parsed file to dictionary
						var hash = part.GetHashCode() + ":" + part.Name;
						parts.Add(hash, parser.ParseConfig(part.FullName));
					}
					catch (ParseErrorException ex)
					{
						Console.WriteLine("Error on parse " + part.Name + " " + ex);
						CKAN.Main.Instance.AddLogMessage("PartEditor: Error on parse " + part.Name + " " + ex);
					}
					catch (ArgumentException ex)
					{
						Console.WriteLine("Error on " + part.Name + " " + ex);
						CKAN.Main.Instance.AddLogMessage("PartEditor: Error on " + part.Name + " " + ex);
					}
				}

				if (parts.Count == 0) continue;

				// Add this parts list to the list containing lists of all mods
				// and then move all parts into the "all parts" list
				_allMods.Add(mod.Name, parts);
				
				foreach (var part1 in parts)
				{
					if (!_allParts.ContainsKey(part1.Key))
						_allParts.Add(part1.Key, part1.Value);
				}
			}

			foreach (var key in _allMods.Keys)
			{
				listBox1.Items.Add(key);
			}

			foreach (var key in _allParts.Keys)
			{
				listBox2.Items.Add(key);
			}


		}

		private Dictionary<string, KerbalConfig> GetInstalledModParts(string identifier)
		{
			var registry = Main.Instance.CurrentInstance.Registry;
			var module = registry.InstalledModule(identifier);

			if (module == null)
				return null;

			var parser = new Parser(false, true);

			var parts = new Dictionary<string, KerbalConfig>();

			foreach (var item in module.Files)
			{
				parts.Add(item, parser.ParseConfig(item));
			}



			//foreach (var item in module.Files)
			//{
			//	if (_mDisabledParts.ContainsKey(item))
			//	{
			//		parts.Add(item, _mDisabledParts[item]);
			//		continue;
			//	}

			//	var filename = Path.GetFileName(item);

			//	if (filename != null && !filename.EndsWith(".cfg")) continue;

			//	var configNode = LoadPart(item);
			//	if (configNode != null)
			//		parts.Add(item, configNode);
			//}

			return parts;
		}

		//private KerbalNode LoadPart(string part)
		//{
		//	var kspDir = Main.Instance.CurrentInstance.GameDir();
		//	var fullPath = Path.Combine(kspDir, part);
		//	if (!File.Exists(fullPath))
		//	{
		//		var partEditorPath = Path.Combine(Main.Instance.CurrentInstance.CkanDir(), "PartManager");
		//		var cachePath = Path.Combine(partEditorPath, "cache");
		//		fullPath = Path.Combine(cachePath, part);
		//		if (!File.Exists(fullPath))
		//			return null;
		//	}

		//	var configNode = ConfigNodeReader.FileToConfigNode(fullPath);
		//	return configNode;
		//}






		private void PartEditorUI_Load(object sender, EventArgs e)
		{
			//LoadConfig();
			RefreshInstalledModsList();
		}

		private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			var key = listBox2.GetItemText(listBox2.SelectedItem);
			var item = _allParts[key];

			richTextBox1.Clear();
			foreach (var kerbalNode in item.Nodes)
			{
				richTextBox1.AppendText(kerbalNode.ToString());
			}
		}
	}
}







//namespace PartEditorPlugin
//{
//	public partial class PartEditorUi : UserControl
//	{
//		private const string ConfigPath = "PartEditor/PartEditor.json";

//		private readonly Dictionary<string, ConfigNode> _mDisabledParts = new Dictionary<string, ConfigNode>();



//		public PartEditorUi()
//		{
//			InitializeComponent();
//		}


//		private void LoadConfig()
//		{
//			var fullPath = Path.Combine(Main.Instance.CurrentInstance.CkanDir(), ConfigPath);
//			if (!File.Exists(fullPath))
//				return;

//			var partEditorPath = Path.Combine(Main.Instance.CurrentInstance.CkanDir(), "PartEditor");
//			if (!Directory.Exists(partEditorPath))
//				Directory.CreateDirectory(partEditorPath);

//			var cachePath = Path.Combine(partEditorPath, "cache");
//			if (!Directory.Exists(cachePath))
//				Directory.CreateDirectory(cachePath);

//			var json = File.ReadAllText(fullPath);
//			var config = (PartEditorConfig)JsonConvert.DeserializeObject<PartEditorConfig>(json);
//			foreach (var item in config.EditedParts)
//				_mDisabledParts.Add(item.Key, ConfigNodeReader.FileToConfigNode(Path.Combine(cachePath, item.Key)));
//		}


//		public void OnModChanged(CkanModule module, GUIModChangeType changeType)
//		{
//			if (changeType == GUIModChangeType.Update || changeType == GUIModChangeType.Install)
//			{
//				// Todo: logic that will handle an updated mod, check all of its part files against the modified versions and propogate the changes if it can or alert the user if it can't.
//			}
//		}


//		private void RefreshInstalledModsList()
//		{
//			var installedMods = Main.Instance.CurrentInstance.Registry.Installed();

//			//InstalledModsListBox.Items.Clear();

//			foreach (var mod in installedMods)
//			{
//				var parts = GetInstalledModParts(mod.Key);
//				//if (parts != null && parts.Any())
//					//InstalledModsListBox.Items.Add(String.Format("{0} | {1}", mod.Key, mod.Value));
//			}
//		}

//		private Dictionary<string, ConfigNode> GetInstalledModParts(string identifier)
//		{
//			var registry = Main.Instance.CurrentInstance.Registry;
//			var module = registry.InstalledModule(identifier);

//			if (module == null)
//				return null;

//			var parts = new Dictionary<string, ConfigNode>();

//			foreach (var item in module.Files)
//			{
//				if (_mDisabledParts.ContainsKey(item))
//				{
//					parts.Add(item, _mDisabledParts[item]);
//					continue;
//				}

//				var filename = Path.GetFileName(item);

//				if (filename != null && !filename.EndsWith(".cfg")) continue;

//				var configNode = LoadPart(item);
//				if (configNode != null)
//					parts.Add(item, configNode);
//			}

//			return parts;
//		}

//		private ConfigNode LoadPart(string part)
//		{
//			var kspDir = Main.Instance.CurrentInstance.GameDir();
//			var fullPath = Path.Combine(kspDir, part);
//			if (!File.Exists(fullPath))
//			{
//				var partEditorPath = Path.Combine(Main.Instance.CurrentInstance.CkanDir(), "PartManager");
//				var cachePath = Path.Combine(partEditorPath, "cache");
//				fullPath = Path.Combine(cachePath, part);
//				if (!File.Exists(fullPath))
//					return null;
//			}

//			var configNode = ConfigNodeReader.FileToConfigNode(fullPath);
//			return configNode;
//		}






//		private void PartEditorUI_Load(object sender, EventArgs e)
//		{
//			LoadConfig();
//			RefreshInstalledModsList();
//		}
//	}
//}
