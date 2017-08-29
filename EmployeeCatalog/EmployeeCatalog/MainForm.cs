using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Controls;

namespace EmployeeCatalog
{
    public partial class MainForm : Form
    {
        /*		private DataGrid dgField;
                private DataSet dataSet;
                private ComboBox cbTable;
                private OleDbConnection Connect;
                private OleDbCommand ComBuyers, ComSellers, ComSales;
        */
        formLogin fmLogin;
        private SqlConnection Connect;
        private SqlCommand comGetData, comInsert, comEdit, comDelete;
        /*
		private Label lHeader = new Label();
		private Panel buttonPanel = new Panel();
		private DataGridView dgvEmployees = new DataGridView();
		private Button btnAddEmployee = new Button();
		private Button btnEditEmployee = new Button();
		private Button btnDeleteEmployee = new Button();
		*/

        public MainForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load);
        }

        private void MainForm_Load(Object seneder, EventArgs e)
        {
            do
            {
                fmLogin = new formLogin();
                if (fmLogin.ShowDialog() != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            } while (!SetupDbConnect());
            GetDataFormDB();
        }

        private bool SetupDbConnect()
        {
            //Задаём параметры подключения
            Connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Employees"].ConnectionString);
            var pass = new System.Security.SecureString();
            fmLogin.maskedTextBox1.Text.ToList().ForEach(pass.AppendChar);
            pass.MakeReadOnly();
            Connect.Credential = new SqlCredential(fmLogin.textBox1.Text, pass);
            try
            {
                Connect.Open();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally { Connect.Close(); }
            return true;
        }

        private void SetupDataGridView()
        {

            /*
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
			*/

        }

        private void GetDataFormDB()
        {
            SqlDataReader reader;
            try
            {
                Connect.Open();
                SqlCommand com = new SqlCommand
                {
                    CommandText = "EXECUTE getEmployees",
                    Connection = Connect
                };
                reader = com.ExecuteReader();
                List<Employee> table = new List<Employee>();
                while (reader.Read())
                {
                    table.Add(new Employee
                    {
                        id = (int)reader["id"],
                        surname = (reader.IsDBNull(1) ? "" : reader.GetString(1)),
                        name = (reader.IsDBNull(2) ? "" : reader.GetString(2)),
                        patronymic = (reader.IsDBNull(3) ? "" : reader.GetString(3)),
                        position = (reader.IsDBNull(4) ? "" : reader.GetString(4)),
                        admission = (reader.IsDBNull(5) ? "" : reader.GetString(5)),
                        dismissal = (reader.IsDBNull(6) ? "" : reader.GetString(6)),
                        photo = (reader.IsDBNull(7) ? "" : reader.GetString(7)),

                    });
                }
                dataGridView1.DataSource = table;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[7].Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "DB Error");
            }
            finally
            {
                Connect.Close();
            }
        }

        /*
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
		*/
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
