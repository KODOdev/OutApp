Public Class FormSaveFolder

    Dim choosed As Boolean = Nothing

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OpenSaveDialog.Click

        If outputfolder.ShowDialog() = DialogResult.OK Then

            Label_SelectedFolder.Text = outputfolder.SelectedPath.ToString
            nextForm.Show()

        Else

            outputfolder.SelectedPath = Nothing
            Label_SelectedFolder.Text = ""
            nextForm.Hide()

        End If



    End Sub

    Private Sub FormSaveFolder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        nextForm.Hide()

    End Sub


    Private Sub nextForm_Click(sender As Object, e As EventArgs) Handles nextForm.Click

        Me.Hide()
        Action.ShowDialog()

    End Sub



    Private Sub fomClose_Click(sender As Object, e As EventArgs) Handles fomClose.Click
        Me.Close()
        FormWhatToDo.Show()
    End Sub

    Public Function pick_output_Folder() As String

        Return outputfolder.SelectedPath.ToString

    End Function

End Class