using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace fakebook
{
    
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void username_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void sign_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup page = new Signup();
            page.Show();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");
            
            connection.Open();

            string sql = "SELECT * FROM users WHERE Email = '"+username_login.Text+ "' AND Password = '" + password_login.Text + "'   ";
            using var cmd = new MySqlCommand(sql, connection);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            bool login = false;
            while (rdr.Read())
            {
                login = true;
                
            }
            if (login)
            {
                
                Main m = new Main(rdr.GetInt32(0),rdr.GetString(1),rdr.GetString(2));
                m.Show();
                this.Hide();
                
                
            }
            else
            {
                MessageBox.Show("Fail");
            }

        }
    }
}
