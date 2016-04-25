using System.Windows.Forms;
using CKAN;

namespace CKANPluginStarter
{
	public partial class PluginUI : UserControl
	{
		public PluginUI()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Callback registered with CKAN to execute any code in the plugin module
		/// whenever CKAN notifies of a change in the mod list.
		/// </summary>
		/// <param name="module">CKAN representation of a mod.</param>
		/// <param name="changeType">The change type made: None, Install, Remove, Update </param>
		public void OnModChanged(CkanModule module, GUIModChangeType changeType)
		{
		}
	}
}
