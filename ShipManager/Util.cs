using System.IO;
using CKAN;

namespace ShipManagerPlugin
{
	// ReSharper disable InconsistentNaming
	internal class Util
	{
		public static string ShipManagerDir
		{
			get
			{
				if (!Directory.Exists(_shipManagerDir))
					Directory.CreateDirectory(_shipManagerDir);
				return _shipManagerDir;
			}
		}
		private static readonly string _shipManagerDir = Path.Combine(Main.Instance.CurrentInstance.CkanDir(), "ShipManager");

		public static string SaveDir
		{
			get
			{
				if (!Directory.Exists(_saveDir))
					Directory.CreateDirectory(_saveDir);
				return _saveDir;
			}
		}
		private static readonly string _saveDir = Path.Combine(Main.Instance.CurrentInstance.GameDir(), "saves");

		public static string HangarDir {
			get
			{
				if (!Directory.Exists(_hangarDir))
					Directory.CreateDirectory(_hangarDir);
				return _hangarDir;
			}
		} 
		private static readonly string _hangarDir = Path.Combine(Main.Instance.CurrentInstance.CkanDir(), "ShipManager", "Hangar",
			"Ships");

		public static string HangarSubDir {
			get
			{
				if (!Directory.Exists(_hagarSubDir))
					Directory.CreateDirectory(_hagarSubDir);
				return _hagarSubDir;
			}
		} 
		private static readonly string _hagarSubDir = Path.Combine(Main.Instance.CurrentInstance.CkanDir(), "ShipManager",
			"Subassemblies");


		public static string ThumbsDir { get; } = Path.Combine(Main.Instance.CurrentInstance.GameDir(), "thumbs");

		public static string FolderNameHangar { get; } = "Hangar";

		/// <summary>
		/// Takes a save name and returns a path to that save's 'Ships' folder.
		/// </summary>
		/// <param name="saveName"></param>
		/// <returns></returns>
		public static string GetPathToShipsFolder(string saveName)
		{
			return (saveName == FolderNameHangar)
					? HangarDir
					: Path.Combine(SaveDir, saveName, "ships");
		}
	}
}
