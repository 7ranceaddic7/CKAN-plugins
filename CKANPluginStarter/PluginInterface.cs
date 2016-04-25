using System;
using System.Windows.Forms;
using CKAN;
using Version = CKAN.Version;


// Setup Notes:
// 1) Menu bar Project -> Properties -> Build Events
//    a) Change name of DLL to name of project
// 2) Debug -> Start external Program
//    a) Enter path to existing version of CKAN

namespace CKANPluginStarter
{
    public class PluginInterface : IGUIPlugin
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
			var tabPage = new TabPage { Name = "CKANPlugin", Text = "CKAN Plugin" };

			// Set the user control from this mod to fill then add to the tab.
			_mUi = new PluginUI { Dock = DockStyle.Fill };
			tabPage.Controls.Add(_mUi);

			// Setup the callback, and add the tab to the CKAN tab controller. 
			// Uses the name given for the tab above when the tabPage was created.
			Main.modChangedCallback += _mUi.OnModChanged;
			Main.Instance.m_TabController.m_TabPages.Add("CKANPlugin", tabPage);
			Main.Instance.m_TabController.ShowTab("CKANPlugin", 1, false);
		}

		/// <summary>
		/// Called by CKAN if the plugin is disabled by the user.
		/// </summary>
		public override void Deinitialize()
		{
			// Unregister the callback, hide the tab, and then remove it.
			// Uses the name given for the tab above when the tabPage was created.
			Main.modChangedCallback -= _mUi.OnModChanged;
			Main.Instance.m_TabController.HideTab("CKANPlugin");
			Main.Instance.m_TabController.m_TabPages.Remove("CKANPlugin");
		}

		/// <summary>
		/// Called by CKAN to show the name of the plugin in the plugin selection interface.
		/// </summary>
		/// <returns>Returns a string with the name of the plugin.</returns>
		public override string GetName()
		{
			// This string should give the name of the plugin. The version will be added by CKAN.
			return "CKAN Plugin";
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
