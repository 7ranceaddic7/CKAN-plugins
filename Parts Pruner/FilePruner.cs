using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using CKAN;
using PartsPrunerPlugin;

namespace PartsPruner
{
	class FilePruner
	{
		/// <summary>
		/// Takes a .prnl file and determines if it is fully or partially pruned
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public bool CheckPruned(string path)
		{
			bool r = false;
			foreach (var line in LoadFilePaths(path))
			{
				if (IsBlankOrComment(line)) continue;

				var fPath = Path.Combine(Main.Instance.CurrentInstance.GameData(), line);

				bool i = IsDirectoryPruned(fPath);
				if (i != r) r = i;
			}
			return r;
		}


		/// <summary>
		/// Determines if a folder contains all pruned files or pruned and unpruned
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public bool IsDirectoryPruned(string path)
		{
			if (Directory.Exists(path))
			{
				var di = new DirectoryInfo(path);

				if (!di.Exists) return false;

				int fileCount = di.EnumerateFiles("*", SearchOption.AllDirectories).Count();
				int pruneCount = di.EnumerateFiles("*.prune", SearchOption.AllDirectories).Count();

				if (fileCount == pruneCount) return true;
				return false;
			}
			if (File.Exists(path + ".prune")) return true;

			return false;

		}


		/// <summary>
		/// Loads all lines from a given .prnl file
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		private List<string> LoadFilePaths(string file)
		{
			var pathsInFile = new List<string>();
			using (var r = new StreamReader(file))
			{
				string line;
				while ((line = r.ReadLine()) != null)
					pathsInFile.Add(line);
			}
			return pathsInFile;
		}

		/// <summary>
		/// Checks if the given string starts with a # or is a blank line
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private bool IsBlankOrComment(string line)
		{
			if (line[0] == '#') return true;
			if (string.IsNullOrEmpty(line)) return true;
			return false;
		}



		#region Pruner

		/// <summary>
		/// Takes a list of file and directory paths and adds the .prune extension to all contained files
		/// </summary>
		/// <param name="filesList">List of file and directory paths</param>
		public void PruneFiles(IEnumerable<string> filesList)
		{
			foreach (var file in filesList)
			{
				foreach (var line in LoadFilePaths(file))
				{
					if (IsBlankOrComment(line)) continue;

					var path = Path.Combine(Main.Instance.CurrentInstance.GameData(), line);


					if (File.Exists(path))
						PruneFile(path);

					else if (Directory.Exists(path))
						PruneDirectory(path);

					else
						PartPrunerUi.Instance.LogWarning("\"" + PartPrunerUi.GetGameDataPath(path) + "\" is not a file or a directory.");
				}
			}
		}

		private void PruneDirectory(string path)
		{
			try
			{
				PartPrunerUi.Instance.Log("Pruning files from " + PartPrunerUi.GetGameDataPath(path));
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
				PartPrunerUi.Instance.LogError(ex.ToString());
			}

		}

		private void PruneFile(string file)
		{
			try
			{
				File.Move(file, file + ".prune");
				PartPrunerUi.Instance.Log("Pruned: " + PartPrunerUi.GetGameDataPath(file));
			}
			catch (IOException ex)
			{
				PartPrunerUi.Instance.LogError(ex.ToString());
			}
		}

		#endregion Pruner


		#region Unpruner

		/// <summary>
		/// Takes a list of file and directory paths and removes the .prune extension from all contained files
		/// </summary>
		/// <param name="filesList">List of file and directory paths</param>
		public void UnpruneFiles(IEnumerable<string> filesList)
		{
			foreach (var file in filesList)
			{
				foreach (var line in LoadFilePaths(file))
				{
					var prunefile = Path.Combine(Main.Instance.CurrentInstance.GameData(), line + ".prune");
					var path = Path.Combine(Main.Instance.CurrentInstance.GameData(), line);

					if (File.Exists((prunefile)))
						path += ".prune";

					if (File.Exists(path))
						UnpruneFile(path);

					else if (Directory.Exists(path))
						UnpruneDirectory(path);

					else
						PartPrunerUi.Instance.LogWarning("\"" + PartPrunerUi.GetGameDataPath(path) + "\" is not a file or a directory.");

				}
			}
		}

		private void UnpruneDirectory(string path)
		{
			try
			{
				PartPrunerUi.Instance.Log("Unpruning files from " + PartPrunerUi.GetGameDataPath(path));
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
				PartPrunerUi.Instance.LogError(ex.ToString());
			}

		}

		private void UnpruneFile(string file)
		{
			try
			{
				var newFile = file.Replace(".prune", "");
				File.Move(file, newFile);
				PartPrunerUi.Instance.Log("Unpruned: " + PartPrunerUi.GetGameDataPath(file));
			}
			catch (IOException ex)
			{
				PartPrunerUi.Instance.LogError(ex.ToString());
			}
		}

		#endregion Unpruner
	}
}
