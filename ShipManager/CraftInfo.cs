using System.Drawing;
using System.IO;
using CKAN;
using ShipManagerPlugin.Properties;

namespace ShipManagerPlugin
{
	public class CraftInfo
	{
		public CraftInfo() { }

		public CraftInfo(string path)
		{
			FilePath = path;
			SaveName = path.Split(Path.DirectorySeparatorChar)[path.Split(Path.DirectorySeparatorChar).Length - 4];
			GetCraftInfo(this, path);
			Thumb = GetCraftThumb();
		}

		/// <summary>
		/// CraftName of the craft file.
		/// </summary>
		public string CraftName { get; set; }

		public string FileName => CraftName + ".craft";

		/// <summary>
		/// Name of the save game the craft file belongs to.
		/// </summary>
		public string SaveName { get; set; }

		/// <summary>
		/// Craft thumbnail.
		/// </summary>
		public Image Thumb { get; }

		/// <summary>
		/// File CraftName of the craft thumbnail.
		/// </summary>
		public string ThumbName => SaveName + "_" + Building + "_" + CraftName + ".png";

		/// <summary>
		/// Full path to the craft file.
		/// </summary>
		public string FilePath { get; }

		/// <summary>
		/// What building this craft shows up in in-game.
		/// </summary>
		public string Building { get; private set; }

		public string PartCount { get; private set; }

		public string Description { get; private set; }

		public string Version { get; private set; }


		private Image GetCraftThumb()
		{
			var thumbPath = Path.Combine(Main.Instance.CurrentInstance.GameDir(), "thumbs", ThumbName);

			if (File.Exists(thumbPath))
				return Image.FromFile(thumbPath);
			return Resources.defaultcapsule;
		}

		/// <summary>
		/// Reads a craft file and gets extra info from it such as the description,
		/// latest game version, and part counts.
		/// </summary>
		public static void GetCraftInfo(CraftInfo craft, string path)
		{
			var file = File.ReadAllLines(path);

			int count = 0;

			foreach (var line in file)
			{
				if (craft.CraftName == null && line.Contains("ship"))
				{
					craft.CraftName = line.Split('=')[1].Trim();
					continue;
				}

				if (craft.Description == null && line.Contains("description"))
				{
					craft.Description = line.Split('=')[1].Trim();
					continue;
				}

				if (craft.Version == null && line.Contains("version"))
				{
					craft.Version = line.Split('=')[1].Trim();
					continue;
				}

				if (craft.Building == null && line.Contains("type"))
				{
					craft.Building = line.Split('=')[1].Trim();
					continue;
				}

				if (line.Equals("PART"))
					count++;

			}
			craft.PartCount = count.ToString();
		}
	}
}