namespace OnlineTopupDesktop
{
    partial class Dashboard
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
            label2 = new Label();
            radioButtonMobileLegends = new RadioButton();
            radioButtonLeagueOfLegends = new RadioButton();
            radioButtonTeamFightTactics = new RadioButton();
            radioButtonCallOfDuty = new RadioButton();
            label1 = new Label();
            label3 = new Label();
            comboBoxSelectAmount = new ComboBox();
            label4 = new Label();
            btnAddToCart = new Button();
            btnCheckOut = new Button();
            checkBoxGCASH = new CheckBox();
            checkBoxPayPal = new CheckBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(230, 30);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(412, 45);
            label2.TabIndex = 2;
            label2.Text = "WELCOME TO ONLINE TOPUP";
            // 
            // radioButtonMobileLegends
            // 
            radioButtonMobileLegends.AutoSize = true;
            radioButtonMobileLegends.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButtonMobileLegends.ForeColor = Color.Black;
            radioButtonMobileLegends.Location = new Point(155, 180);
            radioButtonMobileLegends.Name = "radioButtonMobileLegends";
            radioButtonMobileLegends.Size = new Size(132, 24);
            radioButtonMobileLegends.TabIndex = 3;
            radioButtonMobileLegends.TabStop = true;
            radioButtonMobileLegends.Text = "MOBILE LEGENDS";
            radioButtonMobileLegends.UseVisualStyleBackColor = true;
            radioButtonMobileLegends.CheckedChanged += radioButtonMobileLegends_CheckedChanged;
            // 
            // radioButtonLeagueOfLegends
            // 
            radioButtonLeagueOfLegends.AutoSize = true;
            radioButtonLeagueOfLegends.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButtonLeagueOfLegends.ForeColor = Color.Black;
            radioButtonLeagueOfLegends.Location = new Point(155, 220);
            radioButtonLeagueOfLegends.Name = "radioButtonLeagueOfLegends";
            radioButtonLeagueOfLegends.Size = new Size(148, 24);
            radioButtonLeagueOfLegends.TabIndex = 4;
            radioButtonLeagueOfLegends.TabStop = true;
            radioButtonLeagueOfLegends.Text = "LEAGUE OF LEGENDS";
            radioButtonLeagueOfLegends.UseVisualStyleBackColor = true;
            radioButtonLeagueOfLegends.CheckedChanged += radioButtonLeagueOfLegends_CheckedChanged;
            // 
            // radioButtonTeamFightTactics
            // 
            radioButtonTeamFightTactics.AutoSize = true;
            radioButtonTeamFightTactics.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButtonTeamFightTactics.ForeColor = Color.Black;
            radioButtonTeamFightTactics.Location = new Point(155, 261);
            radioButtonTeamFightTactics.Name = "radioButtonTeamFightTactics";
            radioButtonTeamFightTactics.Size = new Size(149, 24);
            radioButtonTeamFightTactics.TabIndex = 5;
            radioButtonTeamFightTactics.TabStop = true;
            radioButtonTeamFightTactics.Text = "TEAMFIGHT TACTICS";
            radioButtonTeamFightTactics.UseVisualStyleBackColor = true;
            radioButtonTeamFightTactics.CheckedChanged += radioButtonTeamFightTactics_CheckedChanged;
            // 
            // radioButtonCallOfDuty
            // 
            radioButtonCallOfDuty.AutoSize = true;
            radioButtonCallOfDuty.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButtonCallOfDuty.ForeColor = Color.Black;
            radioButtonCallOfDuty.Location = new Point(155, 302);
            radioButtonCallOfDuty.Name = "radioButtonCallOfDuty";
            radioButtonCallOfDuty.Size = new Size(159, 24);
            radioButtonCallOfDuty.TabIndex = 6;
            radioButtonCallOfDuty.TabStop = true;
            radioButtonCallOfDuty.Text = "CALL OF DUTY MOBILE";
            radioButtonCallOfDuty.UseVisualStyleBackColor = true;
            radioButtonCallOfDuty.CheckedChanged += radioButtonCallOfDuty_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(99, 123);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(293, 45);
            label1.TabIndex = 7;
            label1.Text = "SELECT YOUR GAME";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(108, 356);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(250, 45);
            label3.TabIndex = 8;
            label3.Text = "SELECT AMOUNT";
            // 
            // comboBoxSelectAmount
            // 
            comboBoxSelectAmount.FormattingEnabled = true;
            comboBoxSelectAmount.Items.AddRange(new object[] { "50", "100", "500", "1000" });
            comboBoxSelectAmount.Location = new Point(125, 424);
            comboBoxSelectAmount.Name = "comboBoxSelectAmount";
            comboBoxSelectAmount.Size = new Size(219, 23);
            comboBoxSelectAmount.TabIndex = 9;
            comboBoxSelectAmount.SelectedIndexChanged += comboBoxSelectAmount_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(456, 123);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(279, 45);
            label4.TabIndex = 10;
            label4.Text = "PAYMENT METHOD";
            // 
            // btnAddToCart
            // 
            btnAddToCart.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddToCart.Location = new Point(414, 356);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(147, 45);
            btnAddToCart.TabIndex = 13;
            btnAddToCart.Text = "ADD TO CART";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCheckOut.Location = new Point(588, 356);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(147, 45);
            btnCheckOut.TabIndex = 14;
            btnCheckOut.Text = "CHECKOUT";
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // checkBoxGCASH
            // 
            checkBoxGCASH.AutoSize = true;
            checkBoxGCASH.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxGCASH.Location = new Point(510, 180);
            checkBoxGCASH.Name = "checkBoxGCASH";
            checkBoxGCASH.Size = new Size(70, 24);
            checkBoxGCASH.TabIndex = 15;
            checkBoxGCASH.Text = "GCASH";
            checkBoxGCASH.UseVisualStyleBackColor = true;
            checkBoxGCASH.CheckedChanged += checkBoxGCASH_CheckedChanged;
            // 
            // checkBoxPayPal
            // 
            checkBoxPayPal.AutoSize = true;
            checkBoxPayPal.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxPayPal.Location = new Point(510, 220);
            checkBoxPayPal.Name = "checkBoxPayPal";
            checkBoxPayPal.Size = new Size(71, 24);
            checkBoxPayPal.TabIndex = 16;
            checkBoxPayPal.Text = "PAYPAL";
            checkBoxPayPal.UseVisualStyleBackColor = true;
            checkBoxPayPal.CheckedChanged += checkBoxPayPal_CheckedChanged;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(862, 619);
            Controls.Add(checkBoxPayPal);
            Controls.Add(checkBoxGCASH);
            Controls.Add(btnCheckOut);
            Controls.Add(btnAddToCart);
            Controls.Add(label4);
            Controls.Add(comboBoxSelectAmount);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(radioButtonCallOfDuty);
            Controls.Add(radioButtonTeamFightTactics);
            Controls.Add(radioButtonLeagueOfLegends);
            Controls.Add(radioButtonMobileLegends);
            Controls.Add(label2);
            ForeColor = Color.Black;
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private RadioButton radioButtonMobileLegends;
        private RadioButton radioButtonLeagueOfLegends;
        private RadioButton radioButtonTeamFightTactics;
        private RadioButton radioButtonCallOfDuty;
        private Label label1;
        private Label label3;
        private ComboBox comboBoxSelectAmount;
        private Label label4;
        private Button btnAddToCart;
        private Button btnCheckOut;
        private CheckBox checkBoxGCASH;
        private CheckBox checkBoxPayPal;
    }
}