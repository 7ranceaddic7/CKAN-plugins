﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PartEditorPlugin.Configs
{
	public class ConfigNode
	{
		public string Id = String.Empty;
		public string Name = String.Empty;

		private readonly List<KeyValuePair<string, string>> _values = new List<KeyValuePair<string, string>>();
		private readonly List<ConfigNode> _nodes = new List<ConfigNode>();

		public ConfigNode() { }

		public ConfigNode(string name)
		{
			Name = name;
		}

		public ConfigNode[] Nodes => _nodes.ToArray();

		public KeyValuePair<string, string>[] Values => _values.ToArray();

		public int CountNodes => _nodes.Count;

		public int CountValues => _values.Count;

		public ConfigNode AddConfigNode(ConfigNode node)
		{
			_nodes.Add(node);
			return node;
		}

		public void AddValue(string key, string value)
		{
			var kvp = new KeyValuePair<string, string>(key, value);
			_values.Add(kvp);
		}

		public void ClearData()
		{
			_values.Clear();
			_nodes.Clear();
		}

		public void ClearNodes()
		{
			_nodes.Clear();
		}

		public void ClearValues()
		{
			_values.Clear();
		}

		public ConfigNode GetNode(string name, int index)
		{
			int currentIndex = 0;
			foreach (ConfigNode node in _nodes)
			{
				if (node.Name == name)
				{
					if (currentIndex == index)
						return node;
					currentIndex++;
				}
			}
			return null;
		}

		public ConfigNode GetNode(string name)
		{
			foreach (ConfigNode node in _nodes)
			{
				if (node.Name == name)
					return node;
			}
			return null;
		}

		public ConfigNode GetNodeId(string id)
		{
			return _nodes.FirstOrDefault(node => node.Id == id);
		}

		public ConfigNode[] GetNodes(string name)
		{
			return _nodes.Where(node => node.Name == name).ToArray();
		}

		public string GetValue(string name, int index)
		{
			var currentIndex = 0;
			foreach (var value in _values.Where(value => value.Key == name))
			{
				if (currentIndex == index)
					return value.Value;
				currentIndex++;
			}
			return null;
		}

		public string GetValue(string name)
		{
			return (from value in _values where value.Key == name select value.Value).FirstOrDefault();
		}

		public string[] GetValues(string name)
		{
			return (from value in _values where value.Key == name select value.Value).ToArray();
		}

		public string[] GetValuesStartsWith(string name)
		{
			return (from value in _values where value.Key.StartsWith(name) select value.Value).ToArray();
		}

		public bool HasNode()
		{
			return _nodes.Count > 0;
		}

		public bool HasNode(string name)
		{
			return _nodes.Any(cn => cn.Name == name);
		}

		public bool HasNodeId(string id)
		{
			return _nodes.Any(cn => cn.Id == id);
		}

		public bool HasValue()
		{
			return _values.Count > 0;
		}

		public bool HasValue(string name)
		{
			return _values.Any(value => value.Key == name);
		}

		public static ConfigNode Load(string fileFullName)
		{
			return ConfigNodeReader.FileToConfigNode(fileFullName);
		}

		public static void Merge(ConfigNode mergeTo, ConfigNode mergeFrom)
		{
			//TODO: Implement
			throw new NotImplementedException();
		}

		public void RemoveNode(string name)
		{
			foreach (ConfigNode node in _nodes.ToArray())
			{
				if (node.Name != name) continue;
				_nodes.Remove(node);
				return;
			}
		}

		public void RemoveNodes(string name)
		{
			foreach (ConfigNode node in _nodes.ToArray())
			{
				if (node.Name == name)
					_nodes.Remove(node);
			}
		}

		public void RemoveNodesStartsWith(string name)
		{
			foreach (ConfigNode node in _nodes.ToArray())
			{
				if (node.Name.StartsWith(name))
					_nodes.Remove(node);
			}
		}

		public void RemoveValue(string name)
		{
			foreach (KeyValuePair<string, string> value in _values.ToArray())
			{
				if (value.Key != name) continue;
				_values.Remove(value);
				return;
			}
		}

		public void RemoveValues(string[] names)
		{
			foreach (string name in names)
				RemoveValues(name);
		}

		public void RemoveValues(string name)
		{
			foreach (KeyValuePair<string, string> value in _values.ToArray())
			{
				if (value.Key == name)
					_values.Remove(value);
			}
		}

		public void RemoveValuesStartsWith(string startsWith)
		{
			foreach (KeyValuePair<string, string> value in _values.ToArray())
			{
				if (value.Key.StartsWith(Name))
					_values.Remove(value);
			}
		}

		public bool SetNode(string name, ConfigNode newNode, int index)
		{
			//This is probably incorrect, but it already doesn't make sense in the first place...
			ConfigNode oldNode = GetNode(name, index);
			if (oldNode == null)
			{
				//Index doesn't exist - Add it to the node list anyway.
				_nodes.Add(newNode);
			}
			else
			{
				//Index exists - Replace the node
				int oldPos = _nodes.IndexOf(oldNode);
				_nodes[oldPos] = newNode;
			}
			return true;
		}

		public bool SetNode(string name, ConfigNode newNode)
		{
			return SetNode(name, newNode, 0);
		}

		public bool SetValue(string name, string newValue, int index)
		{
			//This is probably incorrect, but it already doesn't make sense in the first place...
			var oldValue = new KeyValuePair<string, string>(name, GetValue(name, index));
			if (oldValue.Value == null)
			{
				//Index doesn't exist - Add it to the node list anyway.
				_values.Add(new KeyValuePair<string, string>(name, newValue));
			}
			else
			{
				//Index exists - Replace the node
				int oldPos = _values.IndexOf(oldValue);
				_values[oldPos] = new KeyValuePair<string, string>(name, newValue);
			}
			return true;
		}

		public bool SetValue(string name, string newValue)
		{
			return SetValue(name, newValue, 0);
		}


	}
}
