
namespace fakebook
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.username_login = new System.Windows.Forms.TextBox();
            this.password_login = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.forgot_btn = new System.Windows.Forms.Button();
            this.sign_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // username_login
            // 
            this.username_login.BackColor = System.Drawing.Color.White;
            this.username_login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username_login.Location = new System.Drawing.Point(286, 75);
            this.username_login.Name = "username_login";
            this.username_login.PlaceholderText = "Email address";
            this.username_login.Size = new System.Drawing.Size(202, 16);
            this.username_login.TabIndex = 0;
            this.username_login.TextChanged += new System.EventHandler(this.username_login_TextChanged);
            // 
            // password_login
            // 
            this.password_login.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.password_login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_login.Location = new System.Drawing.Point(286, 146);
            this.password_login.Name = "password_login";
            this.password_login.PlaceholderText = "Password";
            this.password_login.Size = new System.Drawing.Size(202, 16);
            this.password_login.TabIndex = 1;
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.Transparent;
            this.login_btn.FlatAppearance.BorderSize = 0;
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_btn.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.login_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.login_btn.Location = new System.Drawing.Point(272, 200);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(231, 32);
            this.login_btn.TabIndex = 2;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // forgot_btn
            // 
            this.forgot_btn.BackColor = System.Drawing.Color.Transparent;
            this.forgot_btn.FlatAppearance.BorderSize = 0;
            this.forgot_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forgot_btn.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.forgot_btn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.forgot_btn.Location = new System.Drawing.Point(299, 293);
            this.forgot_btn.Name = "forgot_btn";
            this.forgot_btn.Size = new System.Drawing.Size(175, 32);
            this.forgot_btn.TabIndex = 3;
            this.forgot_btn.Text = "Forgotten Password";
            this.forgot_btn.UseVisualStyleBackColor = false;
            // 
            // sign_btn
            // 
            this.sign_btn.BackColor = System.Drawing.Color.Transparent;
            this.sign_btn.FlatAppearance.BorderSize = 0;
            this.sign_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_btn.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sign_btn.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.sign_btn.Location = new System.Drawing.Point(271, 250);
            this.sign_btn.Name = "sign_btn";
            this.sign_btn.Size = new System.Drawing.Size(231, 34);
            this.sign_btn.TabIndex = 4;
            this.sign_btn.Text = "Sign up";
            this.sign_btn.UseVisualStyleBackColor = false;
            this.sign_btn.Click += new System.EventHandler(this.sign_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.username_login);
            this.panel1.Controls.Add(this.sign_btn);
            this.panel1.Controls.Add(this.password_login);
            this.panel1.Controls.Add(this.forgot_btn);
            this.panel1.Controls.Add(this.login_btn);
            this.panel1.Location = new System.Drawing.Point(122, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 334);
            this.panel1.TabIndex = 5;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox username_login;
        private System.Windows.Forms.TextBox password_login;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Button forgot_btn;
        private System.Windows.Forms.Button sign_btn;
        private System.Windows.Forms.Panel panel1;
    }
}

