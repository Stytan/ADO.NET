/*
 * Created by SharpDevelop.
 * User: sergey.lezhenko
 * Date: 30.08.2017
 * Time: 10:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace EmployeeCatalog
{
    /// <summary>
    /// Description of editForm.
    /// </summary>
    public partial class editForm : Form
    {
        public editForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Загружает выбранное фото
        /// </summary>
        void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.Load();
            }
        }
        /// <summary>
        /// Не позволяет сохранить данные без имени м фамилии
        /// </summary>
        void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == null || textBoxName.Text == null)
            {
                MessageBox.Show("Surname and Name must be filled", "Warning");
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
