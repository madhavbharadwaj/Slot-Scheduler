Imports System.Data.SqlClient

Public Class Form1




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'connection.Open()
        'usnLabel.Text = "Connection Succsful"

        Dim connection As New SqlConnection("Server= MADHAV-PC\SQLEXPRESS; Database = vb; Integrated Security = true")
        Dim command As New SqlCommand("select * from Table_Login where Username = @username and Password = @password", connection)
        command.Parameters.Add("@username", SqlDbType.VarChar).Value = usnText.Text
        command.Parameters.Add("@password", SqlDbType.VarChar).Value = pwText.Text

        Dim adapter As New SqlDataAdapter(command)

        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count() <= 0 Then

            MessageBox.Show("Username Or Password Are Invalid")

        Else

            MessageBox.Show("Login Successfully")

            'Dim frm As New VBNET_SQL_Insert_Update_Delete()

            Me.Hide()
            'Form2.Show()

            Dim frm As New Form2(usnText.Text)
            frm.Show()

            usnText.Text = ""
            pwText.Text = ""
            ' frm.Show()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class
