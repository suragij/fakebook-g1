
namespace fakebook
{
    partial class Signup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signup));
            this.username_rig = new System.Windows.Forms.TextBox();
            this.password_rig = new System.Windows.Forms.TextBox();
            this.sign_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.c_password_rig = new System.Windows.Forms.TextBox();
            this.name_rig = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // username_rig
            // 
            this.username_rig.BackColor = System.Drawing.Color.White;
            this.username_rig.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username_rig.Location = new System.Drawing.Point(39, 95);
            this.username_rig.Name = "username_rig";
            this.username_rig.PlaceholderText = "Email address";
            this.username_rig.Size = new System.Drawing.Size(210, 16);
            this.username_rig.TabIndex = 0;
            // 
            // password_rig
            // 
            this.password_rig.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_rig.Location = new System.Drawing.Point(39, 166);
            this.password_rig.Name = "password_rig";
            this.password_rig.PlaceholderText = "Password";
            this.password_rig.Size = new System.Drawing.Size(215, 16);
            this.password_rig.TabIndex = 1;
            this.password_rig.TextChanged += new System.EventHandler(this.password_rig_TextChanged);
            // 
            // sign_btn
            // 
            this.sign_btn.BackColor = System.Drawing.Color.Transparent;
            this.sign_btn.FlatAppearance.BorderSize = 0;
            this.sign_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_btn.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sign_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sign_btn.Location = new System.Drawing.Point(286, 232);
            this.sign_btn.Name = "sign_btn";
            this.sign_btn.Size = new System.Drawing.Size(231, 32);
            this.sign_btn.TabIndex = 2;
            this.sign_btn.Text = "Sign up";
            this.sign_btn.UseVisualStyleBackColor = false;
            this.sign_btn.Click += new System.EventHandler(this.sign_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.c_password_rig);
            this.panel1.Controls.Add(this.name_rig);
            this.panel1.Controls.Add(this.username_rig);
            this.panel1.Controls.Add(this.password_rig);
            this.panel1.Controls.Add(this.sign_btn);
            this.panel1.Location = new System.Drawing.Point(122, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 334);
            this.panel1.TabIndex = 6;
            // 
            // back
            // 
            this.back.FlatAppearance.BorderSize = 0;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.back.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.back.Location = new System.Drawing.Point(286, 289);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(231, 23);
            this.back.TabIndex = 7;
            this.back.Text = "Login";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // c_password_rig
            // 
            this.c_password_rig.BackColor = System.Drawing.SystemColors.Window;
            this.c_password_rig.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c_password_rig.Location = new System.Drawing.Point(291, 166);
            this.c_password_rig.Name = "c_password_rig";
            this.c_password_rig.PlaceholderText = "Confirm password";
            this.c_password_rig.Size = new System.Drawing.Size(226, 16);
            this.c_password_rig.TabIndex = 3;
            // 
            // name_rig
            // 
            this.name_rig.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name_rig.Location = new System.Drawing.Point(296, 95);
            this.name_rig.Name = "name_rig";
            this.name_rig.PlaceholderText = "Name";
            this.name_rig.Size = new System.Drawing.Size(221, 16);
            this.name_rig.TabIndex = 4;
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Signup";
            this.Text = "Signup";
            this.Load += new System.EventHandler(this.Signup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox username_rig;
        private System.Windows.Forms.TextBox password_rig;
        private System.Windows.Forms.Button sign_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox c_password_rig;
        private System.Windows.Forms.TextBox name_rig;
        private System.Windows.Forms.Button back;
    }
}