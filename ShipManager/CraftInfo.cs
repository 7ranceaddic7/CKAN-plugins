using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
			FileName = Path.GetFileName(path);
			if (path.Contains("Subassemblies")) SaveName = path.Split(Path.DirectorySeparatorChar)[path.Split(Path.DirectorySeparatorChar).Length - 3];
			else SaveName = path.Split(Path.DirectorySeparatorChar)[path.Split(Path.DirectorySeparatorChar).Length - 4];
			GetCraftInfo(this, path);
			Thumb = GetCraftThumb();

			Hash = GetHash();
		}

		/// <summary>
		/// CraftName of the craft file.
		/// </summary>
		public string CraftName { get; private set; }

		public string FileName { get; private set; }

		/// <summary>
		/// Name of the save game the craft file belongs to.
		/// </summary>
		public string SaveName { get; }

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
		public string FilePath { get; private set; }

		/// <summary>
		/// What building this craft shows up in in-game.
		/// </summary>
		public string Building { get; private set; }

		public string PartCount { get; private set; }

		public string Description { get; private set; }

		public string Version { get; private set; }

		public string Hash { get; private set; }


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


		public void UpdateCraftPath(string newPath)
		{
			if (File.Exists(newPath))
				FilePath = newPath;
		}

		/// <summary>
		/// Gets the thumbnail of a craft file.
		/// </summary>
		/// <returns>Returns the thumbnail if one exists, and the default icon otherwise</returns>
		private Image GetCraftThumb()
		{
			var thumbPath = Path.Combine(Main.Instance.CurrentInstance.GameDir(), "thumbs", ThumbName);

			if (File.Exists(thumbPath))
				return Image.FromFile(thumbPath);
			return Resources.defaultcapsule;
		}

		private string GetHash()
		{
			using (var md5 = MD5.Create())
			{
				using (var stream = File.OpenRead(FilePath))
				{
					return Encoding.Default.GetString(md5.ComputeHash(stream));
				}
			}
		}



		public bool Equals(CraftInfo toCompare)
		{
			return Hash.Equals(toCompare.Hash);
		}
	}
}