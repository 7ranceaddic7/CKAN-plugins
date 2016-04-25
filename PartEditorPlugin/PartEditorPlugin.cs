using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CKAN;
using Version = CKAN.Version;

namespace PartEditorPlugin
{
	public class PartEditorPlugin: IGUIPlugin
	{
		private readonly Version _version = new Version("v1.1.0");

		private PartEditorUi _mUi = null;

		public override string GetName()
		{
			return "Part Editor by Gribbleshnibit8";
		}

		public override Version GetVersion()
		{
			return _version;
		}

		public override void Initialize()
		{
			var tabPage = new TabPage { Name = "Part Editor", Text = "Part Editor" };

			_mUi = new PartEditorUi { Dock = DockStyle.Fill };
			tabPage.Controls.Add(_mUi);

			Main.modChangedCallback += _mUi.OnModChanged;
			Main.Instance.m_TabController.m_TabPages.Add("Part Editor", tabPage);
			Main.Instance.m_TabController.ShowTab("Part Editor", 1, false);
		}

		public override void Deinitialize()
		{
			throw new NotImplementedException();
		}
	}
}
