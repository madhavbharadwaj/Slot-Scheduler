Imports System.Data.SqlClient
Imports System.IO

Public Class Form2


    Public Sub New(ByVal sTitle As String)
        InitializeComponent()

        MonthCalendar1.MinDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        MonthCalendar1.MaxDate = MonthCalendar1.MinDate.AddDays(31)

        Me.Text = sTitle


    End Sub

    Dim t As String
    Dim MonthS As String
    Dim DayS As String
    Dim YearS As String


    Dim msg As MsgBoxResult

    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        t = MonthCalendar1.SelectionRange.Start.Month.ToString & MonthCalendar1.SelectionRange.Start.Day.ToString

        YearS = MonthCalendar1.SelectionRange.Start.Year.ToString
        MonthS = MonthCalendar1.SelectionRange.Start.Month.ToString
        DayS = MonthCalendar1.SelectionRange.Start.Day.ToString


        'MessageBox.Show(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"))

        ' MessageBox.Show(DayS + "/" + MonthS + "/" + YearS)
        Try

            Dim val As String

            If File.Exists(t & ".txt") = True Then

                Dim cnPodaci As New SqlConnection
                cnPodaci.ConnectionString = "Server= MADHAV-PC\SQLEXPRESS; Database = vb; Integrated Security = true"
                cnPodaci.Open()
                Dim cm As New SqlCommand
                cm.CommandText = "SELECT * FROM Booking_Details WHERE scheduled_on = '" + DayS + "/" + MonthS + "/" + YearS + "'"
                cm.Connection = cnPodaci
                Dim dr As SqlDataReader
                dr = cm.ExecuteReader

                If dr.HasRows Then

                    dr.Read()
                    val = dr.Item("scheduler_name").ToString
                    dr.Close()

                End If
                cnPodaci.Close()

                msg = MsgBox("Staff [" + val + "] has already booked on this Date. Wanna Update ?", MsgBoxStyle.YesNo)
                If msg = MsgBoxResult.Yes Then

                    MonthCalendar1.Enabled = False
                    MonthCalendar1.Hide()
                    TextBox1.Enabled = True
                    TextBox1.Show()
                    Button1.Enabled = True
                    Button1.Show()
                    Button2.Enabled = True
                    Button2.Show()

                    TextBox1.Text = File.ReadAllText(t & ".txt")
                End If


                'Dim cnPodaci As New SqlConnection
                'cnPodaci.ConnectionString = "Server= MADHAV-PC\SQLEXPRESS; Database = vb; Integrated Security = true"
                'cnPodaci.Open()
                'Dim cm As New SqlCommand
                'cm.CommandText = "SELECT * FROM Booking_Details where scheduled_on = 23/9/2018"
                'cm.Connection = cnPodaci
                'Dim dr As SqlDataReader
                'dr = cm.ExecuteReader

                'If dr.HasRows Then

                '    dr.Read()
                '    TextBox1.Text = dr.Item("information")


                '    dr.Close()

                'End If
                'cnPodaci.Close()


            Else

                msg = MsgBox("Would you like to create a booking for this date?", MsgBoxStyle.YesNo)
                If msg = MsgBoxResult.Yes Then

                    MonthCalendar1.Enabled = False
                    MonthCalendar1.Hide()
                    TextBox1.Enabled = True
                    TextBox1.Show()
                    TextBox1.Text = ""
                    Button1.Enabled = True
                    Button1.Show()
                    Button2.Enabled = True
                    Button2.Show()


                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Dim MonthS1 As String
    Dim DayS1 As String
    Dim YearS1 As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        YearS1 = MonthCalendar1.SelectionRange.Start.Year.ToString
        MonthS1 = MonthCalendar1.SelectionRange.Start.Month.ToString
        DayS1 = MonthCalendar1.SelectionRange.Start.Day.ToString

        Try
            If TextBox1.Text = "" Then
                If File.Exists(t & ".txt") = True Then


                    Dim con As New SqlConnection
                    Dim cmd As New SqlCommand
                    Try
                        con.ConnectionString = "Server= MADHAV-PC\SQLEXPRESS; Database = vb; Integrated Security = true"
                        con.Open()
                        cmd.Connection = con
                        cmd.CommandText = "Delete From Booking_Details where scheduled_on = @colSO"
                        cmd.Parameters.Add(New SqlParameter("@colSO", DayS1 + "/" + MonthS1 + "/" + YearS1))

                        If MessageBox.Show("Do you really want to Unbook this Schedule?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

                            File.Delete(t & ".txt")
                            cmd.ExecuteNonQuery()
                            MsgBox("Schedule unbooked on : " + DayS1 + "/" + MonthS1 + "/" + YearS1)
                            TextBox1.Enabled = False
                            TextBox1.Hide()
                            Button1.Enabled = False
                            Button1.Hide()
                            Button2.Enabled = False
                            Button2.Hide()
                            MonthCalendar1.Enabled = True
                            MonthCalendar1.Show()
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Error while deleting record on table..." & ex.Message, "Delete Records")

                    Finally

                        con.Close()
                    End Try
                End If
            End If

            If TextBox1.Text.Length > 0 Then
                'TextBox1.Text = File.ReadAllText(t & ".txt")

                If File.Exists(t & ".txt") = True Then

                    File.WriteAllText(t & ".txt", TextBox1.Text)

                    ' MessageBox.Show(TextBox1.Text)
                    Dim query As String = String.Empty
                    query &= "UPDATE Booking_Details SET scheduler_name=@colSN ,booked_on=@colBO,information=@colINFO " &
                     "WHERE scheduled_on=@colSO"

                    Using conn As New SqlConnection("Server= MADHAV-PC\SQLEXPRESS; Database = vb; Integrated Security = true")
                        Using comm As New SqlCommand()
                            With comm
                                .Connection = conn
                                .CommandType = CommandType.Text
                                .CommandText = query
                                .Parameters.AddWithValue("@colSN", Me.Text)
                                .Parameters.AddWithValue("@colSO", DayS1 + "/" + MonthS1 + "/" + YearS1)
                                .Parameters.AddWithValue("@colBO", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"))
                                .Parameters.AddWithValue("@colINFO", TextBox1.Text)


                            End With
                            Try
                                conn.Open()
                                comm.ExecuteNonQuery()

                                ' File.WriteAllText(t & ".txt", TextBox1.Text)

                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try

                        End Using
                    End Using

                    MessageBox.Show("Schedule Updated.")

                Else
                    File.WriteAllText(t & ".txt", TextBox1.Text)

                    Dim query As String = String.Empty
                    query &= "INSERT INTO Booking_Details (scheduler_name, scheduled_on, booked_on, "
                    query &= "                     information)  "
                    query &= "VALUES (@colSN,@colSO, @colBO, @colINFO)"

                    Using conn As New SqlConnection("Server= MADHAV-PC\SQLEXPRESS; Database = vb; Integrated Security = true")
                        Using comm As New SqlCommand()
                            With comm
                                .Connection = conn
                                .CommandType = CommandType.Text
                                .CommandText = query
                                .Parameters.AddWithValue("@colSN", Me.Text)
                                .Parameters.AddWithValue("@colSO", DayS + "/" + MonthS + "/" + YearS)
                                .Parameters.AddWithValue("@colBO", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"))
                                .Parameters.AddWithValue("@colINFO", TextBox1.Text)

                            End With
                            Try
                                conn.Open()
                                comm.ExecuteNonQuery()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try
                        End Using
                    End Using
                    MessageBox.Show("Schedule reserved on : " + DayS + "/" + MonthS + "/" + YearS)
                    Test()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim msg1 As MsgBoxResult
        t = MonthCalendar1.SelectionRange.Start.Month.ToString & MonthCalendar1.SelectionRange.Start.Day.ToString

        If Date.Today = MonthCalendar1.TodayDate And File.Exists(t & ".txt") = True Then
            msg1 = MsgBox(" You have a booking set for today, would like to view it?", MsgBoxStyle.YesNo)
            If msg1 = MsgBoxResult.Yes Then
                MonthCalendar1.Enabled = False
                MonthCalendar1.Hide()
                TextBox1.Enabled = True
                TextBox1.Show()
                Button1.Enabled = True
                Button1.Show()
                Button2.Enabled = True
                Button2.Show()
                TextBox1.Text = File.ReadAllText(t & ".txt")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Enabled = False
        TextBox1.Hide()
        Button1.Enabled = False
        Button1.Hide()
        Button2.Enabled = False
        Button2.Hide()
        MonthCalendar1.Enabled = True
        MonthCalendar1.Show()

    End Sub
    Private Sub Test()
        DataGridView1.Refresh()


    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim conn As New SqlConnection
        conn.ConnectionString = "Server= MADHAV-PC\SQLEXPRESS; Database = vb; Integrated Security = true"

        Dim cmd As New SqlCommand("SELECT * FROM Booking_Details where scheduler_name = '" + Me.Text + "'", conn)

        Dim adapter As New SqlDataAdapter(cmd)

        Dim table As New DataTable

        adapter.Fill(table)

        DataGridView1.DataSource = table
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim conn As New SqlConnection
        conn.ConnectionString = "Server= MADHAV-PC\SQLEXPRESS; Database = vb; Integrated Security = true"

        Dim cmd As New SqlCommand("SELECT * FROM Booking_Details", conn)

        Dim adapter As New SqlDataAdapter(cmd)

        Dim table As New DataTable

        adapter.Fill(table)

        DataGridView1.DataSource = table
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        msg = MsgBox("Do you really want to logout?", MsgBoxStyle.YesNo)
        If msg = MsgBoxResult.Yes Then
            Me.Close()
            Form1.Show()
            Form1.usnText.Select()
        End If
    End Sub
End Class