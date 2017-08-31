/*
 * Created by SharpDevelop.
 * User: sergey.lezhenko
 * Date: 31.08.2017
 * Time: 9:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace DZ_DataAdapter
{
	public partial class MainForm : Form
	{
		public static SqlConnection connect = null;
		public static SqlDataAdapter dAdapter;
		public static DataSet set = new DataSet("Library");
		
		public MainForm()
		{
			InitializeComponent();
			this.Load += MainForm_OnLoad;
		}

		void MainForm_OnLoad(object sender, EventArgs e)
		{
			connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Library"].ConnectionString);
			buttonSelect_Click(sender, e);
		}
		void buttonSelect_Click(object sender, EventArgs e)
		{
			try {
				dAdapter = new SqlDataAdapter("SELECT * FROM Authors ORDER BY id", connect);
				dAdapter.Fill(set, "Authors");
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}
		void buttonInsert_Click(object sender, EventArgs e)
		{
			FormEdit fmEdit = new FormEdit();
			if (fmEdit.ShowDialog() == DialogResult.OK) {
				try {
					dAdapter.InsertCommand = new SqlCommand(string.Format(
						"INSERT INTO Authors(firstname,lastname) VALUES('{0}','{1}')",
						fmEdit.textBoxFirstName.Text,
						fmEdit.textBoxLastName.Text));
					DataRow newAuthor = set.Tables["Authors"].NewRow();
					newAuthor["firstname"] = fmEdit.textBoxFirstName.Text;
					newAuthor["lastname"] = fmEdit.textBoxLastName.Text;
					set.Tables["Authors"].Rows.Add(newAuthor);
					dAdapter.Update(set.Tables["Authors"]);
				} catch (Exception ex) {
					MessageBox.Show(ex.Message);
				}
			}
		}
		void buttonUpdate_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0) {
				try {
					var fmEdit = new FormEdit();
					fmEdit.textBoxFirstName.Text = (string)dataGridView1.SelectedRows[0].Cells["firstname"].Value ?? "";
					fmEdit.textBoxLastName.Text = (string)dataGridView1.SelectedRows[0].Cells["lastname"].Value ?? "";
					if (fmEdit.ShowDialog() == DialogResult.OK) {
						int id = (int)dataGridView1.SelectedRows[0].Cells["id"].Value;
						dAdapter.UpdateCommand = new SqlCommand(string.Format(
							"UPDATE Authors SET firstname = {0}, lastname = {1} WHERE id = {2}",
							fmEdit.textBoxFirstName.Text,
							fmEdit.textBoxLastName.Text,
							id));
						DataRow[] row = set.Tables["Authors"].Select(string.Format("id = {0}", id));
						row[0]["firstname"] = fmEdit.textBoxFirstName.Text;
						row[0]["lastname"] = fmEdit.textBoxLastName.Text;
						dAdapter.Update(set.Tables["Authors"]);
					}
				} catch (Exception ex) {
					MessageBox.Show(ex.Message);
				}
			}
		}
		void buttonDelete_Click(object sender, EventArgs e)
		{
			if(dataGridView1.SelectedRows.Count > 0) {
				try{
					int id = (int)dataGridView1.SelectedRows[0].Cells["id"].Value;
					dAdapter.DeleteCommand = new SqlCommand(string.Format("DELETE FROM Authors WHERE id = {0}", id));
					DataRow[] row = set.Tables["Authors"].Select(string.Format("id = {0}", id));
					row[0].Delete();
					dAdapter.Update(set.Tables["Authors"]);
				}catch(Exception ex){
					MessageBox.Show(ex.Message);
				}
			}
		}
	}
}
