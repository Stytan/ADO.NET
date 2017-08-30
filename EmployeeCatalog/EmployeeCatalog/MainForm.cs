using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace EmployeeCatalog
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Форма входа
        /// </summary>
        formLogin fmLogin;
        /// <summary>
        /// Соединение с базой
        /// </summary>
        private SqlConnection connect;

        public MainForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load);
        }

        private void MainForm_Load(Object seneder, EventArgs e)
        {
            do
            {
                //Запрашиваем логин и пароль
                fmLogin = new formLogin();
                if (fmLogin.ShowDialog() != DialogResult.OK)
                {
                    //Если не ОК - завершаемся
                    Environment.Exit(0);
                }
                //пока не подключимся к базе
            } while (!SetupDbConnect());
            //Обновляем таблицу
            GetDataFormDB();
            labelUser.Text += fmLogin.textBox1.Text;
        }

        /// <summary>
        /// Проверяет возможность соединения с базой под заданными учетными данными
        /// </summary>
        /// <returns>true - соединение успешно</returns>
        private bool SetupDbConnect()
        {
            //Задаём параметры подключения
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Employees"].ConnectionString);
            //Задаём учётные данные
            var pass = new System.Security.SecureString();
            fmLogin.maskedTextBox1.Text.ToList().ForEach(pass.AppendChar);
            pass.MakeReadOnly();
            connect.Credential = new SqlCredential(fmLogin.textBox1.Text, pass);
            //Проверяем возможность соединения
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally { connect.Close(); }
            return true;
        }

        /// <summary>
        /// Получает данные из БД и заполняет таблицу
        /// </summary>
        private void GetDataFormDB()
        {
            SqlDataReader reader = null;
            try
            {
                connect.Open();
                SqlCommand com = new SqlCommand
                {
                    //Процедура возвращает таблицу сотрудников
                    CommandText = "EXECUTE getEmployees",
                    Connection = connect
                };
                reader = com.ExecuteReader();
                //Заполняем список значениями из базы
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
                //Заполняем DataGridView
                dataGridView1.DataSource = table;
                //Скрываем столбцы id и photo
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["photo"].Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "DB Error");
            }
            finally
            {
                reader.Close();
                connect.Close();
            }
        }

        /// <summary>
        /// Обновляет фото при выборе сотрудника
        /// </summary>
        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            picBoxPhoto.ImageLocation = (string)(dataGridView1.CurrentRow.Cells["photo"].Value ?? "");
            picBoxPhoto.Load();
        }

        /// <summary>
        /// Удаляет сотрудника из базы
        /// </summary>
        void btnDelete_Click(object sender, EventArgs e)
        {
            //Если выбрана строка
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    connect.Open();
                    SqlCommand com = new SqlCommand
                    {
                        //Процедура удаляет строку из базы по её id
                        CommandText = "EXECUTE deleteEmployeeById " + (int)dataGridView1.CurrentRow.Cells["id"].Value,
                        Connection = connect
                    };
                    MessageBox.Show(com.ExecuteNonQuery() + " record deleted");
                    //Обновляем таблицу
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connect.Close();
                }
                GetDataFormDB();
            }
        }

        /// <summary>
        /// Добавляет сотрудника в базу
        /// </summary>
        void btnAdd_Click(object sender, EventArgs e)
        {
            //Форма добавления/редактирования сотрудника
            editForm fmEdit = new editForm();
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    connect.Open();
                    //Процедура добавляет данные сотрудника по все таблицы БД
                    string comText = "EXECUTE addEmployee '"
                                     + fmEdit.textBoxSurname.Text + "', '"
                                     + fmEdit.textBoxName.Text + "', '"
                                     + fmEdit.textBoxPatronymic.Text + "', '"
                                     + fmEdit.textBoxPosition.Text + "', '"
                                     + fmEdit.textBoxAdmission.Text + "', '"
                                     + fmEdit.textBoxDismissal.Text + "', '"
                                     + fmEdit.pictureBox1.ImageLocation + "'";
                    SqlCommand com = new SqlCommand
                    {
                        CommandText = comText,
                        Connection = connect
                    };
                    MessageBox.Show(com.ExecuteNonQuery() + " record added");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connect.Close();
                }
                GetDataFormDB();
            }
        }

        /// <summary>
        /// Редактирует данные выбранного сотрудника в БД
        /// </summary>
        void btnEdit_Click(object sender, EventArgs e)
        {
            editForm fmEdit = new editForm();
            DataGridViewCellCollection dc = dataGridView1.CurrentRow.Cells;
            //Заполняем форму данными редактируемого сотрудника
            fmEdit.textBoxSurname.Text = (string)(dc["surname"].Value ?? "");
            fmEdit.textBoxName.Text = (string)(dc["name"].Value ?? "");
            fmEdit.textBoxPatronymic.Text = (string)(dc["patronymic"].Value ?? "");
            fmEdit.textBoxPosition.Text = (string)(dc["position"].Value ?? "");
            fmEdit.textBoxAdmission.Text = (string)(dc["admission"].Value ?? "");
            fmEdit.textBoxDismissal.Text = (string)(dc["dismissal"].Value ?? "");
            fmEdit.pictureBox1.ImageLocation = (string)(dc["photo"].Value ?? "");
            fmEdit.pictureBox1.Load();
            fmEdit.Text = "Edit employee";
            fmEdit.buttonAdd.Text = "Save";
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    connect.Open();
                    //Процедура обновляет данные сотрудника во всех таблицах БД по его id
                    string comText = "EXECUTE updateEmployeeById "
                                     + (int)dc["id"].Value + ", '"
                                     + fmEdit.textBoxSurname.Text + "', '"
                                     + fmEdit.textBoxName.Text + "', '"
                                     + fmEdit.textBoxPatronymic.Text + "', '"
                                     + fmEdit.textBoxPosition.Text + "', '"
                                     + fmEdit.textBoxAdmission.Text + "', '"
                                     + fmEdit.textBoxDismissal.Text + "', '"
                                     + fmEdit.pictureBox1.ImageLocation + "'";
                    SqlCommand com = new SqlCommand
                    {
                        CommandText = comText,
                        Connection = connect
                    };
                    MessageBox.Show(com.ExecuteNonQuery() + " record updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connect.Close();
                }
                GetDataFormDB();
            }
        }
    }
}
