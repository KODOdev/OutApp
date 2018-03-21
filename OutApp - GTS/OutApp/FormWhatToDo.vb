Public Class FormWhatToDo
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles fomClose.Click

        nextForm.Hide()

        Me.Close()

        FormMain.Show()

    End Sub

    Private Sub nextForm_Click(sender As Object, e As EventArgs) Handles nextForm.Click
        Me.Hide()
        FormSaveFolder.ShowDialog()

    End Sub

    Private Sub export_CheckedChanged(sender As Object, e As EventArgs) Handles export.CheckedChanged
        nextForm.Show()
    End Sub

    Private Sub report_CheckedChanged(sender As Object, e As EventArgs) Handles report.CheckedChanged
        nextForm.Show()
    End Sub

    Private Sub FormWhatToDo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        nextForm.Hide()

    End Sub

    Public Function get_what_to_do() As String

        Dim what_to_do As String

        If export.Checked = 1 Then

            what_to_do = export.Text
        Else

            what_to_do = report.Text

        End If

        Return what_to_do

    End Function

End Class