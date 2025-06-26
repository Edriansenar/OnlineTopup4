Public Class Dashboard

    ' Cart list to store selected items
    Private cart As New List(Of String)

    ' When the form loads, populate the top-up amount ComboBox
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("50")
        ComboBox1.Items.Add("100")
        ComboBox1.Items.Add("500")
        ComboBox1.Items.Add("5000")
        ComboBox1.Items.Add("10000")
        ComboBox1.SelectedIndex = 0 ' Default selection
    End Sub

    ' Add to cart button click
    Private Sub btnAddCart_Click(sender As Object, e As EventArgs) Handles btnAddCart.Click
        Dim selectedGame As String = ""

        ' Check which radio button is selected
        If rbMobileLegends.Checked Then
            selectedGame = "Mobile Legends"
        ElseIf rbLeagueOfLegends.Checked Then
            selectedGame = "League of Legends"
        ElseIf rbHonorOfKings.Checked Then
            selectedGame = "Honor of Kings"
        ElseIf rbCallOfDuty.Checked Then
            selectedGame = "Call of Duty Mobile"
        ElseIf rbTeamFightTactics.Checked Then
            selectedGame = "Teamfight Tactics"
        Else
            MessageBox.Show("Please select a game.", "Game Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get selected amount
        Dim selectedAmount As String = ComboBox1.SelectedItem.ToString()

        ' Add to cart
        Dim cartItem As String = selectedGame & " - " & selectedAmount
        cart.Add(cartItem)
        MessageBox.Show("Added to cart: " & cartItem, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' View Cart button click
    Private Sub btnViewCart_Click(sender As Object, e As EventArgs) Handles btnViewCart.Click
        If cart.Count = 0 Then
            MessageBox.Show("Your cart is empty.", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim cartSummary As String = String.Join(Environment.NewLine, cart)
        MessageBox.Show("Your cart items:" & Environment.NewLine & cartSummary, "Cart Contents", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Optional: Handle RadioButton changes if needed
    Private Sub rbMobileLegends_CheckedChanged(sender As Object, e As EventArgs) Handles rbMobileLegends.CheckedChanged
        ' Optional logic on selection
    End Sub

    Private Sub rbLeagueOfLegends_CheckedChanged(sender As Object, e As EventArgs) Handles rbLeagueOfLegends.CheckedChanged
    End Sub

    Private Sub rbHonorOfKings_CheckedChanged(sender As Object, e As EventArgs) Handles rbHonorOfKings.CheckedChanged
    End Sub

    Private Sub rbCallOfDuty_CheckedChanged(sender As Object, e As EventArgs) Handles rbCallOfDuty.CheckedChanged
    End Sub

    Private Sub rbTeamFightTactics_CheckedChanged(sender As Object, e As EventArgs) Handles rbTeamFightTactics.CheckedChanged
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Optional logic when amount changes
    End Sub

    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
        If cart.Count = 0 Then
            MessageBox.Show("Your cart is empty!", "Checkout Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cartForm As New Cart()
        cartForm.CartItems = New List(Of String)(cart)
        cartForm.Show()
    End Sub

End Class
