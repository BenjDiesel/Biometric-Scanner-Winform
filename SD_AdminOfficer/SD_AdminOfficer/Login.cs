using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

using System.IO;
using System.Security.Cryptography;

namespace SD_AdminOfficer
{
    
    public partial class Login : Form
    {
     //   string constring = @"Server=localhost; Database=sdtestdb;  UID =root; PWD=1234;";
        public Login()
        {
            InitializeComponent();
        }
            public static string CreateSHAHash(string Phrase)
        {
            SHA512Managed HashTool = new SHA512Managed();
            Byte[] PhraseAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Phrase));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PhraseAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please input Username and Password");
                return;
            }

            try
            {
                MySqlConnection con = new MySqlConnection(Helper.GetConnection());
                MySqlCommand com = new MySqlCommand();
                com.Connection = con;
                con.Open();
                com.CommandText = "SELECT * FROM employee WHERE username=@username AND password=@password AND position=@position";
                com.Parameters.AddWithValue("@username", txtUsername.Text);
                com.Parameters.AddWithValue("@password", CreateSHAHash(txtPassword.Text));
                com.Parameters.AddWithValue("@position", "Administration Officer");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();

                int count = ds.Tables[0].Rows.Count;

                if (count == 1)
                {
                    this.Hide();
                    Home home = new Home();
                    home.Show();
                }

                else
                {
                    MessageBox.Show("Invalid Account!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
