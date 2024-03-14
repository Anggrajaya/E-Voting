using e_coblos;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace e_coblos
{
    public partial class dashboard_admin : Form
    {
        private DatabaseConnection dbConnection;
        private paslon newPaslon;

        public dashboard_admin()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("127.0.0.1", "e-coblos", "root", "");
            newPaslon = new paslon();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txt_nama_paslon_upload_TextChanged(object sender, EventArgs e)
        {

        }

        private void numeric_paslon_upload_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rich_txt_visi_paslon_upload_TextChanged(object sender, EventArgs e)
        {

        }

        private void upload_image()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg, *.png, *.jpeg)|*.jpg;*.png;*.jpeg";
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string imagePath = dialog.FileName;
                    byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
                    if (newPaslon != null)
                    {
                        newPaslon.Foto_paslon = imageBytes;
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            Image image = Image.FromStream(ms);
                        }
                        imageBytes = null;
                    }
                    else
                    {
                        MessageBox.Show("Objek paslon belum diinisialisasi.");
                    }
                    imageBytes = null;
                    imagePath = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_nama_paslon_upload.Text) || numeric_paslon_upload.Value == 0 || string.IsNullOrEmpty(rich_txt_visi_paslon_upload.Text))
                {
                    MessageBox.Show("Mohon lengkapi semua kolom untuk melanjutkan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int noPaslon = (int)numeric_paslon_upload.Value;

                if (NoSama(noPaslon))
                {
                    MessageBox.Show("Nomor paslon sudah ada dalam database. Silakan pilih nomor paslon lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                newPaslon.Nama_paslon = txt_nama_paslon_upload.Text;
                newPaslon.No_paslon = (int)numeric_paslon_upload.Value;
                newPaslon.Visi_misi_paslon = rich_txt_visi_paslon_upload.Text;
                newPaslon.SimpanData(newPaslon.Nama_paslon, newPaslon.No_paslon, newPaslon.Visi_misi_paslon, newPaslon.Foto_paslon);

                txt_nama_paslon_upload.Clear();
                rich_txt_visi_paslon_upload.Clear();
                numeric_paslon_upload.Value = 0;
                if (dataGridView1.Rows.Count == 0)
                {
                    LoadDataToDataGridView();
                }
                else
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = newPaslon.No_paslon.ToString();
                    newRow.Cells[1].Value = newPaslon.Foto_paslon;
                    newRow.Cells[2].Value = newPaslon.Nama_paslon;
                    newRow.Cells[3].Value = newPaslon.Visi_misi_paslon;
                    dataGridView1.Rows.Add(newRow);

                    dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex.Message);
            }

        }

        private bool NoSama(int noPaslon)
        {
            bool exists = false;
            try
            {
                MySqlConnection connection = dbConnection.GetConnection();
                connection.Open();
                string query = "SELECT COUNT(*) FROM paslon WHERE no_paslon = @noPaslon";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@noPaslon", noPaslon);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                exists = count > 0;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memeriksa nomor paslon: " + ex.Message);
            }
            return exists;
        }

        private void btn_upload_foto_paslon_Click(object sender, EventArgs e)
        {
            upload_image();
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
                        dataGridView1.Rows.Add(reader["no_paslon"].ToString(), reader["foto_paslon"], reader["nama_paslon"], reader["visi_misi_paslon"].ToString(), reader["perolehan_suara"].ToString());
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void dashboard_admin_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int no_paslon = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["no_paslon"].Value);
                string nama_paslon = dataGridView1.Rows[e.RowIndex].Cells["nama"].Value.ToString();
                string visi_misi = dataGridView1.Rows[e.RowIndex].Cells["visi_misi"].Value.ToString();
                byte[] foto_paslon = (byte[])dataGridView1.Rows[e.RowIndex].Cells["foto_paslon"].Value;
                dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

                if (MessageBox.Show("Anda Yakin Ingin Mengedit Data Paslon ?", "information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    edit_paslon pageEdit = new edit_paslon(no_paslon, nama_paslon, visi_misi);
                    pageEdit.SetFotoPaslon(Image.FromStream(new MemoryStream(foto_paslon)));
                    pageEdit.ShowDialog();
                }
            }
            else if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                int no_paslon = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["no_paslon"].Value);

                if (MessageBox.Show("Anda Yakin Ingin Menghapus Data Paslon ?", "information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    newPaslon.HapusData(no_paslon);
                    LoadDataToDataGridView();
                }

                return;
            }
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void btn_nav_dpt_Click(object sender, EventArgs e)
        {
            Dashboar_dpt PageDpt = new Dashboar_dpt();
            PageDpt.Show();
            this.Close();
        }

        private void dashboard_admin_Load_1(object sender, EventArgs e)
        {        
            LoadDataToDataGridView();
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }
    }
}
