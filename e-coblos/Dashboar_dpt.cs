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
    public partial class Dashboar_dpt : Form
    {
        private DatabaseConnection dbConnection;
        private user newUser;
        public Dashboar_dpt()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("127.0.0.1", "e-coblos", "root", "");
            newUser = new user();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_nik_upload.Text) || string.IsNullOrEmpty(txt_upload_nama.Text))
                {
                    MessageBox.Show("Mohon lengkapi semua kolom untuk melanjutkan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                newUser.Nama = txt_upload_nama.Text;
                newUser.Nik = txt_nik_upload.Text;

                newUser.SimpanData(newUser.Nama, newUser.Nik);
                LoadDataToDataGridView();

                txt_nik_upload.Clear();
                txt_upload_nama.Clear();  
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Terjad Kesalahan" + ex);
            }
        }

        private void LoadDataToDataGridView()
        {
            try
            {
                dataGridView1.Rows.Clear();
                MySqlConnection connection = dbConnection.GetConnection();
                connection.Open();

                string query = "SELECT id, nama, nik, CASE WHEN status = 1 THEN 'Sudah Memilih' ELSE 'Belum Memilih' END AS Status FROM user";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["id"], reader["nama"], reader["nik"], reader["Status"]);
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan" + ex);
            }
        }


        private void btn_nav_paslon_Click(object sender, EventArgs e)
        {
            dashboard_admin pageAdmmi = new dashboard_admin();
            pageAdmmi.Show();
            this.Close();
        }

        private void btn_nav_dpt_Click(object sender, EventArgs e)
        {

        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                string nama_pemilih = dataGridView1.Rows[e.RowIndex].Cells["nama_penduduk"].Value.ToString();
                string nik = dataGridView1.Rows[e.RowIndex].Cells["nik"].Value.ToString();
                dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

                if (MessageBox.Show("Anda Yakin Ingin Mengedit Data Pemilih ?", "information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    edit_user pageEdit = new edit_user(id,nama_pemilih,nik);
                    pageEdit.ShowDialog();
                }
            }
            if (e.ColumnIndex == 5)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);

                if (MessageBox.Show("Anda Yakin Ingin Menghapus Data Pemilih ?", "information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    newUser.HapusData(id);
                    LoadDataToDataGridView();
                }
            }
        }

        private void Dashboar_dpt_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
        }
    }
}
