using System.IO;

namespace PartEditorPlugin.Configs
{
	public class ConfigNodeReader
	{
		public static ConfigNode FileToConfigNode(string inputFile)
		{
			return StringToConfigNode(File.ReadAllText(inputFile));
		}
		
		public static ConfigNode StringToConfigNode(string inputString)
		{
			var returnNode = new ConfigNode();
			using (var sr = new StringReader(inputString))
			{
				string currentLine;

				var partStringFound = false;

				while ((currentLine = sr.ReadLine()) != null)
				{
					string trimmedLine = currentLine.TrimStart(); //Take note of depth

					

					if (trimmedLine.Contains("//"))
						trimmedLine = trimmedLine.Substring(0, trimmedLine.IndexOf("//"));

					if (trimmedLine.Length == 0)
						continue;

					if (trimmedLine.Contains("{") && !partStringFound) return null;

					if (trimmedLine.Contains("}")) { }

					if (trimmedLine.ToUpper().Contains("PART"))
						partStringFound = true;

					//We are reading a config node at our depth
					if (trimmedLine.Contains(" = "))
					{
						string pairKey = trimmedLine.Substring(0, trimmedLine.IndexOf(" = "));
						string pairValue = trimmedLine.Substring(trimmedLine.IndexOf(" = ") + 3);
						returnNode.AddValue(pairKey, pairValue);
					}
				}
			}
			return returnNode;
		}

		private static ConfigNode CreateChildNode(string inputString, ConfigNode parentNode)
		{
			return new ConfigNode();
		}
	}
}
