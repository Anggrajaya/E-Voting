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

namespace e_coblos
{
    public partial class LogIn : Form
    {
        private DatabaseConnection dbConnection;

        public LogIn()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("127.0.0.1", "e-coblos", "root", "");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txt_nama_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_nik_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_nama_login.Text;
            string nik = txt_nik_login.Text;


            string query = "SELECT COUNT(*) FROM user WHERE nama = @nama AND nik = @nik";

            using (MySqlConnection connection = dbConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nama", username);
                    cmd.Parameters.AddWithValue("@nik", nik);

                    connection.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        if (username == "admin" && nik == "admin")
                        {
                            MessageBox.Show("LogIn Berhasil Sebagai Admin");
                            dashboard_admin pageadmin = new dashboard_admin();
                            pageadmin.Show();
                            this.Hide();   
                        }
                        else
                        {
                            MessageBox.Show("LogIn Berhasil Sebagai User");

                            this.Hide();

                            Dashboard_User pageuser = new Dashboard_User(username,nik);

                            pageuser.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Anda TIdak Terdaftar!!!");
                    }
                }
            }
        }
    }
}
