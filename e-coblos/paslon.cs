using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace e_coblos
{
    public class paslon
    {
        private string nama_paslon;
        private int no_paslon;
        private string visi_misi_paslon;
        private int perolehan_suara;
        private byte[] foto_paslon;

        public string Nama_paslon { get => nama_paslon; set => nama_paslon = value; }
        public int No_paslon { get => no_paslon; set => no_paslon = value; }
        public string Visi_misi_paslon { get => visi_misi_paslon; set => visi_misi_paslon = value; }
        public byte[] Foto_paslon { get => foto_paslon; set => foto_paslon = value; }
        public int Perolehan_suara { get => perolehan_suara; set => perolehan_suara = value; }

        string cnnString = "server=127.0.0.1;database=e-coblos;uid=root;pwd=";
        MySqlConnection myConnection;

        public paslon()
        {
            myConnection = new MySqlConnection(cnnString);
            myConnection.Open();
        }

        public void SimpanData(string setNama, int setNo, string setVisi, byte[] setFoto)
        {
            Nama_paslon = setNama;
            No_paslon = setNo;
            Visi_misi_paslon = setVisi;
            Foto_paslon = setFoto;

            if (myConnection.State == ConnectionState.Open)
            {
                string query = "INSERT INTO paslon(no_paslon, nama_paslon, visi_misi_paslon, foto_paslon) VALUES (@no_paslon, @nama_paslon, @visi_misi_paslon, @foto_paslon)";
                try
                {
                    var cmd = new MySqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@no_paslon", setNo);
                    cmd.Parameters.AddWithValue("@nama_paslon", setNama);
                    cmd.Parameters.AddWithValue("@visi_misi_paslon", setVisi);
                    cmd.Parameters.AddWithValue("@foto_paslon", setFoto);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil ditambahkan");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void HapusData(int no_paslon)
        {
            if (myConnection.State == ConnectionState.Open)
            {
                string query = "DELETE FROM paslon WHERE no_paslon = @no_paslon";
                try
                {
                    var cmd = new MySqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@no_paslon", no_paslon);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void EditData(int no_paslon, string setNama, string setVisi, byte[] setFoto)
        {
            if (myConnection.State == ConnectionState.Open)
            {
                string query = "UPDATE paslon SET nama_paslon = @nama_paslon, visi_misi_paslon = @visi_misi_paslon, foto_paslon = @foto_paslon WHERE no_paslon = @no_paslon";
                try
                {
                    var cmd = new MySqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@no_paslon", no_paslon);
                    cmd.Parameters.AddWithValue("@nama_paslon", setNama);
                    cmd.Parameters.AddWithValue("@visi_misi_paslon", setVisi);
                    cmd.Parameters.AddWithValue("@foto_paslon", setFoto);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diubah");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void TambahSuara(int no_paslon)
        {
            if (myConnection.State == ConnectionState.Open)
            {
                string query = "UPDATE paslon SET perolehan_suara = perolehan_suara + 1 WHERE no_paslon = @no_paslon";
                try
                {
                    var cmd = new MySqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@no_paslon", no_paslon);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Suara berhasil ditambahkan untuk paslon nomor " + no_paslon);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        ~paslon()
        {
            if (myConnection != null && myConnection.State == ConnectionState.Open)
                myConnection.Close();
        }
    }
}
