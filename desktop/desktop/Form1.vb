Imports System.Data.SQLite

Public Class Form1

    Dim connection As SQLiteConnection

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Create database and table if not exists
        Dim dbPath As String = "Data Source=user.db;Version=3;"
        connection = New SQLiteConnection(dbPath)
        connection.Open()

        Dim cmd As New SQLiteCommand("CREATE TABLE IF NOT EXISTS user (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Age INTEGER ,gender TEXT, blood TEXT, aadher INTEGER, community TEXT, class TEXT, dateofbirth TEXT, address TEXT, Image BLOB)", connection)
        cmd.ExecuteNonQuery()
    End Sub
    Private Function ImageToByteArray(ByVal img As Image) As Byte()
        Dim ms As New System.IO.MemoryStream()
        img.Save(ms, img.RawFormat)
        Return ms.ToArray()
    End Function

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim name As String = TextBox1.Text.Trim()
        Dim age As Integer
        Dim gender As String = ComboBox1.Text()
        Dim blood As String = ComboBox2.Text()
        Dim aadher As Integer = TextBox5.Text()
        Dim community As String = TextBox6.Text()
        Dim clas As String = TextBox7.Text()
        Dim birth As String = TextBox8.Text()
        Dim address As String = TextBox9.Text()
        Dim imgData() As Byte = ImageToByteArray(PictureBox2.Image)

        If String.IsNullOrEmpty(name) OrElse Not Integer.TryParse(TextBox2.Text, age) Then
            MessageBox.Show("Please enter a valid name and age.")
            Return
        End If

        Dim insertCmd As New SQLiteCommand("INSERT INTO user (Name, Age,gender,blood,aadher,community,class,dateofbirth,address,Image) VALUES (@name, @age,@gender,@blood,@aadher,@community,@clas,@birth,@address, @image)", connection)
        insertCmd.Parameters.AddWithValue("@name", name)
        insertCmd.Parameters.AddWithValue("@age", age)
        insertCmd.Parameters.AddWithValue("@gender", gender)
        insertCmd.Parameters.AddWithValue("@blood", blood)
        insertCmd.Parameters.AddWithValue("@aadher", aadher)
        insertCmd.Parameters.AddWithValue("@community", community)
        insertCmd.Parameters.AddWithValue("@clas", clas)
        insertCmd.Parameters.AddWithValue("@birth", birth)
        insertCmd.Parameters.AddWithValue("@address", address)
        insertCmd.Parameters.AddWithValue("@image", imgData)
        insertCmd.ExecuteNonQuery()

        MessageBox.Show("Data saved successfully!")

        ' Optionally clear the inputs
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
       
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        If connection IsNot Nothing Then
            connection.Close()
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.Filter = "Image Files|*.jpg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(openFileDialog.FileName)
        End If
    End Sub
End Class
