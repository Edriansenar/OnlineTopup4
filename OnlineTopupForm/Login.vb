Imports System.Data.SqlClient

Public Class Login

    Dim connectionString As String = "Data Source=YANN\SQLEXPRESS02;Initial Catalog=AccountsDB;Integrated Security=True;TrustServerCertificate=True;"

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblUsername.Click

    End Sub

    Private Sub txtbUsername_TextChanged(sender As Object, e As EventArgs) Handles txtbUsername.TextChanged

    End Sub

    Private Sub txtbPassword_TextChanged(sender As Object, e As EventArgs) Handles txtbPassword.TextChanged

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtbUsername.Text.Trim()
        Dim password As String = txtbPassword.Text.Trim()

        Dim query As String = "SELECT COUNT(*) FROM Accounts WHERE Username = @Username AND Password = @Password"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", password)

                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                conn.Close()

                If count > 0 Then
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' ✅ Open Dashboard form and hide login form
                    Dim dashboardForm As New Dashboard()
                    dashboardForm.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End Using
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim username As String = txtbUsername.Text.Trim()
        Dim password As String = txtbPassword.Text.Trim()

        ' ✅ Check for blank input
        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Username and password cannot be blank.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if username already exists
        Dim checkQuery As String = "SELECT COUNT(*) FROM Accounts WHERE Username = @Username"
        Dim insertQuery As String = "INSERT INTO Accounts (Username, Password) VALUES (@Username, @Password)"

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            Using checkCmd As New SqlCommand(checkQuery, conn)
                checkCmd.Parameters.AddWithValue("@Username", username)

                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If exists > 0 Then
                    MessageBox.Show("Username already taken. Please choose another.", "Register Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End Using

            ' Insert new account
            Using insertCmd As New SqlCommand(insertQuery, conn)
                insertCmd.Parameters.AddWithValue("@Username", username)
                insertCmd.Parameters.AddWithValue("@Password", password)

                insertCmd.ExecuteNonQuery()
                MessageBox.Show("Account registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

            conn.Close()
        End Using

    End Sub
End Class
