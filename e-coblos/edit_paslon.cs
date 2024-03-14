using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_coblos
{
    public partial class edit_paslon : Form
    {
        private int no_paslon;
        private string nama_paslon;
        private string visi_misi;
        private Image foto_paslon;
        private paslon newPaslon;

        public edit_paslon(int no_paslon, string nama_paslon, string visi_misi)
        {
            InitializeComponent();
            newPaslon = new paslon();
            this.no_paslon = no_paslon;
            this.nama_paslon=nama_paslon;
            this.visi_misi = visi_misi;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void SetFotoPaslon(Image foto_paslon)
        {
            this.foto_paslon = foto_paslon;
            pictureBoxFotoPaslon.Image = foto_paslon;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            editData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
                        // Set the image to the PictureBox for display
                        pictureBoxFotoPaslon.Image = Image.FromStream(new MemoryStream(imageBytes));

                        // Set the foto_paslon property of paslon object
                        foto_paslon = Image.FromStream(new MemoryStream(imageBytes));
                    }
                    else
                    {
                        MessageBox.Show("Objek paslon belum diinisialisasi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void edit_paslon_Load_1(object sender, EventArgs e)
        {
            try
            {
                txt_update_nama_paslon.Text = nama_paslon;
                rich_txt_update_visi_misi_passlon.Text = visi_misi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan" + ex);
            }
        }

        private void btn_update_gambar_Click(object sender, EventArgs e)
        {
            upload_image();
        }

        private void editData()
        {
            try
            {
                string namaBaru = txt_update_nama_paslon.Text;
                string visiBaru = rich_txt_update_visi_misi_passlon.Text;
                byte[] fotoPaslonBaru = (foto_paslon != null) ? ImageToByteArray(foto_paslon) : null;

                newPaslon.EditData(no_paslon, namaBaru, visiBaru, fotoPaslonBaru);

                MessageBox.Show("Data Paslon Berhasil di Perbarui !");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex.Message);
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void numeric_update_no_paslon_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
