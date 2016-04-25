using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipManagerPlugin
{
	public partial class SaveSelection : Form
	{
		public string Value;

		public SaveSelection(List<string> saves)
		{
			InitializeComponent();

			comboBox1.DataSource = new BindingSource {DataSource = saves};
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Value = comboBox1.SelectedItem.ToString();
			Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
