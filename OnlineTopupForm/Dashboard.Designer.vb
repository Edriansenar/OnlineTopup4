<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbMobileLegends = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.rbHonorOfKings = New System.Windows.Forms.RadioButton()
        Me.rbTeamFightTactics = New System.Windows.Forms.RadioButton()
        Me.rbLeagueOfLegends = New System.Windows.Forms.RadioButton()
        Me.rbCallOfDuty = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnAddCart = New System.Windows.Forms.Button()
        Me.btnViewCart = New System.Windows.Forms.Button()
        Me.btnCheckout = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Noto Serif SC", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.Location = New System.Drawing.Point(223, 21)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(771, 61)
        Me.lblWelcome.TabIndex = 2
        Me.lblWelcome.Text = "Welcome [Username] Online Topup"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Noto Serif SC", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RosyBrown
        Me.Label1.Location = New System.Drawing.Point(364, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(494, 40)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "What game you would like to toup?"
        '
        'rbMobileLegends
        '
        Me.rbMobileLegends.AutoSize = True
        Me.rbMobileLegends.BackColor = System.Drawing.Color.White
        Me.rbMobileLegends.Font = New System.Drawing.Font("Noto Serif HK", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMobileLegends.ForeColor = System.Drawing.Color.RosyBrown
        Me.rbMobileLegends.Location = New System.Drawing.Point(234, 201)
        Me.rbMobileLegends.Name = "rbMobileLegends"
        Me.rbMobileLegends.Size = New System.Drawing.Size(214, 37)
        Me.rbMobileLegends.TabIndex = 6
        Me.rbMobileLegends.TabStop = True
        Me.rbMobileLegends.Text = "Mobile Legends"
        Me.rbMobileLegends.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(104, 99)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1017, 480)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'rbHonorOfKings
        '
        Me.rbHonorOfKings.AutoSize = True
        Me.rbHonorOfKings.BackColor = System.Drawing.Color.White
        Me.rbHonorOfKings.Font = New System.Drawing.Font("Noto Serif HK", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbHonorOfKings.ForeColor = System.Drawing.Color.RosyBrown
        Me.rbHonorOfKings.Location = New System.Drawing.Point(371, 255)
        Me.rbHonorOfKings.Name = "rbHonorOfKings"
        Me.rbHonorOfKings.Size = New System.Drawing.Size(212, 37)
        Me.rbHonorOfKings.TabIndex = 7
        Me.rbHonorOfKings.TabStop = True
        Me.rbHonorOfKings.Text = "Honor Of Kings"
        Me.rbHonorOfKings.UseVisualStyleBackColor = False
        '
        'rbTeamFightTactics
        '
        Me.rbTeamFightTactics.AutoSize = True
        Me.rbTeamFightTactics.BackColor = System.Drawing.Color.White
        Me.rbTeamFightTactics.Font = New System.Drawing.Font("Noto Serif HK", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTeamFightTactics.ForeColor = System.Drawing.Color.RosyBrown
        Me.rbTeamFightTactics.Location = New System.Drawing.Point(655, 255)
        Me.rbTeamFightTactics.Name = "rbTeamFightTactics"
        Me.rbTeamFightTactics.Size = New System.Drawing.Size(233, 37)
        Me.rbTeamFightTactics.TabIndex = 8
        Me.rbTeamFightTactics.TabStop = True
        Me.rbTeamFightTactics.Text = "TeamFightTactics"
        Me.rbTeamFightTactics.UseVisualStyleBackColor = False
        '
        'rbLeagueOfLegends
        '
        Me.rbLeagueOfLegends.AutoSize = True
        Me.rbLeagueOfLegends.BackColor = System.Drawing.Color.White
        Me.rbLeagueOfLegends.Font = New System.Drawing.Font("Noto Serif HK", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLeagueOfLegends.ForeColor = System.Drawing.Color.RosyBrown
        Me.rbLeagueOfLegends.Location = New System.Drawing.Point(798, 201)
        Me.rbLeagueOfLegends.Name = "rbLeagueOfLegends"
        Me.rbLeagueOfLegends.Size = New System.Drawing.Size(249, 37)
        Me.rbLeagueOfLegends.TabIndex = 9
        Me.rbLeagueOfLegends.TabStop = True
        Me.rbLeagueOfLegends.Text = "League Of Legends"
        Me.rbLeagueOfLegends.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.rbLeagueOfLegends.UseVisualStyleBackColor = False
        '
        'rbCallOfDuty
        '
        Me.rbCallOfDuty.AutoSize = True
        Me.rbCallOfDuty.BackColor = System.Drawing.Color.White
        Me.rbCallOfDuty.Font = New System.Drawing.Font("Noto Serif HK", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCallOfDuty.ForeColor = System.Drawing.Color.RosyBrown
        Me.rbCallOfDuty.Location = New System.Drawing.Point(505, 201)
        Me.rbCallOfDuty.Name = "rbCallOfDuty"
        Me.rbCallOfDuty.Size = New System.Drawing.Size(259, 37)
        Me.rbCallOfDuty.TabIndex = 10
        Me.rbCallOfDuty.TabStop = True
        Me.rbCallOfDuty.Text = "Call Of Duty Mobile"
        Me.rbCallOfDuty.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Noto Serif SC", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RosyBrown
        Me.Label2.Location = New System.Drawing.Point(258, 363)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 40)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Select Amount"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"50", "100", "500", "5000", "10000"})
        Me.ComboBox1.Location = New System.Drawing.Point(488, 378)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(307, 24)
        Me.ComboBox1.TabIndex = 12
        '
        'btnAddCart
        '
        Me.btnAddCart.Font = New System.Drawing.Font("Noto Serif HK", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddCart.ForeColor = System.Drawing.Color.IndianRed
        Me.btnAddCart.Location = New System.Drawing.Point(272, 475)
        Me.btnAddCart.Name = "btnAddCart"
        Me.btnAddCart.Size = New System.Drawing.Size(201, 36)
        Me.btnAddCart.TabIndex = 13
        Me.btnAddCart.Text = "Add to Cart"
        Me.btnAddCart.UseVisualStyleBackColor = True
        '
        'btnViewCart
        '
        Me.btnViewCart.Font = New System.Drawing.Font("Noto Serif HK", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewCart.ForeColor = System.Drawing.Color.IndianRed
        Me.btnViewCart.Location = New System.Drawing.Point(522, 475)
        Me.btnViewCart.Name = "btnViewCart"
        Me.btnViewCart.Size = New System.Drawing.Size(201, 36)
        Me.btnViewCart.TabIndex = 14
        Me.btnViewCart.Text = "View Cart"
        Me.btnViewCart.UseVisualStyleBackColor = True
        '
        'btnCheckout
        '
        Me.btnCheckout.Font = New System.Drawing.Font("Noto Serif HK", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckout.ForeColor = System.Drawing.Color.IndianRed
        Me.btnCheckout.Location = New System.Drawing.Point(778, 475)
        Me.btnCheckout.Name = "btnCheckout"
        Me.btnCheckout.Size = New System.Drawing.Size(201, 36)
        Me.btnCheckout.TabIndex = 15
        Me.btnCheckout.Text = "Checkout"
        Me.btnCheckout.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Font = New System.Drawing.Font("Noto Serif HK", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.IndianRed
        Me.btnLogout.Location = New System.Drawing.Point(1025, 32)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(142, 36)
        Me.btnLogout.TabIndex = 16
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.RosyBrown
        Me.ClientSize = New System.Drawing.Size(1198, 641)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.btnCheckout)
        Me.Controls.Add(Me.btnViewCart)
        Me.Controls.Add(Me.btnAddCart)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rbCallOfDuty)
        Me.Controls.Add(Me.rbLeagueOfLegends)
        Me.Controls.Add(Me.rbTeamFightTactics)
        Me.Controls.Add(Me.rbHonorOfKings)
        Me.Controls.Add(Me.rbMobileLegends)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblWelcome)
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblWelcome As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents rbMobileLegends As RadioButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents rbHonorOfKings As RadioButton
    Friend WithEvents rbTeamFightTactics As RadioButton
    Friend WithEvents rbLeagueOfLegends As RadioButton
    Friend WithEvents rbCallOfDuty As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnAddCart As Button
    Friend WithEvents btnViewCart As Button
    Friend WithEvents btnCheckout As Button
    Friend WithEvents btnLogout As Button
End Class
