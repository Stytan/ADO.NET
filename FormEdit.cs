/*
 * Created by SharpDevelop.
 * User: sergey.lezhenko
 * Date: 31.08.2017
 * Time: 10:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DZ_DataAdapter
{
	public partial class FormEdit : Form
	{
		public FormEdit()
		{
			InitializeComponent();
		}
		void buttonSave_Click(object sender, EventArgs e)
		{
			if(textBoxFirstName.Text == null || textBoxLastName==null)
			{
				MessageBox.Show("First name and last name must be filled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.DialogResult = DialogResult.None;
			}
		}
	}
}
