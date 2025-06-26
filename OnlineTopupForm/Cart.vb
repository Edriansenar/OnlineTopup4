Public Class Cart

    ' Public cart list passed from Dashboard
    Public Property CartItems As List(Of String)

    Private Sub Cart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display cart items in ListBox
        If CartItems IsNot Nothing Then
            ListBox1.Items.Clear()
            For Each item As String In CartItems
                ListBox1.Items.Add(item)
            Next
        End If
    End Sub

    ' Remove selected item
    Private Sub btnRemoveCart_Click(sender As Object, e As EventArgs) Handles btnRemoveCart.Click
        If ListBox1.SelectedIndex >= 0 Then
            Dim removedItem As String = ListBox1.SelectedItem.ToString()
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            CartItems.Remove(removedItem)
            MessageBox.Show("Item removed from cart.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please select an item to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Checkout button click
    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
        If ListBox1.Items.Count = 0 Then
            MessageBox.Show("Your cart is empty!", "Checkout Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Checkout successful!" & vbCrLf & "Thank you for your purchase.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ListBox1.Items.Clear()
            CartItems.Clear()
        End If
    End Sub

    ' Back to Dashboard
    Private Sub btnBacktoDashboard_Click(sender As Object, e As EventArgs) Handles btnBacktoDashboard.Click
        Me.Hide()
        Dashboard.Show()
    End Sub

    ' Optional: when user clicks item
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ' Optional highlight logic
    End Sub

End Class
