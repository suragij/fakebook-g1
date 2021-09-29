using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace fakebook
{
    public partial class Friend : Form
    {
        public int userId;
        public ArrayList array1 = new ArrayList();
        public ArrayList array2 = new ArrayList();
        public ArrayList name = new ArrayList();
        public ArrayList profile = new ArrayList();
        public ArrayList id_friend = new ArrayList();
        public ArrayList re_friend = new ArrayList();
        public int start_p = 0;
        public int end_p;
        public Friend(int userid)
        {
            InitializeComponent();
            userId = userid;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            connection.Open();

            string sql = "SELECT * FROM userfriends WHERE UserID = '" + userId + "' or FriendID ='" + userId + "'";
            using var cmd = new MySqlCommand(sql, connection);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr.GetUInt32(1) == userId)
                {
                    array1.Add(rdr.GetInt32(2));
                }
                else if (rdr.GetUInt32(2) == userId)
                {
                    array1.Add(rdr.GetInt32(1));
                }

            }
            connection.Close();
            MySqlConnection connection1 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            string sql1 = "SELECT * FROM users WHERE not UserID = '" + userId + "' ";
            using var cmd1 = new MySqlCommand(sql1, connection1);
            connection1.Open();
            using MySqlDataReader rdr1 = cmd1.ExecuteReader();


            while (rdr1.Read())
            {
                bool run = false;
                foreach (int num in array1)
                {

                    if (num == rdr1.GetInt32(0))
                    {
                        run = true;
                        continue;
                    }
                }
                if (run)
                {
                    array2.Add(rdr1.GetInt32(0));
                    name.Add(rdr1.GetString(2));
                    profile.Add(rdr1.GetString(6));
                    id_friend.Add(rdr1.GetInt32(0));
                }

            }

            end_p = name.ToArray().Length;
            change_scroll();
            if (name.ToArray().Length > 4)
            {
                afload.Visible = true;
            }

        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public void change_scroll()
        {
            name1.Visible = false;
            name2.Visible = false;
            name3.Visible = false;
            name4.Visible = false;
            profile1.Visible = false;
            profile2.Visible = false;
            profile3.Visible = false;
            profile4.Visible = false;
            btnadd1.Visible = false;
            btnadd2.Visible = false;
            btnadd3.Visible = false;
            btnadd4.Visible = false;
            if (end_p - start_p >= 4)
            {
                end_p = start_p + 4;
                name4.Text = name[start_p + 3].ToString();
                name4.Visible = true;
                btnadd4.Visible = true;
                profile4.Visible = true;
                profile4.Image = resizeImage(Image.FromFile(profile[start_p + 3].ToString()), new Size(80, 79));
            }
            if (end_p - start_p >= 3)
            {
                name3.Text = name[start_p + 2].ToString();
                name3.Visible = true;
                btnadd3.Visible = true;
                profile3.Visible = true;
                profile3.Image = resizeImage(Image.FromFile(profile[start_p + 2].ToString()), new Size(80, 79));
            }
            if (end_p - start_p >= 2)
            {
                name2.Text = name[start_p + 1].ToString();
                name2.Visible = true;
                btnadd2.Visible = true;
                profile2.Visible = true;
                profile2.Image = resizeImage(Image.FromFile(profile[start_p + 1].ToString()), new Size(80, 79));
            }
            if (end_p - start_p >= 1)
            {
                name1.Text = name[start_p].ToString();
                name1.Visible = true;
                btnadd1.Visible = true;
                profile1.Visible = true;
                profile1.Image = resizeImage(Image.FromFile(profile[start_p].ToString()), new Size(80, 79));
            }

        }
        private void btnadd1_Click(object sender, EventArgs e)
        {
            unfriend(0);
        }

        private void btnadd2_Click(object sender, EventArgs e)
        {
            unfriend(1);
        }

        private void btnadd3_Click(object sender, EventArgs e)
        {
            unfriend(2);
        }

        private void btnadd4_Click(object sender, EventArgs e)
        {
            unfriend(3);
        }

        private void preload_Click(object sender, EventArgs e)
        {
            if (start_p > 1)
            {
                start_p -= 1;
                end_p -= 1;
                change_scroll();
            }
        }

        private void afload_Click(object sender, EventArgs e)
        {
            if (end_p < name.ToArray().Length)
            {
                start_p += 1;
                end_p += 1;
                change_scroll();
                preload.Visible = true;
            }
        }

        public void unfriend(int number)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            connection.Open();

            string sql = "DELETE FROM userfriends WHERE FriendID = '" + id_friend[number] + "' and UserID = '" + userId + "' or FriendID = '" + userId + "' and UserID = '" + id_friend[number] + "'  ";
            using var cmd = new MySqlCommand(sql, connection);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            MessageBox.Show("successful");
            this.Close();

            connection.Close();
        }
    }
}
