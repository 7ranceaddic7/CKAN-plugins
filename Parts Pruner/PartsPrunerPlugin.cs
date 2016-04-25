using System.Windows.Forms;
using CKAN;
using Version = CKAN.Version;

namespace PartsPrunerPlugin
{
	class PartsPrunerPlugin : IGUIPlugin
	{
		private readonly  Version _version = new Version("v1.0.0");

		private PartPrunerUi _mUI = null;

		public override void Initialize()
		{
			var tabPage = new TabPage {Name = "PartsPruner", Text = "Part Pruner"};

			_mUI = new PartPrunerUi {Dock = DockStyle.Fill};
			tabPage.Controls.Add(_mUI);

			//Main.modChangedCallback += _mUI.OnModChanged;

			Main.Instance.m_TabController.m_TabPages.Add("PartsPruner", tabPage);
			Main.Instance.m_TabController.ShowTab("PartsPruner", 1, false);
		}

		public override void Deinitialize()
		{
			//Main.modChangedCallback -= _mUI.OnModChanged;
			Main.Instance.m_TabController.HideTab("PartsPruner");
			Main.Instance.m_TabController.m_TabPages.Remove("PartsPruner");
		}

		public override string GetName()
		{
			return "Parts Pruner by Gribbleshnibit8";
		}

		public override Version GetVersion()
		{
			return _version;
		}
	}
}
