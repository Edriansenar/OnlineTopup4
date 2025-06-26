<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cart
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
        Me.lblCart = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.btnRemoveCart = New System.Windows.Forms.Button()
        Me.btnCheckout = New System.Windows.Forms.Button()
        Me.btnBacktoDashboard = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblCart
        '
        Me.lblCart.AutoSize = True
        Me.lblCart.Font = New System.Drawing.Font("Noto Serif SC", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCart.Location = New System.Drawing.Point(264, 21)
        Me.lblCart.Name = "lblCart"
        Me.lblCart.Size = New System.Drawing.Size(281, 61)
        Me.lblCart.TabIndex = 3
        Me.lblCart.Text = "YOUR CART"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Noto Serif HK", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 33
        Me.ListBox1.Location = New System.Drawing.Point(112, 85)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(586, 268)
        Me.ListBox1.TabIndex = 4
        '
        'btnRemoveCart
        '
        Me.btnRemoveCart.Font = New System.Drawing.Font("Noto Serif HK", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveCart.ForeColor = System.Drawing.Color.IndianRed
        Me.btnRemoveCart.Location = New System.Drawing.Point(62, 376)
        Me.btnRemoveCart.Name = "btnRemoveCart"
        Me.btnRemoveCart.Size = New System.Drawing.Size(201, 36)
        Me.btnRemoveCart.TabIndex = 14
        Me.btnRemoveCart.Text = "Remove To Cart"
        Me.btnRemoveCart.UseVisualStyleBackColor = True
        '
        'btnCheckout
        '
        Me.btnCheckout.Font = New System.Drawing.Font("Noto Serif HK", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckout.ForeColor = System.Drawing.Color.IndianRed
        Me.btnCheckout.Location = New System.Drawing.Point(292, 376)
        Me.btnCheckout.Name = "btnCheckout"
        Me.btnCheckout.Size = New System.Drawing.Size(201, 36)
        Me.btnCheckout.TabIndex = 15
        Me.btnCheckout.Text = "Checkout"
        Me.btnCheckout.UseVisualStyleBackColor = True
        '
        'btnBacktoDashboard
        '
        Me.btnBacktoDashboard.Font = New System.Drawing.Font("Noto Serif HK", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBacktoDashboard.ForeColor = System.Drawing.Color.IndianRed
        Me.btnBacktoDashboard.Location = New System.Drawing.Point(532, 376)
        Me.btnBacktoDashboard.Name = "btnBacktoDashboard"
        Me.btnBacktoDashboard.Size = New System.Drawing.Size(201, 36)
        Me.btnBacktoDashboard.TabIndex = 16
        Me.btnBacktoDashboard.Text = "Back To Dashboard"
        Me.btnBacktoDashboard.UseVisualStyleBackColor = True
        '
        'Cart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.RosyBrown
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnBacktoDashboard)
        Me.Controls.Add(Me.btnCheckout)
        Me.Controls.Add(Me.btnRemoveCart)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.lblCart)
        Me.Name = "Cart"
        Me.Text = "Cart"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCart As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents btnRemoveCart As Button
    Friend WithEvents btnCheckout As Button
    Friend WithEvents btnBacktoDashboard As Button
End Class
