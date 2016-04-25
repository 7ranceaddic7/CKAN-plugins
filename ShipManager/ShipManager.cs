using System;
using System.Windows.Forms;
using CKAN;
using Version = CKAN.Version;

namespace ShipManagerPlugin
{
    public class ShipManagerPlugin : IGUIPlugin
	{
		private readonly Version _version = new Version("v1.1.0");

		// Variable to hold the current interface instance that will be added to the plugin's tab.
		private PluginUI _mUi = null;

		/// <summary>
		/// Called by CKAN at load to set up the plugin.
		/// </summary>
		public override void Initialize()
		{
			// Give the tab a name and set the text that will show to the user.
			var tabPage = new TabPage { Name = "ShipManager", Text = "Ship Manager" };

			// Set the user control from this plugin to fill then add to the tab.
			_mUi = new PluginUI { Dock = DockStyle.Fill };
			tabPage.Controls.Add(_mUi);

			// Setup the callback, and add the tab to the CKAN tab controller. 
			//Main.modChangedCallback += _mUi.OnModChanged;
			Main.Instance.m_TabController.m_TabPages.Add("ShipManager", tabPage);
			Main.Instance.m_TabController.ShowTab("ShipManager", 1, false);
		}

		/// <summary>
		/// Called by CKAN if the plugin is disabled by the user.
		/// </summary>
		public override void Deinitialize()
		{
			// Unregister the callback, hide the tab, and then remove it.
			//Main.modChangedCallback -= _mUi.OnModChanged;
			Main.Instance.m_TabController.HideTab("ShipManager");
			Main.Instance.m_TabController.m_TabPages.Remove("ShipManager");
		}

		/// <summary>
		/// Called by CKAN to show the name of the plugin in the plugin selection interface.
		/// </summary>
		/// <returns>Returns a string with the name of the plugin.</returns>
		public override string GetName()
		{
			// This string should give the name of the plugin. The version will be added by CKAN.
			return "Ship Manager by Gribbleshnibit8";
		}

		/// <summary>
		/// Called by CKAN to get the version of the plugin.
		/// </summary>
		/// <returns></returns>
		public override Version GetVersion()
		{
			return _version;
		}
	}
}
