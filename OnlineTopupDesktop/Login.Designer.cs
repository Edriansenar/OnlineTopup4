namespace OnlineTopupDesktop
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtBoxUsername = new TextBox();
            txtBoxPassword = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(531, 151);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(104, 45);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(349, 40);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(412, 45);
            label2.TabIndex = 1;
            label2.Text = "WELCOME TO ONLINE TOPUP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(324, 254);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(103, 26);
            label3.TabIndex = 2;
            label3.Text = "USERNAME:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(319, 312);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(108, 26);
            label4.TabIndex = 3;
            label4.Text = "PASSWORD:";
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.Location = new Point(456, 257);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.Size = new Size(266, 23);
            txtBoxUsername.TabIndex = 4;
            txtBoxUsername.Text = "1";
            txtBoxUsername.TextChanged += txtBoxUsername_TextChanged;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.Location = new Point(456, 315);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.Size = new Size(266, 23);
            txtBoxPassword.TabIndex = 5;
            txtBoxPassword.TextChanged += txtBoxPassword_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(390, 382);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(147, 45);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(575, 382);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(147, 45);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(1106, 629);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtBoxPassword);
            Controls.Add(txtBoxUsername);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtBoxUsername;
        private TextBox txtBoxPassword;
        private Button btnLogin;
        private Button btnRegister;
    }
}
