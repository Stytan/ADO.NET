/*
 * Created by SharpDevelop.
 * User: sergey.lezhenko
 * Date: 30.08.2017
 * Time: 10:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EmployeeCatalog
{
	partial class editForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox textBoxSurname;
		public System.Windows.Forms.TextBox textBoxName;
		public System.Windows.Forms.TextBox textBoxPatronymic;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox textBoxPosition;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox textBoxAdmission;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox textBoxDismissal;
		public System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		public System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonLoad;
		private System.Windows.Forms.Label label7;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxSurname = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxPatronymic = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxPosition = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxAdmission = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxDismissal = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Surname";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Name";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 152);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Patronymic";
			// 
			// textBoxSurname
			// 
			this.textBoxSurname.Location = new System.Drawing.Point(96, 56);
			this.textBoxSurname.MaxLength = 50;
			this.textBoxSurname.Name = "textBoxSurname";
			this.textBoxSurname.Size = new System.Drawing.Size(136, 20);
			this.textBoxSurname.TabIndex = 1;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(96, 104);
			this.textBoxName.MaxLength = 50;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(136, 20);
			this.textBoxName.TabIndex = 2;
			// 
			// textBoxPatronymic
			// 
			this.textBoxPatronymic.Location = new System.Drawing.Point(96, 152);
			this.textBoxPatronymic.MaxLength = 50;
			this.textBoxPatronymic.Name = "textBoxPatronymic";
			this.textBoxPatronymic.Size = new System.Drawing.Size(136, 20);
			this.textBoxPatronymic.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 200);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Position";
			// 
			// textBoxPosition
			// 
			this.textBoxPosition.Location = new System.Drawing.Point(96, 200);
			this.textBoxPosition.MaxLength = 255;
			this.textBoxPosition.Name = "textBoxPosition";
			this.textBoxPosition.Size = new System.Drawing.Size(464, 20);
			this.textBoxPosition.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 248);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Admission";
			// 
			// textBoxAdmission
			// 
			this.textBoxAdmission.Location = new System.Drawing.Point(96, 248);
			this.textBoxAdmission.MaxLength = 30;
			this.textBoxAdmission.Name = "textBoxAdmission";
			this.textBoxAdmission.Size = new System.Drawing.Size(136, 20);
			this.textBoxAdmission.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(288, 248);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Dismissal";
			// 
			// textBoxDismissal
			// 
			this.textBoxDismissal.Location = new System.Drawing.Point(352, 248);
			this.textBoxDismissal.MaxLength = 30;
			this.textBoxDismissal.Name = "textBoxDismissal";
			this.textBoxDismissal.Size = new System.Drawing.Size(136, 20);
			this.textBoxDismissal.TabIndex = 7;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(416, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(144, 160);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Photo|*.jpg,*.bmp";
			// 
			// buttonAdd
			// 
			this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonAdd.Location = new System.Drawing.Point(328, 320);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 8;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(456, 320);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(352, 160);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(56, 23);
			this.buttonLoad.TabIndex = 5;
			this.buttonLoad.Text = "Load...";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(352, 136);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 0;
			this.label7.Text = "Photo";
			// 
			// editForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(597, 368);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.buttonLoad);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.textBoxDismissal);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxAdmission);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxPosition);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxPatronymic);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.textBoxSurname);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "editForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Add employee";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
