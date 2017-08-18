/*
 * Created by SharpDevelop.
 * User: sergey.lezhenko
 * Date: 25.07.2017
 * Time: 9:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DZ_2
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
/*		private DataGrid dgField;
		private DataSet dataSet;
		private ComboBox cbTable;
		private OleDbConnection Connect;
		private OleDbCommand ComBuyers, ComSellers, ComSales;
*/		
		private OleDbConnection Connect;
		private OleDbCommand comGetData, comInsert, comEdit, comDelete;		
		private Label lHeader = new Label();
		private Panel buttonPanel = new Panel();
		private DataGridView dgvEmployees = new DataGridView();
		private Button btnAddEmployee = new Button();
		private Button btnEditEmployee = new Button();
		private Button btnDeleteEmployee = new Button();
		
		public MainForm()
		{
			InitializeComponent();
			
			this.Load += new EventHandler(MainForm_Load);

/*			
			//Создаём выпадающий список
			cbTable = new ComboBox();
			cbTable.Size = new Size(100, 50);
			cbTable.Location = new Point(20, 30);
			this.Controls.Add(cbTable);
			
			//Добавляем в него элементы
			cbTable.BeginUpdate();
			cbTable.Items.Add("Покупатели");
			cbTable.Items.Add("Продавцы");
			cbTable.Items.Add("Продажи");
			cbTable.EndUpdate();
			
			//Подписываемся на событие изменения поля
			cbTable.SelectedIndexChanged += tableChanged;
			
			//Создаём поле для показа таблицы результатов
			dgField = new DataGrid();
			dgField.Size = new Size(700, 400);
			dgField.Location = new Point(200, 30);
			this.Controls.Add(dgField);
			
*/
		}
		
		private void MainForm_Load(Object seneder, EventArgs e)
		{
			SetupLayout();
			SetupDbConnect();
			SetupDataGridView();
			
		}

		private void SetupLayout()
		{
			lHeader.Location = new Point(400, 20);
			lHeader.Size = new Size(150, 20);
			lHeader.Font = new Font(lHeader.Font, FontStyle.Bold);
			lHeader.Text = "List of Employees";
			this.Controls.Add(lHeader);
			
			btnAddEmployee.Text = "Add Emlpoyee";
			btnAddEmployee.Location = new Point(10, 10);
			btnAddEmployee.Click += new EventHandler(btnAddEmployee_Click);
			
			btnEditEmployee.Text = "Edit Employee";
			btnEditEmployee.Location = new Point(100, 10);
			btnEditEmployee.Click += new EventHandler(btnEditEmployee_Click);
			
			btnDeleteEmployee.Text = "Delete Employee";
			btnDeleteEmployee.Location = new Point(190, 10);
			btnDeleteEmployee.Click += new EventHandler(btnDeleteEmployee_Click);
			
			buttonPanel.Controls.Add(btnAddEmployee);
			buttonPanel.Controls.Add(btnEditEmployee);
			buttonPanel.Controls.Add(btnDeleteEmployee);
			buttonPanel.Height = 50;
			buttonPanel.Dock = DockStyle.Bottom;
			
			this.Controls.Add(buttonPanel);
		}

		private void SetupDbConnect()
		{
			//Задаём параметры подключения
			Connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" +
			                              "Data Source = .\\example.accdb;" +
			                              "Persist Security Info = false");
			
			//Задаём запросы на выборку данных
			comGetData = new OleDbCommand("", Connect);
			comInsert = new OleDbCommand("", Connect);
			comEdit = new OleDbCommand("", Connect);
			comDelete = new OleDbCommand("", Connect);
		}
		
		private void SetupDataGridView()
		{
			this.Controls.Add(dgvEmployees);
			
			dgvEmployees.ColumnCount = 7;
			
			dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
			dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			dgvEmployees.ColumnHeadersDefaultCellStyle.Font =
				new Font(dgvEmployees.Font, FontStyle.Bold);
			dgvEmployees.Name = "dgvEmployees";
			dgvEmployees.Location = new Point(10, 50);
			dgvEmployees.Size = new Size(900, 350);
			dgvEmployees.AutoSizeRowsMode = 
				DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
			dgvEmployees.ColumnHeadersBorderStyle =
				DataGridViewHeaderBorderStyle.Single;
			dgvEmployees.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			dgvEmployees.GridColor = Color.Black;
			dgvEmployees.RowHeadersVisible = false;
			
			dgvEmployees.Columns[0].Name = "#";
			dgvEmployees.Columns[0].Width = 30;
			dgvEmployees.Columns[1].Name = "Surname";
			dgvEmployees.Columns[1].Width = 110;
			dgvEmployees.Columns[2].Name = "Name";
			dgvEmployees.Columns[2].Width = 110;
			dgvEmployees.Columns[3].Name = "Patronymic";
			dgvEmployees.Columns[3].Width = 110;
			dgvEmployees.Columns[4].Name = "Position";
			dgvEmployees.Columns[4].Width = 295;
			dgvEmployees.Columns[4].DefaultCellStyle.Font =
				new Font(dgvEmployees.DefaultCellStyle.Font, FontStyle.Italic);
			dgvEmployees.Columns[5].Name = "Order of admission";
			dgvEmployees.Columns[5].Width = 120;
			dgvEmployees.Columns[6].Name = "Order of dismissal";
			dgvEmployees.Columns[6].Width = 120;
			
			dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvEmployees.MultiSelect = false;
			dgvEmployees.Dock = DockStyle.None;
			
			dgvEmployees.DataSource = GetDataFormDB();
		}

		private DataTable GetDataFormDB()
		{
			var table = new DataTable();
			DataColumn Col;
			DataRow Row;
			try{
				Connect.Open();
				//OleDbDataReader reader = comGetData.ExecuteReader();
			}catch(OleDbException e){
				MessageBox.Show(e.Message, "DB Error");
			}finally{
				if (Connect.State == ConnectionState.Open)
					Connect.Close();
			}
			
			
			return table;
		}
		
		private void btnAddEmployee_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void btnEditEmployee_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void btnDeleteEmployee_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
