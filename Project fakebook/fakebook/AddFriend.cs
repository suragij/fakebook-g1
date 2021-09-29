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
    public partial class AddFriend : Form
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
        public AddFriend(int userid)
        {
            InitializeComponent();
            userId = userid;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            connection.Open();

            string sql = "SELECT * FROM userfriends WHERE UserID = '" + userId + "' or FriendID ='"+ userId + "'";
            using var cmd = new MySqlCommand(sql, connection);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                if (rdr.GetUInt32(1) == userId)
                {
                    array1.Add(rdr.GetInt32(2));
                }
                else if(rdr.GetUInt32(2) == userId)
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
                bool run = true;
                foreach (int num in array1)
                {
                    
                    if (num==rdr1.GetInt32(0))
                    {
                        run = false;
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
            MySqlConnection connection2 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            string sql2 = "SELECT * FROM friendrequests WHERE UserID = '" + userId + "' ";
            using var cmd2 = new MySqlCommand(sql2, connection2);
            connection2.Open();
            using MySqlDataReader rdr2 = cmd2.ExecuteReader();


            while (rdr2.Read())
            {
                int x = 0;
                foreach(int a in id_friend)
                {
                    
                    if(a == rdr2.GetInt32(2))
                    {
                        if (x == 0)
                        {
                            btnadd1.Text = "ส่งคำขอแล้ว";
                        }
                        if (x == 1)
                        {
                            btnadd2.Text = "ส่งคำขอแล้ว";
                        }
                        if (x == 2)
                        {
                            btnadd3.Text = "ส่งคำขอแล้ว";
                        }
                        if (x == 3)
                        {
                            btnadd4.Text = "ส่งคำขอแล้ว";
                        }
                    }
                    x += 1;
                }
                
            }

            connection2.Close();
            MySqlConnection connection3 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            string sql3 = "SELECT * FROM friendrequests WHERE FriendID = '" + userId + "' ";
            using var cmd3 = new MySqlCommand(sql3, connection3);
            connection3.Open();
            using MySqlDataReader rdr3 = cmd3.ExecuteReader();


            while (rdr3.Read())
            {
                int x = 0;
                foreach (int a in id_friend)
                {

                    if (a == rdr3.GetInt32(1))
                    {
                        if (x == 0)
                        {
                            btnadd1.Text = "ตอบรับคำขอ";
                        }
                        if (x == 1)
                        {
                            btnadd2.Text = "ตอบรับคำขอ";
                        }
                        if (x == 2)
                        {
                            btnadd3.Text = "ตอบรับคำขอ";
                        }
                        if (x == 3)
                        {
                            btnadd4.Text = "ตอบรับคำขอ";
                        }
                    }
                    x += 1;
                }

            }

            connection3.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void afload_Click(object sender, EventArgs e)
        {
            if(end_p < name.ToArray().Length)
            {
                start_p += 1;
                end_p += 1;
                change_scroll();
                preload.Visible = true;
            }
            
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

        private void btnadd1_Click(object sender, EventArgs e)
        {
            if (btnadd1.Text == "ตอบรับคำขอ")
            {
                addfriend(0);
            }
            else if (btnadd1.Text != "ส่งคำขอแล้ว")
            {
                friend(0);
            }
            
        }


        public void addfriend(int number)
        {
            
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            connection.Open();

            string sql = "DELETE FROM friendrequests WHERE FriendID = '"+ userId + "' and UserID = '" + id_friend[number] + "' ";
            using var cmd = new MySqlCommand(sql, connection);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            
            connection.Close();
            if (number == 0)
            {
                btnadd1.Text = "เพิ่มเพื่อนแล้ว";
            }
            if (number == 1)
            {
                btnadd2.Text = "เพิ่มเพื่อนแล้ว";
            }
            if (number == 2)
            {
                btnadd3.Text = "เพิ่มเพื่อนแล้ว";
            }
            if (number == 3)
            {
                btnadd4.Text = "เพิ่มเพื่อนแล้ว";
            }
            MySqlConnection connection1 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None");
            MySqlCommand command1;
            String insertQuery1 = "INSERT INTO fackbook.userfriends(UserFriendID, UserID, FriendID) VALUES(@RequestID, @UserID, @FriendID)";

            connection1.Open();
            command1 = new MySqlCommand(insertQuery1, connection1);

            command1.Parameters.Add("@RequestID", MySqlDbType.Int32);
            command1.Parameters.Add("@UserID", MySqlDbType.Int32);
            command1.Parameters.Add("@FriendID", MySqlDbType.Int32);

            command1.Parameters["@RequestID"].Value = Int32.Parse(id_friend[number].ToString()) + userId;
            command1.Parameters["@UserID"].Value = userId;
            command1.Parameters["@FriendID"].Value = Int32.Parse(id_friend[number].ToString());
            if (command1.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("successful");
            }
                
        }
        public void friend(int number)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None");
            MySqlCommand command;
            String insertQuery = "INSERT INTO fackbook.friendrequests(RequestID, UserID, FriendID, RequestDate) VALUES(@RequestID, @UserID, @FriendID, @RequestDate)";

            connection.Open();
            command = new MySqlCommand(insertQuery, connection);

            command.Parameters.Add("@RequestID", MySqlDbType.Int32);
            command.Parameters.Add("@UserID", MySqlDbType.Int32);
            command.Parameters.Add("@FriendID", MySqlDbType.Int32);
            command.Parameters.Add("@RequestDate", MySqlDbType.Text);

            var rand = new Random();
            command.Parameters["@RequestID"].Value = Int32.Parse(id_friend[number].ToString())+userId;
            command.Parameters["@UserID"].Value = userId;
            command.Parameters["@FriendID"].Value = Int32.Parse(id_friend[number].ToString());
            command.Parameters["@RequestDate"].Value = new DateTime().ToString();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("ส่งคำขอเป็นเพื่อนแล้ว");
                if (number == 0)
                {
                    btnadd1.Text = "ส่งคำขอแล้ว";
                }
                if (number == 1)
                {
                    btnadd2.Text = "ส่งคำขอแล้ว";
                }
                if (number == 2)
                {
                    btnadd3.Text = "ส่งคำขอแล้ว";
                }
                if (number == 3)
                {
                    btnadd4.Text = "ส่งคำขอแล้ว";
                }
            }

            connection.Close();
        }

        private void AddFriend_Load(object sender, EventArgs e)
        {

        }

        private void btnadd2_Click_1(object sender, EventArgs e)
        {
            if (btnadd2.Text == "ตอบรับคำขอ")
            {
                addfriend(1);
            }
            else if (btnadd2.Text != "ส่งคำขอแล้ว")
            {
                friend(1);
            }
        }

        private void btnadd3_Click(object sender, EventArgs e)
        {
            if (btnadd3.Text == "ตอบรับคำขอ")
            {
                addfriend(2);
            }
            else if (btnadd3.Text != "ส่งคำขอแล้ว")
            {
                friend(2);
            }
        }

        private void btnadd4_Click(object sender, EventArgs e)
        {
            if (btnadd4.Text == "ตอบรับคำขอ")
            {
                addfriend(3);
            }
            else if (btnadd4.Text != "ส่งคำขอแล้ว")
            {
                friend(3);
            }
        }

        private void profile3_Click(object sender, EventArgs e)
        {

        }

        private void name3_Click(object sender, EventArgs e)
        {

        }

        private void profile2_Click(object sender, EventArgs e)
        {

        }

        private void name2_Click(object sender, EventArgs e)
        {

        }
    }
}
