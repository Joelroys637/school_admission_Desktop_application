Imports System.Data.SQLite
Imports System.Data

Public Class dataview

    ' Change this path to the path of your SQLite database
    Private connectionString As String = "Data Source=C:\Users\LEO_JOEL_ROYS\OneDrive\Documents\Visual Studio 2010\Projects\desktop\desktop\bin\Release\user.db;Version=3;"

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Using conn As New SQLiteConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT * FROM user" ' Replace with your table name
                Dim cmd As New SQLiteCommand(query, conn)
                Dim adapter As New SQLiteDataAdapter(cmd)
                Dim dt As New DataTable()

                adapter.Fill(dt)

                DataGridView1.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