/*
		/// <summary>
		/// Функция по событию передаёт в RefreshGrid нужную команду
		/// </summary>
		private void tableChanged(object sender, System.EventArgs e)
		{
			switch((string)cbTable.SelectedItem)
			{
				case "Покупатели":
					{
						RefreshGrid(ComBuyers);
						break;}
				case "Продавцы":
					{
						RefreshGrid(ComSellers);
						break;}
				case "Продажи":
					{
						RefreshGrid(ComSales);
						break;}
			}
		}
		
		/// <summary>
		/// Обновляет поле с таблицей результатов
		/// </summary>
		/// <param name="command">Команда с запросом в базу</param>
		private void RefreshGrid(OleDbCommand command)
		{
			try{
				//Создаём таблицу для результатов
				DataTable Table = new DataTable("MainTable");
				DataColumn Col;
				DataRow Row;
				if(command.Equals(ComSellers) || command.Equals(ComBuyers))
				{
					Col = new DataColumn();
					Col.DataType = Type.GetType("System.Int32");
					Col.ColumnName = "id";
					Col.ReadOnly = true;
					Table.Columns.Add(Col);
					Col = new DataColumn();
					Col.DataType = Type.GetType("System.String");
					Col.ColumnName = "FirstName";
					Col.ReadOnly = true;
					Table.Columns.Add(Col);
					Col = new DataColumn();
					Col.DataType = Type.GetType("System.String");
					Col.ColumnName = "LastName";
					Col.ReadOnly = true;
					Table.Columns.Add(Col);
				}else{
					Col = new DataColumn();
					Col.DataType = Type.GetType("System.Int32");
					Col.ColumnName = "id";
					Col.ReadOnly = true;
					Table.Columns.Add(Col);
					Col = new DataColumn();
					Col.DataType = Type.GetType("System.String");
					Col.ColumnName = "Seller";
					Col.ReadOnly = true;
					Table.Columns.Add(Col);
					Col = new DataColumn();
					Col.DataType = Type.GetType("System.String");
					Col.ColumnName = "Buyer";
					Col.ReadOnly = true;
					Table.Columns.Add(Col);
    				Col = new DataColumn();
					Col.DataType = Type.GetType("System.Double");
					Col.ColumnName = "Amount";
					Col.ReadOnly = true;
					Table.Columns.Add(Col);
					Col = new DataColumn();
					Col.DataType = Type.GetType("System.DateTime");
					Col.ColumnName = "Date";
					Col.ReadOnly = true;
					Table.Columns.Add(Col);
				}
				
				//Создаём DataSet для хранения таблицы
				dataSet = new DataSet();
				
				//Добавляем в него таблицу
    			dataSet.Tables.Add(Table);
    			
    			//Подключаемся к базе и выполняем запрос
				Connect.Open();
				OleDbDataReader reader = command.ExecuteReader();
				
    			//Наполняем таблицу данными из базы
				while(reader.Read())
				{
					if (reader.FieldCount == 3) {
						Row = Table.NewRow();
						Row["id"] = Convert.ToInt32(reader["id"]);
						Row["FirstName"] = reader["firstname"];
						Row["LastName"] = reader["lastname"];
						Table.Rows.Add(Row);
					}else if(reader.FieldCount == 5)
					{
						Row = Table.NewRow();
						Row["id"] = Convert.ToInt32(reader[0]);
						Row["Seller"] = reader[1];
						Row["Buyer"] = reader[2];
						Row["Amount"] = Convert.ToDouble(reader[3]);
						Row["Date"] = Convert.ToDateTime(reader[4]);
						Table.Rows.Add(Row);
					}
				}
				
				//Привязываем данные к полю вывода
				dgField.SetDataBinding(dataSet, "MainTable");
			}catch(Exception e){
				MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK);
			}finally{
				if(Connect.State == ConnectionState.Open) Connect.Close();
			}
		}
*/
	}
}
