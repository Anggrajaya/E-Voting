using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Xamarin.Forms;

namespace e_coblos
{
    public partial class Dashboard_User : Form
    {
        private DatabaseConnection dbConnection;
        private paslon newPaslon;
        private user newUser;
        private string username;
        private string nik;

        public Dashboard_User(string username, string nik)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("127.0.0.1", "e-coblos", "root", "");
            newPaslon = new paslon();
            newUser = new user();
            this.username = username;
            this.nik = nik;
        }

        private void Dashboard_User_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            textBox1.Text= username;
            textBox2.Text= nik;

             int userId = GetUserID(username, nik);
        }

        private void LoadDataToDataGridView()
        {
            try
            {
                dataGridView1.Rows.Clear();
                MySqlConnection connection = dbConnection.GetConnection();
                connection.Open();

                string query = "SELECT * FROM paslon";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["no_paslon"].ToString(), reader["foto_paslon"], reader["nama_paslon"], reader["visi_misi_paslon"].ToString());
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int userId = GetUserID(username, nik);
                bool userStatus = newUser.CheckUserStatus(userId);

                if (!userStatus)
                {
                    if (MessageBox.Show("Anda Yakin Ingin Memilih Paslon Ini ?", "information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int no_paslon = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["no_paslon"].Value);
                        newPaslon.TambahSuara(no_paslon);

                        newUser.SetUserStatus(userId, true);

                        this.Close();
                        LogIn pageLogin = new LogIn();
                        pageLogin.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Anda sudah memilih paslon!");
                }
            }
        }

        private int GetUserID(string username, string nik)
        {
            int id = 0;
            try
            {
                MySqlConnection connection = dbConnection.GetConnection();
                connection.Open();

                string query = "SELECT id FROM user WHERE nama = @nama AND nik = @nik";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nama", username);
                cmd.Parameters.AddWithValue("@nik", nik);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    id = Convert.ToInt32(result);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mendapatkan ID pengguna: " + ex.Message);
            }
            return id;
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
