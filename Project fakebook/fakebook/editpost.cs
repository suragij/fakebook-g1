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
    public partial class editpost : Form
    {
        public int PostId = 0;
        public int post_choose = 0;
        public string image_post = "";
        public editpost(int postid)
        {
            InitializeComponent();
            PostId = postid;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None;database=fackbook");

            connection.Open();
            MessageBox.Show(PostId.ToString());
            string sql = "SELECT * FROM posts WHERE PostID = '" + PostId + "' ";
            using var cmd = new MySqlCommand(sql, connection);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                pictureBox1.Image = Image.FromFile(rdr.GetString(2));
                image_post = rdr.GetString(2);
                textBox1.Text = rdr.GetString(1);
                
            }
            connection.Close();
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files | *.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    image_post = openFileDialog1.FileName;
                    pictureBox1.Image = resizeImage(Image.FromFile(openFileDialog1.FileName), new Size(168, 151));
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=None");
            MySqlCommand command;
            String insertQuery = "UPDATE fackbook.posts SET PostText=@PostText,Picture=@Picture WHERE PostID = @PostID";

            connection.Open();
            command = new MySqlCommand(insertQuery, connection);
            if (System.IO.File.Exists("./image" + PostId + ".jpg"))
            {
                System.IO.File.Delete("./image" + PostId + ".jpg");
            }
            System.IO.File.Copy(image_post, "./image" + PostId + ".jpg");
            command.Parameters.Add("@PostText", MySqlDbType.Text);
            command.Parameters.Add("@Picture", MySqlDbType.Text);
            command.Parameters.Add("@PostID", MySqlDbType.Text);
            command.Parameters["@PostID"].Value = PostId;
            command.Parameters["@PostText"].Value = textBox1.Text;
            command.Parameters["@Picture"].Value = "./image" + PostId + ".jpg";
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
    }
}
