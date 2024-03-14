using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace e_coblos
{
    public class user
    {
        private string nama;
        private string nik;
        private int id;
        private string status;

        public string Nama { get => nama; set => nama = value; }
        public string Nik { get => nik; set => nik = value; }
        public int Id { get => id; set => id = value; }
        public string Status { get => status; set => status = value; }

        string cnnString = "server=127.0.0.1;database=e-coblos;uid=root;pwd=";
        MySqlConnection myConnection;

        public user()
        {
            myConnection = new MySqlConnection(cnnString);
            myConnection.Open();
        }

        public void SimpanData(string setNama,string setNik)
        {
            Nama = setNama;
            Nik = setNik;

            if(myConnection.State == ConnectionState.Open)
            {
                string query = "INSERT INTO user(nama, nik) VALUES (@nama, @nik)";
                try
                {
                    var cmd = new MySqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@nama", setNama);
                    cmd.Parameters.AddWithValue("@nik", setNik);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil ditambahkan");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan" + ex.Message);
                }
            }
        }

        public void HapusData(int id)
        {
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    string query = "DELETE FROM user WHERE id = @id";
                    var cmd = new MySqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus");

                    query = "UPDATE user SET id = id - 1 WHERE id > @id";
                    cmd = new MySqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        public void EditData(int id, string nama, string nik)
        {
            if (myConnection.State == ConnectionState.Open)
            {
                string query = "UPDATE user SET nama = @nama, nik = @nik WHERE id = @id";
                try
                {
                    var cmd = new MySqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@nik", nik);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diubah");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SetUserStatus(int id, bool status)
        {
            if (myConnection.State == ConnectionState.Open)
            {
                string query = "UPDATE user SET status = @status WHERE id = @id";
                try
                {
                    var cmd = new MySqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Status pengguna berhasil diperbarui");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
        }

        public bool CheckUserStatus(int id)
        {
            if (myConnection.State == ConnectionState.Open)
            {
                string query = "SELECT status FROM user WHERE id = @id";
                try
                {
                    var cmd = new MySqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@id", id);
                    var result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        if (result is bool)
                        {
                            return (bool)result;
                        }
                        else if (result is string)
                        {
                            return result.ToString().ToLower() == "true"; 
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
            return false;
        }


    }

    public class DatabaseConnection
    {
        private string connectionString;

        public DatabaseConnection(string server, string database, string uid, string password)
        {
            connectionString = $"server={server};database={database};uid={uid};pwd={password}";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}