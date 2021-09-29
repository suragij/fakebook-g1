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
    public partial class ChangePassword : Form
    {
        public int IDuser;
        public ChangePassword(int userid)
        {
            InitializeComponent();
            IDuser = userid;
        }

        private void username_rig_TextChanged(object sender, EventArgs e)
        {
                    }

        private void back_Click(object sender, EventArgs e)
        {

        }

        private void sign_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None");
            MySqlCommand command;
            String insertQuery = "UPDATE fackbook.users SET Password=@Password , Name = @Name WHERE UserID = @UserID";

            connection.Open();
            command = new MySqlCommand(insertQuery, connection);
            if(password_rig.Text == c_password_rig.Text)
            {
                command.Parameters.Add("@Password", MySqlDbType.Text);
                command.Parameters.Add("@Name", MySqlDbType.Text);
                command.Parameters.Add("@UserID", MySqlDbType.Int32);
                command.Parameters["@Password"].Value = password_rig.Text;
                command.Parameters["@Name"].Value = name_rig.Text;
                command.Parameters["@UserID"].Value = IDuser;
            }
            else
            {
                MessageBox.Show("กรุณาใส่รหัสให้ตรงกัน");
            }
            
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Successful");
                this.Close();

            }
            else
            {
                MessageBox.Show("fail");
            }
            
        }

        private void password_rig_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
