using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace fakebook
{
    public partial class Signup : Form
    {
        
        public Signup()
        {
            InitializeComponent();
        }

        private void sign_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None");
            MySqlCommand command;
            String insertQuery = "INSERT INTO fackbook.users(UserID, Email, Name, Password,Picture) VALUES(@UserID, @Email, @Name, @Password,@Picture)";
            
            connection.Open();
            try
            {
                
                command = new MySqlCommand(insertQuery, connection);

                command.Parameters.Add("@UserID", MySqlDbType.Int32);
                command.Parameters.Add("@Email", MySqlDbType.Text);
                command.Parameters.Add("@Name", MySqlDbType.Text);
                command.Parameters.Add("@Password", MySqlDbType.Text);
                command.Parameters.Add("@Picture", MySqlDbType.Text);

                var rand = new Random();
                command.Parameters["@UserID"].Value = rand.Next(10000, 99999);
                command.Parameters["@Email"].Value = username_rig.Text;
                command.Parameters["@Password"].Value = password_rig.Text;
                command.Parameters["@Name"].Value = name_rig.Text;
                command.Parameters["@Picture"].Value = "profile.png";
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Successful");
                    Login page = new Login();
                    page.Show();
                    this.Close();
                }

                connection.Close();
            }
            catch 
            {
                MessageBox.Show("Error");
            }
            

        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            Login page = new Login();
            page.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void password_rig_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
