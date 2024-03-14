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
    public partial class edit_user : Form
    {
        private int id;
        private string nama_Pemilih;
        private string nik;
        private user newUser;

        public edit_user(int id, string nama_pemilih, string nik)
        {
            InitializeComponent();
            newUser = new user();
            this.id = id;
            this.nama_Pemilih = nama_pemilih;
            this.nik = nik;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            editData(id);
        }

        private void editData(int id)
        {
            try
            {
                string namaBaru = txt_update_nama_pemilih.Text;
                string nikBaru = txt_update_nik.Text;

                // Perbaiki pemanggilan metode EditData agar sesuai dengan parameter yang diperlukan
                newUser.EditData(id, namaBaru, nikBaru);

                MessageBox.Show("Data Paslon Berhasil di Perbarui !");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex.Message);
            }
        }

        private void edit_user_Load(object sender, EventArgs e)
        {
            try
            {
                txt_update_nama_pemilih.Text = nama_Pemilih;
                txt_update_nik.Text = nik;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex.Message);
            }
        }
    }
}
