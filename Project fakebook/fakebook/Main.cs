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
    public partial class Main : Form
    {
        public int post_choose = 0;
        public string image_post = "";
        public int iduser;
        public ArrayList array1 = new ArrayList();
        public ArrayList array_post = new ArrayList();
        public string email_login;
        public Main(int userid, string email, string name)
        {
            InitializeComponent();
            email_login = email;
            iduser = userid;
            name_login.Text = name;
            show_name.Text = name;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            connection.Open();

            string sql = "SELECT Picture FROM users WHERE Email = '" + email_login + "' ";
            using var cmd = new MySqlCommand(sql, connection);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                if (rdr.GetString(0) != "none")
                {
                    pictureBox4.Image = resizeImage(Image.FromFile(rdr.GetString(0)), new Size(24, 24));
                    pictureBox1.Image = resizeImage(Image.FromFile(rdr.GetString(0)), new Size(50, 50));
                    profile_login.Image = resizeImage(Image.FromFile(rdr.GetString(0)), new Size(50, 50));
                    profile_show.Image = resizeImage(Image.FromFile(rdr.GetString(0)), new Size(100, 100));
                }
                else
                {
                    pictureBox4.Image = resizeImage(Image.FromFile("profile.png"), new Size(24, 24));
                    pictureBox1.Image = resizeImage(Image.FromFile("profile.png"), new Size(50, 50));
                    profile_login.Image = resizeImage(Image.FromFile("profile.png"), new Size(50, 50));
                    profile_show.Image = resizeImage(Image.FromFile("profile.png"), new Size(100, 100));
                }
            }
            MySqlConnection connection3 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            connection3.Open();

            string sql3 = "SELECT * FROM userfriends WHERE UserID = '" + userid + "' or FriendID ='" + userid + "'";
            using var cmd3 = new MySqlCommand(sql3, connection3);

            using MySqlDataReader rdr3 = cmd3.ExecuteReader();

            while (rdr3.Read())
            {
                if (rdr3.GetUInt32(1) == userid)
                {
                    array1.Add(rdr3.GetInt32(2));
                }
                else if (rdr3.GetUInt32(2) == userid)
                {
                    array1.Add(rdr3.GetInt32(1));
                }

            }
            connection3.Close();
            MySqlConnection connection1 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            connection1.Open();
            string sql1 = "SELECT * FROM posts";
            using var cmd1 = new MySqlCommand(sql1, connection1);

            using MySqlDataReader rdr1 = cmd1.ExecuteReader();

            while (rdr1.Read())
            {
                foreach(int a in array1)
                {
                    if (a == rdr1.GetUInt32(3) || userid == rdr1.GetUInt32(3))
                    {
                        array_post.Add(rdr1.GetUInt32(0));
                    }
                }
              
            }
            connection1.Close();
            load_feed();
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if(panel3.Height == 0)
            {
                panel3.Height = 190;
            }
            else
            {
                panel3.Height = 0;
            }
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files | *.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    profile_login.Image = resizeImage(Image.FromFile(openFileDialog1.FileName), new Size(50, 50));
                    profile_show.Image = resizeImage(Image.FromFile(openFileDialog1.FileName), new Size(100, 100));
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None");
                    MySqlCommand command;
                    String insertQuery = "UPDATE fackbook.users SET Picture=@Picture WHERE UserID = @UserID";

                    connection.Open();
                    command = new MySqlCommand(insertQuery, connection);
                    if(System.IO.File.Exists("./image" + iduser + ".jpg"))
                    {
                        System.IO.File.Delete("./image" + iduser + ".jpg");
                    }
                    System.IO.File.Copy(openFileDialog1.FileName, "./image"+iduser+".jpg");
                    command.Parameters.Add("@Picture", MySqlDbType.Text);
                    command.Parameters.Add("@UserID", MySqlDbType.Int32);
                    command.Parameters["@Picture"].Value = "./image" + iduser + ".jpg";
                    command.Parameters["@UserID"].Value = iduser;
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Successful");

                    }
                    else
                    {
                        MessageBox.Show("fail");
                    }

                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddFriend add = new AddFriend(iduser);
            add.Show();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            Login page = new Login();
            page.Show();
            this.Close();
        }

        private void change_btn_Click(object sender, EventArgs e)
        {
            ChangePassword page = new ChangePassword(iduser);
            page.Show();
        }

        private void list_btn_Click(object sender, EventArgs e)
        {

            Friend page = new Friend(iduser);
            page.Show();
        }

        private void profile_login_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = !panel4.Visible;
            panel5.Visible = !panel5.Visible;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files | *.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    image_post = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(image_post != "" && textBox1.Text != "")
            {
                MySqlConnection connection1 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None");
                MySqlCommand command1;
                String insertQuery1 = "INSERT INTO fackbook.posts(PostID, PostText, Picture,UserID) VALUES(@PostID, @PostText, @Picture, @UserID)";
                
                connection1.Open();
                command1 = new MySqlCommand(insertQuery1, connection1);

                command1.Parameters.Add("@PostID", MySqlDbType.Int32);
                command1.Parameters.Add("@PostText", MySqlDbType.Text);
                command1.Parameters.Add("@Picture", MySqlDbType.Text);
                command1.Parameters.Add("@UserID", MySqlDbType.Int32);
                var rand = new Random();
                int temp = rand.Next(10000, 99999) + iduser;
                command1.Parameters["@PostID"].Value = temp;
                command1.Parameters["@PostText"].Value = textBox1.Text;
                command1.Parameters["@Picture"].Value = "post"+temp+".jpg";
                command1.Parameters["@UserID"].Value = iduser;
                if (command1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("successful");
                }
                System.IO.File.Copy(image_post, "./post" + temp + ".jpg");
            }
        }
        public void load_feed()
        {
            int profile_id = 0;
            int counts = array_post.ToArray().Length;
            if (counts > 0) { 
                MySqlConnection connection1 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");
                var rand = new Random();

                int temp = rand.Next(array_post.Count);

                Console.WriteLine(array_post);
                string post_rand = array_post[temp].ToString();
                connection1.Open();
                post_choose = Int32.Parse(post_rand);
                string sql1 = "SELECT * FROM posts WHERE PostID = '" + post_rand + "'";
                using var cmd1 = new MySqlCommand(sql1, connection1);

                using MySqlDataReader rdr1 = cmd1.ExecuteReader();

                while (rdr1.Read())
                {
                    profile_id = rdr1.GetInt32(3);
                    if(rdr1.GetInt32(3) == iduser)
                    {
                        ebtn.Visible = true;
                    }
                    else
                    {
                        ebtn.Visible = false;
                    }
                    panel7.Visible = true;
                    pictureBox2.Image = resizeImage(Image.FromFile(rdr1.GetString(2)), new Size(364, 213));
                    label6.Text = rdr1.GetString(1);
                }
                connection1.Close();
            }
            MySqlConnection connection2 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            connection2.Open();
            string sql2 = "SELECT * FROM users WHERE UserID ='"+ profile_id + "'";
            using var cmd2 = new MySqlCommand(sql2, connection2);

            using MySqlDataReader rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())
            {
                pictureBox3.Image = resizeImage(Image.FromFile(rdr2.GetString(6)), new Size(50, 50));
                label1.Text = rdr2.GetString(2);
            }
            connection2.Close();

            MySqlConnection connection4 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            connection4.Open();
            string sql4 = "SELECT * FROM postcomments WHERE PostID = '" + post_choose + "'";
            using var cmd4 = new MySqlCommand(sql4, connection4);

            using MySqlDataReader rdr4 = cmd4.ExecuteReader();
            img1.Visible = false;
            img2.Visible = false;
            msg1.Text = "none";
            msg2.Text = "none";
            msg1.Visible = false;
            msg2.Visible = false;
            name11.Visible = false;
            name22.Visible = false;
            while (rdr4.Read())
            {
                MySqlConnection connection5 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

                connection5.Open();
                string sql5 = "SELECT * FROM comments WHERE CommentID = '" + rdr4.GetInt32(2) + "'";
                using var cmd5 = new MySqlCommand(sql5, connection5);

                using MySqlDataReader rdr5 = cmd5.ExecuteReader();
                
                while (rdr5.Read())
                {
                    
                    MySqlConnection connection6 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

                    connection6.Open();
                    string sql6 = "SELECT * FROM users WHERE UserID = '" + rdr5.GetInt32(3).ToString() + "'";
                    using var cmd6 = new MySqlCommand(sql6, connection6);

                    using MySqlDataReader rdr6 = cmd6.ExecuteReader();
                    
                    while (rdr6.Read())
                    {
                        if (msg1.Text == "none")
                        {
                            img1.Visible = true;
                            img1.Image = resizeImage(Image.FromFile(rdr6.GetString(6)), new Size(26, 24));
                            msg1.Visible = true;
                            name11.Visible = true;
                            name11.Text = rdr6.GetString(2);
                            msg1.Text = rdr5.GetString(1);

                            
                        }
                        else
                        {
                            img2.Visible = true;
                            img2.Image = resizeImage(Image.FromFile(rdr6.GetString(6)), new Size(26, 24));
                            msg2.Visible = true;
                            name22.Visible = true;
                            name22.Text = rdr6.GetString(2);
                            msg2.Text = rdr5.GetString(1);
                        }
                        
                    }
                    connection6.Close();
                    
                }
                connection5.Close();
            }
            connection4.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            load_feed();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            MySqlConnection connection1 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None");
            MySqlCommand command1;
            String insertQuery1 = "INSERT INTO fackbook.comments(CommentID, CommentText, DateTime,UserID,PostID) VALUES(@CommentID, @CommentText, @DateTime, @UserID,@PostID)";

            connection1.Open();
            command1 = new MySqlCommand(insertQuery1, connection1);

            command1.Parameters.Add("@CommentID", MySqlDbType.Int32);
            command1.Parameters.Add("@CommentText", MySqlDbType.Text);
            command1.Parameters.Add("@DateTime", MySqlDbType.DateTime);
            command1.Parameters.Add("@UserID", MySqlDbType.Int32);
            command1.Parameters.Add("@PostID", MySqlDbType.Int32);
            var rand = new Random();
            int temp = rand.Next(10000, 99999) + iduser;
            command1.Parameters["@CommentID"].Value = temp;
            command1.Parameters["@CommentText"].Value = textBox2.Text;
            command1.Parameters["@DateTime"].Value = new DateTime();
            command1.Parameters["@UserID"].Value = iduser;
            command1.Parameters["@PostID"].Value = post_choose;

            if (command1.ExecuteNonQuery() == 1)
            {
                
            }
            connection1.Close();

            MySqlConnection connection2 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None");
            MySqlCommand command2;
            String insertQuery2 = "INSERT INTO fackbook.postcomments(PostCommentID, PostID, CommentID) VALUES(@PostCommentID, @PostID, @CommentID)";

            connection2.Open();
            command2 = new MySqlCommand(insertQuery2, connection2);

            command2.Parameters.Add("@PostCommentID", MySqlDbType.Int32);
            command2.Parameters.Add("@PostID", MySqlDbType.Int32);
            command2.Parameters.Add("@CommentID", MySqlDbType.Int32);


            command2.Parameters["@PostCommentID"].Value = post_choose+temp;
            command2.Parameters["@PostID"].Value = post_choose;
            command2.Parameters["@CommentID"].Value = temp;

            if (command2.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("successful");
                load_feed();
                textBox2.Text = "";
            }
            connection2.Close();
        }

        private void ebtn_Click(object sender, EventArgs e)
        {
            editpost page = new editpost(post_choose);
            page.Show();
        }
    }
}
